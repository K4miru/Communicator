using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        IPGlobalProperties propertiesIP = IPGlobalProperties.GetIPGlobalProperties();
        private TcpListener server = null;
        private TcpClient client =null;
        private BinaryReader reading = null;
        private BinaryWriter writing = null;
        private bool activeCall = false;
        private bool bold = false;
        private bool italic= false;
        [DllImport("user32.dll")]
        static extern bool FlashWindow(IntPtr hwnd, bool bInvert);
        public void Combo()
        {
            string priev = "";
            foreach (IPEndPoint connectUdp in propertiesIP.GetActiveUdpListeners())
            {
                char[] chartab = connectUdp.Address.ToString().ToCharArray();
                if (chartab[0].ToString() != "0" && chartab[0].ToString() != ":" && chartab[0].ToString() != "f")
                {
                    
                    if (priev != connectUdp.Address.ToString())
                    {
                        cBAddress.Items.Add(connectUdp.Address.ToString());
                        priev = connectUdp.Address.ToString();
                    }
                }
                    
            }
        }
        

        public Form1()
        {
            InitializeComponent();
            Combo();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            if (!activeCall)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                activeCall = false;
                backgroundWorker1.CancelAsync();
                writing.Write("END");
                client.Close();
                server.Stop();
                lbSerwer.Items.Add("Zakończono pracę serwera ...");
                bStart.Enabled = true;
                bStart.Text = "Start";
                tBNick.Enabled = true;
                bStop.Enabled = false;
            }
        }

        

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            if (lbSerwer.InvokeRequired || cBAddress.InvokeRequired)
            {
                IPAddress adresIP = null;
                string host = "";
                cBAddress.Invoke(new MethodInvoker(delegate { 
                    if(cBAddress.SelectedItem!=null)
                        host = cBAddress.SelectedItem.ToString();
                    else
                        host = cBAddress.Text.ToString();

                }));
                int port = System.Convert.ToInt16(numPort.Value);

                try
                {
                    client = new TcpClient(host, port);
                    lbSerwer.Invoke(new MethodInvoker(delegate { lbSerwer.Items.Add("Nawiązano połączenie z " + host + " Na porcie: " + port); }));
                    NetworkStream ns = client.GetStream();
                    reading = new BinaryReader(ns);
                    writing = new BinaryWriter(ns);
                    writing.Write("password");

                    string passReceived;
                    passReceived = reading.ReadString();
                    if (passReceived == "NO")
                    {
                        lbSerwer.Invoke(new MethodInvoker(delegate { lbSerwer.Items.Add("" + passReceived + ""); }));
                    }
                    else
                    {
                        if (tBNick.TextLength == 0)
                            tBNick.Invoke(new MethodInvoker(delegate { tBNick.Text = "Client"; }));
                        tBNick.Invoke(new MethodInvoker(delegate { tBNick.Enabled = false; }));
                        bStart.Invoke(new MethodInvoker(delegate { bStart.Enabled = false; }));
                        bStop.Invoke(new MethodInvoker(delegate { bStop.Enabled = true; }));
                        backgroundWorker2.RunWorkerAsync();
                    }
                    activeCall = true;
                }
                catch (Exception ex)
                {
                    lbSerwer.Invoke(new MethodInvoker(delegate { lbSerwer.Items.Add("" + ex.ToString() + ""); }));
                    lbSerwer.Invoke(new MethodInvoker(delegate { lbSerwer.Items.Add("Błąd połączenia jako klient, uruchamiam serwer"); }));
                    try
                    {
                        if (cBAddress.SelectedItem != null)
                            adresIP = IPAddress.Parse(cBAddress.SelectedItem.ToString());
                        else
                            adresIP = IPAddress.Parse(cBAddress.Text.ToString());
                        bStart.Enabled = false;
                        bStop.Enabled = false;
                    }
                    catch{

                        MessageBox.Show("Błędny format adresu IP" + adresIP, "Błąd");
                        cBAddress.Invoke(new MethodInvoker(delegate { cBAddress.Text = ""; }));
                        return;
                    }


                    try
                    {
                        server = new TcpListener(adresIP, port);
                        server.Start();
                        lbSerwer.Invoke(new MethodInvoker(delegate { lbSerwer.Items.Add("Oczekiwanie na połączenie"); }));
                        client = server.AcceptTcpClient();
                        NetworkStream ns = client.GetStream();
                        reading = new BinaryReader(ns);
                        writing = new BinaryWriter(ns);
                        if (reading.ReadString() == "password")
                        {
                            writing.Write("OK");
                            if (tBNick.TextLength == 0)
                                tBNick.Invoke(new MethodInvoker(delegate { tBNick.Text = "Serwer"; }));
                            activeCall = true;
                            IPEndPoint IP = (IPEndPoint)client.Client.RemoteEndPoint;
                          
                            tBNick.Invoke(new MethodInvoker(delegate { tBNick.Enabled = false; }));
                            lbSerwer.Invoke(new MethodInvoker(delegate { lbSerwer.Items.Add("[" + IP.ToString() + "] : Nawiązano połączenie"); }));
                            bStart.Invoke(new MethodInvoker(delegate { bStart.Enabled = true; }));
                            bStart.Invoke(new MethodInvoker(delegate { bStart.Text = "Stop"; }));
                            bStop.Invoke(new MethodInvoker(delegate { bStop.Enabled = true; }));
                            backgroundWorker2.RunWorkerAsync();
                        }
                        else
                        {
                            writing.Write("NO");
                            activeCall = false;
                            lbSerwer.Invoke(new MethodInvoker(delegate { lbSerwer.Items.Add("złe hasło"); }));
                            backgroundWorker1.CancelAsync();
                            //client.Close();
                            //server.Stop();
                            lbSerwer.Invoke(new MethodInvoker(delegate { lbSerwer.Items.Add("Zakończono pracę serwera ..."); }));
                            bStart.Invoke(new MethodInvoker(delegate { bStart.Enabled = true; }));
                            bStop.Invoke(new MethodInvoker(delegate { bStop.Enabled = false; }));
                        }//client.Close();
                         //server.Stop();
                    }
                    catch (Exception exr)
                    {
                        lbSerwer.Invoke(new MethodInvoker(delegate { lbSerwer.Items.Add("Błąd inicjacji serwera!"); }));
                        bStart.Invoke(new MethodInvoker(delegate { bStart.Enabled = true; }));
                        activeCall = false;
                        MessageBox.Show(exr.ToString(), "Błąd");
                    }
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (activeCall)
            {
                string messageReceived = reading.ReadString();
                if (messageReceived != "END")
                {
                    wB1.Invoke(new MethodInvoker(delegate { wB1.DocumentText += "" + messageReceived + ""; }));
                    IntPtr handle = Handle;
                    FlashWindow(handle,false);
                    Console.Beep();
                }
                else
                {
                    lbSerwer.Invoke(new MethodInvoker(delegate { lbSerwer.Items.Add("Wyłączono serwer!"); }));
                    activeCall = false;
                    bStart.Invoke(new MethodInvoker(delegate { bStart.Enabled = true; }));
                    tBNick.Invoke(new MethodInvoker(delegate { tBNick.Enabled = true; }));
                    bStop.Invoke(new MethodInvoker(delegate { bStop.Enabled = false; }));
                }
                
            }
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void tB1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Send();
            }
            else if (e.Alt && e.KeyCode == Keys.B)
            {
                Bold();
            }else if(e.Alt && e.KeyCode == Keys.I)
            {
                Italic();
            }

        }

        public void Send() {
            if (activeCall)
            {
                string Nick = tBNick.Text;
                string messageSend = tB1.Text;
                if (messageSend.Length > 0)
                {
                    if (bold && italic)
                        messageSend = "<b><em>" + messageSend + "</b></em>";
                    else if (bold)
                        messageSend = "<b>" + messageSend + "</b>";
                    else if (italic)
                        messageSend = "<em>" + messageSend + "</em>";

                    wB1.Invoke(new MethodInvoker(delegate { wB1.DocumentText += "<div style = 'text-align: right;width:480px;' >" + Nick + " " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + "<br>" + messageSend + "</div><hr>"; }));
                    messageSend = "<div style='text-align: left;width:480px;'>"+Nick+" "  + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + "<br>" + messageSend + "</div><hr>";
                    tB1.Invoke(new MethodInvoker(delegate { tB1.Text = ""; }));
                    writing.Write(messageSend);
                }
            }
        }


        public void Bold()
        {
            if (bold)
            {
                bold = false;
                btBold.BackColor = SystemColors.Control;
            }
            else
            {
                bold = true;
                btBold.BackColor = SystemColors.Info;
            }
        }

        public void Italic()
        {
            if (italic)
            {
                italic = false;
                btItalic.BackColor = SystemColors.Control;
            }
            else
            {
                italic = true;
                btItalic.BackColor = SystemColors.Info;
            }
        }

        private void btItalic_Click(object sender, EventArgs e)
        {
            Italic();
        }

        private void btBold_Click(object sender, EventArgs e)
        {
            Bold();
            
        }


    }
}
