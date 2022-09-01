using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;

namespace RecieveStream
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach (Control control in this.Controls)
            {
                control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
            }

            CheckForIllegalCrossThreadCalls = false;

            ControlConnection.StartSocket();

            CheckConnectionThread = new Thread(CheckConnection);
            CheckConnectionThread.Start();

            ImageThread = new Thread(WirelessNetworkConnect);
            ImageDownloaded += UpdateImg;
            ImageThread.Start();

            KeyDown += KeyDownV;
            KeyUp += KeyUpV;          

            FormClosing += Close;

        }

        void Close(object sender, EventArgs e)
        {
            if(ImageThread != null)
                ImageThread.Abort();
            if(ControlThread != null)
                ControlThread.Abort();
            if (CheckConnectionThread != null)
                CheckConnectionThread.Abort();
            stop = true;
        }


        public Thread ControlThread;
        public Thread ImageThread;
        public Thread CheckConnectionThread;

        public delegate void UpdateImage();
        public event UpdateImage ImageDownloaded;

        public List<byte[]> ByteChunks = new List<byte[]>();


        private int LeftMotorValue = 0;
        public int LeftMotor
        {            
            get
            {
                return LeftMotorValue;
            }
            set
            {
                int oldValue = LeftMotorValue;
                LeftMotorValue = value;
                if (oldValue != 0 && LeftMotorValue == 0)
                    ControlConnection.SendMessage("s1");
                else if (oldValue == 0 && LeftMotorValue > 0)
                    ControlConnection.SendMessage("f1");
                else if (oldValue == 0 && LeftMotorValue < 0)
                    ControlConnection.SendMessage("b1");

            }
        }
        private int RightMotorValue = 0;
        public int RightMotor
        {
            get
            {
                return RightMotorValue;
            }
            set
            {
                int oldValue = RightMotorValue;
                RightMotorValue = value;
                if (oldValue != 0 && RightMotorValue == 0)
                    ControlConnection.SendMessage("s2");
                else if (oldValue == 0 && RightMotorValue > 0)
                    ControlConnection.SendMessage("f2");
                else if (oldValue == 0 && RightMotorValue < 0)
                    ControlConnection.SendMessage("b2");
            }
        }

        public byte[] ImageByteArray = new byte[] { };

        void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
            if (!KeysPressed.Contains(e.KeyCode))
            {
                KeysPressed.Add(e.KeyCode);
                if (OldControlsRadio.Checked)
                {
                    if (e.KeyCode == Keys.Escape)
                        stop = true;
                    else if (e.KeyCode == Keys.W)
                    {
                        RightMotor += 1;
                    }
                    else if (e.KeyCode == Keys.S)
                    {
                        RightMotor -= 1;
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        LeftMotor += 1;
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        LeftMotor -= 1;
                    }
                }
                else if (NewControlsRadio.Checked)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        LeftMotor += 1;
                        RightMotor += 1;
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        LeftMotor -= 1;
                        RightMotor -= 1;
                    }
                    else if (e.KeyCode == Keys.Right)
                    {
                        RightMotor += 1;
                    }
                    else if (e.KeyCode == Keys.Left)
                    {
                        LeftMotor += 1;
                    }
                    else if (e.KeyCode == Keys.Oemcomma)
                    {
                        LeftMotor += 1;
                        RightMotor -= 1;
                    }
                    else if (e.KeyCode == Keys.OemPeriod)
                    {
                        LeftMotor -= 1;
                        RightMotor += 1;
                    }
                }
            }
            if (KeysPressed.Any())
            {
                OldControlsRadio.Enabled = false;
                NewControlsRadio.Enabled = false;
            }
            else
            {
                OldControlsRadio.Enabled = true;
                NewControlsRadio.Enabled = true;
            }
        }

        public void KeyDownV(object sender, KeyEventArgs e)
        {
            
        }

        public void KeyUpV(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (KeysPressed.Contains(e.KeyCode))
            {
                KeysPressed.Remove(e.KeyCode);
                if (OldControlsRadio.Checked)
                {
                    if (e.KeyCode == Keys.Escape)
                        stop = true;
                    else if (e.KeyCode == Keys.W)
                    {
                        RightMotor -= 1;
                    }
                    else if (e.KeyCode == Keys.S)
                    {
                        RightMotor += 1;
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        LeftMotor -= 1;
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        LeftMotor += 1;
                    }
                }
                else if (NewControlsRadio.Checked)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        LeftMotor -= 1;
                        RightMotor -= 1;
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        LeftMotor += 1;
                        RightMotor += 1;
                    }
                    else if (e.KeyCode == Keys.Left)
                    {
                        LeftMotor -= 1;
                    }
                    else if (e.KeyCode == Keys.Right)
                    {
                        RightMotor -= 1;
                    }
                    else if (e.KeyCode == Keys.Oemcomma)
                    {
                        LeftMotor -= 1;
                        RightMotor += 1;
                    }
                    else if (e.KeyCode == Keys.OemPeriod)
                    {
                        LeftMotor += 1;
                        RightMotor -= 1;
                    }
                }
            }
            if (KeysPressed.Any())
            {
                OldControlsRadio.Enabled = false;
                NewControlsRadio.Enabled = false;
            }
            else
            {
                OldControlsRadio.Enabled = true;
                NewControlsRadio.Enabled = true;
            }
        }

        bool stop = false;
        public List<string> requests = new List<string>();

        public void HandleRequestFunction()
        {
            if (requests.Any())
            {
                ControlConnection.SendMessage(requests.First());
                requests.Remove(requests.First());
            }
        }  

        public List<Keys> KeysPressed = new List<Keys>();

        public void WirelessNetworkConnect()
        {
            UdpClient con = new UdpClient(50001);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 50001);
            while (!stop)
            {
                recieveMessage(con, groupEP);
            }
        }

        public void CheckConnection()
        {
            while (!stop)
            {
                if (ControlConnection.Client.Connected)
                {
                    OffOnDrone.Text = "Online";
                    OffOnDrone.ForeColor = Color.Lime;
                }
                else
                {
                    OffOnDrone.Text = "Offline";
                    OffOnDrone.ForeColor = Color.Red;
                }
                Ping P = new Ping();
                PingReply Pr = P.Send("192.168.43.30");
                if (Pr.Status == IPStatus.Success)
                {
                    LatencyDrone.Text = Pr.RoundtripTime + " ms";
                    if (Pr.RoundtripTime < 20)
                        LatencyDrone.ForeColor = Color.Lime;
                    else if (Pr.RoundtripTime < 80)
                        LatencyDrone.ForeColor = Color.Orange;
                    else
                        LatencyDrone.ForeColor = Color.Red;
                }
                else
                {
                    LatencyDrone.Text = "Timed out";
                    LatencyDrone.ForeColor = Color.Red;
                }
                ControlConnection.SendMessage("a");
                Thread.Sleep(1000);
            }
        }

        public void UpdateImg()
        {
            byte[] copy = ImageByteArray.ToArray();

            using (Image image = Image.FromStream(new MemoryStream(copy)))
            {
                Bitmap bp = new Bitmap(image);
                bp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                picture.Image = bp;
            }
        }
        public void recieveMessage(UdpClient uc, IPEndPoint end) {          
            ImageByteArray = uc.Receive(ref end);
            ImageDownloaded?.Invoke();
        }
        

        private void RestartConnectionButton_Click(object sender, EventArgs e)
        {
            if (!ControlConnection.Client.Connected)
            {
                ControlConnection.StartConnection();
            }
        }

        public static class ControlConnection
        {
            public static TcpClient Client;
            public static readonly string Address = "192.168.43.30";
            public static NetworkStream Stream;
            public static void StartSocket()
            {
                Client = new TcpClient();
                Client.SendBufferSize = 64;
            }
            public static void StartConnection()
            {
                Client = new TcpClient();
                Client.Connect(Address, 50000);
                Stream = Client.GetStream();
            }
            public static void SendMessage(string message)
            {
                if (Client.Connected)
                {
                    try
                    {
                        byte[] bytes = Encoding.ASCII.GetBytes(message);
                        Stream.Write(bytes, 0, bytes.Length);
                    }
                    catch
                    {
                        Client.Close();                        
                    }
                }
            }
        }

        public void ChangeControlScheme(object sender, EventArgs e)
        {

        }        
    }
}
