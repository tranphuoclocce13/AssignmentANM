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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssigmentForm
{
    public partial class MainForm : Form
    {
        private Thread chatServerThread = null;
        private Thread chatClientThread = null;
        private Thread transferServerThread = null;
        private Thread transferClientThread = null;
        private const int BUFFER_SIZE = 1024;
        private const string END_CONNECTION_STRING = "DISCONNECTPLEASE12345";
        private string yourIPAddress = string.Empty;
        private string partnerIPAddress = string.Empty;
        private int serverPort = 19999;
        private int transferPort = 29999;
        private string IPConnect = null;
        private int portConnect = 0;
        private TcpListener chatListener = null;
        private TcpListener transferListener = null;
        private TcpClient clientChat = null;
        private TcpClient clientTransfer = null;
        private NetworkStream netStream = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chatServerThread = new Thread(startChatServer);
            chatServerThread.IsBackground = true;
            chatServerThread.Start();

            transferServerThread = new Thread(startTransferServer);
            transferServerThread.SetApartmentState(ApartmentState.STA);
            transferServerThread.IsBackground = true;
            transferServerThread.Start();
            /*Set T is Back Ground to Terminal Program when Press X button*/

            yourIPAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            this.Text += " - " + yourIPAddress;
        }

        public void startTransferServer()
        {
            NetworkStream netstream = null;

            while (true)
            {
                try
                {
                    transferListener = new TcpListener(IPAddress.Any, transferPort);
                    transferListener.Start();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transferPort += 1;
                }
            }

            while (true)
            {
                try
                {
                    clientTransfer = transferListener.AcceptTcpClient();
                    netstream = clientTransfer.GetStream();

                    byte[] recData = new byte[BUFFER_SIZE];
                    int recBytes;
                    string saveFileName = string.Empty;
                    string fileName = string.Empty;

                    recBytes = netstream.Read(recData, 0, BUFFER_SIZE);
                    fileName = Encoding.ASCII.GetString(recData);
                    netstream.Write(recData, 0, recBytes);

                    string message = "Accept Incoming File: " + fileName;
                    DialogResult result = MessageBox.Show(message, "Incoming File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        SaveFileDialog dialogSave = new SaveFileDialog();

                        dialogSave.Filter = "All files (*.*)|*.*";
                        dialogSave.RestoreDirectory = true;
                        dialogSave.Title = "Where do you want to save the file?";
                        dialogSave.InitialDirectory = @"C:/";
                        dialogSave.FileName = fileName;

                        if (dialogSave.ShowDialog() == DialogResult.OK)
                            saveFileName = dialogSave.FileName;

                        if (saveFileName != string.Empty)
                        {
                            int totalrecbytes = 0;
                            FileStream Fs = new FileStream(saveFileName, FileMode.OpenOrCreate, FileAccess.Write);
                            while ((recBytes = netstream.Read(recData, 0, recData.Length)) > 0)
                            {
                                Fs.Write(recData, 0, recBytes);
                                totalrecbytes += recBytes;
                                if (recBytes < BUFFER_SIZE) break;
                            }
                            Fs.Close();
                            addTextView("Transfer File Done");
                            clientTransfer.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    addTextView(ex.Message);
                    clientTransfer.Close();
                }
            }      
        }

/*Method for Thread Call*/
        public void startChatServer()
        {
            while (true)
            {
                try
                {
                    chatListener = new TcpListener(IPAddress.Any, serverPort);
                    chatListener.Start();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    serverPort += 1;
                }
            }

            while (true)
            {
                try
                {
                    if (chatListener.Pending())
                    {
                        setStatus("Incoming Connection...");
                        string message = "Accept Incoming Connection?";
                        string caption = "New Connection";
                        MessageBoxButtons boxConfirm = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(message, caption, boxConfirm);
                        try
                        {
                            if (result == System.Windows.Forms.DialogResult.Yes)
                            {
                                clientChat = chatListener.AcceptTcpClient();
                                netStream = clientChat.GetStream();
                                //receive IP of Partner
                                byte[] receiveData = new byte[BUFFER_SIZE];
                                int receiveBytes = netStream.Read(receiveData, 0, BUFFER_SIZE);
                                partnerIPAddress = Encoding.ASCII.GetString(receiveData);

                                setStatus("Connected");

                                
                                while (true)
                                {
                                    receivingData();
                                }
                            }
                            else
                            {
                                clientChat = chatListener.AcceptTcpClient();
                                clientChat.Close();
                                setStatus("Waiting...");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            announceDisconnect();
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }  
        }


/*Method handle receiving data from Partner and write it to Form*/
        private void receivingData()
        {
            byte[] receiveData = new byte[BUFFER_SIZE];
            int receiveBytes = netStream.Read(receiveData, 0, BUFFER_SIZE);

            if (receiveBytes > 0)
            {
                string receiveMessage = Encoding.UTF8.GetString(receiveData);
                if (receiveMessage.Substring(0, END_CONNECTION_STRING.Length) == END_CONNECTION_STRING)
                {
                    clientChat.Close();
                    return;
                }
                
                receiveMessage = "Partner: " + receiveMessage;
                addTextView(receiveMessage);
            }
        }

/*Method handle sending data to Partner and write it to form*/
        private void sendingDaTa()
        {
            string writeMessage = tbMessage.Text;
            
            try
            {
                if (writeMessage.Length > 0)
                {
                    byte[] writeData = Encoding.UTF8.GetBytes(writeMessage);
                    int sendingSize = (writeData.Length > BUFFER_SIZE) ? BUFFER_SIZE : writeData.Length;
                    netStream.Write(writeData, 0, sendingSize);
                    writeMessage = "You: " + writeMessage;
                    addTextView(writeMessage);
                    tbMessage.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private delegate void SetTextCallback(string text);

/*Method edit status of connection*/
        private void setStatus(string text)
        {
            if (this.lbStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setStatus);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lbStatus.Text = text;
            }
        }

/*Method add Text to main view*/
        private void addTextView(string text)
        {
            try
            {
                if (this.tbView.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(addTextView);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.tbView.AppendText(text);
                    this.tbView.AppendText(Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }

/*Method handle connecting to Server to chat and send File*/
        public void connectToChatServer()
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient(IPConnect, portConnect);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                addTextView("Cannot connect to " + IPConnect + " at " + portConnect.ToString());
                return;
            }

            try
            {
                setStatus("Connected");
                netStream = client.GetStream();
                byte[] writeData = Encoding.UTF8.GetBytes(yourIPAddress);
                netStream.Write(writeData, 0, writeData.Length);

                while (true)
                {
                    receivingData();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                announceDisconnect();
                client.Close();
                return;
            }
        }

/*Method excute when press New Connection*/
        private void newConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputIPForm form = new InputIPForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                IPConnect = form.IP;
                portConnect = form.port;
                form.Dispose();
            }
            else
            {
                form.Dispose();
                return;
            }

            chatClientThread = new Thread(connectToChatServer);
            chatClientThread.IsBackground = true;
            chatClientThread.Start();
        }

/*Method excute when press View Port*/
        private void viewPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Port Server: " + serverPort.ToString() + '\n' + "Port Transfer: " + transferPort.ToString();
            MessageBox.Show(message, "Current Port",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

/*Method excute when press Send, send data to partner*/
        private void button1_Click(object sender, EventArgs e)
        {
            sendingDaTa();
        }

/*Check if Enter is pressing*/
        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendingDaTa();
                e.SuppressKeyPress = true;       
             }
        }

/*Method excute when press Disconnect*/
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] writeData = Encoding.ASCII.GetBytes(END_CONNECTION_STRING);
                netStream.Write(writeData, 0, writeData.Length);
                clientChat.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

/*Method show string disconnect on View Textbox*/
        public void announceDisconnect()
        {
            string message = "Your partner has disconnectd...";
            addTextView(message);
            setStatus("Waiting...");
        }

/*Change port of server, Close old port and start Thread for new one*/

/*Method excute when press Exit*/
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

/*Method handle transfer file without encryption*/
        private void nornalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transferClientThread = new Thread(connectToTransferServer);
            transferClientThread.IsBackground = true;
            transferClientThread.SetApartmentState(ApartmentState.STA);
            transferClientThread.Start();
        }

        private void chatPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePortForm changePort = new ChangePortForm();
            changePort.setOldPort(serverPort);

            if (changePort.ShowDialog() == DialogResult.OK)
            {
                chatListener.Stop();
                serverPort = changePort.newPort;
                string message = "Server Port has been changed to " + serverPort.ToString();
                addTextView(message);

                chatServerThread.Abort();
                chatServerThread = new Thread(startChatServer);
                chatServerThread.IsBackground = true;
                chatServerThread.Start();
            }

            changePort.Dispose();
        }

        private void transferPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePortForm changePort = new ChangePortForm();
            changePort.setOldPort(transferPort);

            if (changePort.ShowDialog() == DialogResult.OK)
            {
                transferListener.Stop();
                transferPort = changePort.newPort;
                string message = "Transfer Port has been changed to " + transferPort.ToString();
                addTextView(message);

                transferServerThread.Abort();
                transferServerThread = new Thread(startTransferServer);
                transferServerThread.IsBackground = true;
                transferServerThread.Start();
            }
            changePort.Dispose();
        }

        private void clearTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbView.Text = "";
        }

        public void connectToTransferServer()
        {
            NetworkStream netstream = null;
            byte[] sendingBuffer = null;

            try
            {
                string sendingFilePath = string.Empty;
                string fileName = string.Empty;
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "All Files (*.*)|*.*";
                openFile.CheckFileExists = true;
                openFile.Title = "Choose a File";
                openFile.InitialDirectory = @"C:\";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    sendingFilePath = openFile.FileName;
                    fileName = openFile.SafeFileName;

                }

                if (sendingFilePath != string.Empty)
                {
                    clientTransfer = new TcpClient(IPConnect, 29999);

                    netstream = clientTransfer.GetStream();
                    //send file name to receiver
                    sendingBuffer = new byte[fileName.Length];
                    sendingBuffer = Encoding.ASCII.GetBytes(fileName);
                    netstream.Write(sendingBuffer, 0, sendingBuffer.Length);
                    netstream.Read(sendingBuffer, 0, sendingBuffer.Length);

                    FileStream Fs = new FileStream(sendingFilePath, FileMode.Open, FileAccess.Read);

                    int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Fs.Length) / Convert.ToDouble(BUFFER_SIZE)));

                    int TotalLength = (int)Fs.Length, CurrentPacketLength;
                    while (TotalLength > 0) 
                    {
                        if (TotalLength > BUFFER_SIZE)
                        {
                            CurrentPacketLength = BUFFER_SIZE;
                            TotalLength = TotalLength - CurrentPacketLength;
                        }
                        else
                        {
                            CurrentPacketLength = TotalLength;
                            TotalLength = 0;
                        }
                            sendingBuffer = new byte[CurrentPacketLength];
                            Fs.Read(sendingBuffer, 0, CurrentPacketLength);
                            netstream.Write(sendingBuffer, 0, (int)sendingBuffer.Length);
                    }

                    addTextView("Transfer File Done");
                    Fs.Close();
                    clientTransfer.Close();
                }
            }
            catch (Exception ex)
            {
                addTextView(ex.Message);
            }
        }
    }
}
