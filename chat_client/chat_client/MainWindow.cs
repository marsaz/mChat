using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	public static Label status_label;
	public static TextView console_text;
	public static System.Net.Sockets.Socket socket = new System.Net.Sockets.Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
	public static Entry MsgInput;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		status_label = StatusLBL;
		console_text = ConsoleTXT;
		MsgInput = ChatInput;

		IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
		IPEndPoint remoteEP = new IPEndPoint(ipAddress, 23);

		Thread Client = new Thread (() => Start_Client(socket, remoteEP));
		Client.IsBackground = true;
		Client.Start ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	public static void Start_Client(System.Net.Sockets.Socket socket, IPEndPoint remoteEP)
	{
		// Data buffer
		byte[] bytes = new byte[1024];

		// Connect to a server

			try {
				socket.Connect(remoteEP);
				status_label.Text = "connected";				

				// Receive data
				int bytesRec = socket.Receive(bytes);
				console_text.Buffer.Text = Encoding.ASCII.GetString(bytes,0,bytesRec);

				socket.Shutdown(SocketShutdown.Both);
				socket.Close();
				status_label.Text = "disconnected";

			} catch (ArgumentNullException ane) {
				console_text.Buffer.Text = ane.ToString();
			} catch (SocketException se) {
				console_text.Buffer.Text = se.ToString();
			} catch (Exception e) {
				console_text.Buffer.Text = e.ToString();
			}
		
		}

	public static void Send_Msg (System.Net.Sockets.Socket socket)
	{
		try {
			
			// Encode message string
			byte[] msg = Encoding.ASCII.GetBytes(MsgInput.Text);

			// Send data
			int bytesSent = socket.Send(msg);

		} catch (Exception e) {
			console_text.Buffer.Text = e.ToString ();
		}
	}


	protected void OnSendBTNClicked (object sender, EventArgs e)
	{
		Send_Msg (socket);
	}
}
