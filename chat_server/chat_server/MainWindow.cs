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
	public static System.Net.Sockets.Socket listener = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();	
		status_label = StatusLBL;
		console_text = ConsoleTXT;

		IPAddress ipAddress = IPAddress.Parse ("127.0.0.1");
		IPEndPoint localEndPoint = new IPEndPoint (ipAddress, 23);

		Thread server = new Thread (() => Start_Server(localEndPoint));
		server.IsBackground = true;
		server.Start ();

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}



	public static void Start_Server(IPEndPoint localEndPoint)
	{
		// Incoming data from the client
		string data = null;

		// Data buffer
		byte[] bytes = new Byte[1024];

		// Listen for incoming connections

		try {
			listener.Bind(localEndPoint);
			listener.Listen(10);

			while (true) {
				
				status_label.Text = "Waiting for a connection...";
				System.Net.Sockets.Socket handler = listener.Accept();
				data = null;

				// Process incoming connection

				while (true) {
					status_label.Text = "connected";
					bytes = new byte[1024];
					int bytesRec = handler.Receive(bytes);
					data += Encoding.ASCII.GetString(bytes,0,bytesRec);

					// Show data in the console
					console_text.Buffer.Text += data + "\n";


					if (data.IndexOf("<EOF>") > -1 ) {
						handler.Shutdown(SocketShutdown.Both);
						handler.Close();
						status_label.Text = "disconnected";
						break;
					}

					data = null;
				}

				// Send something back

				byte[] msg = Encoding.ASCII.GetBytes("hello sir");

				handler.Send(msg);


				}

		} catch (Exception e) {
			console_text.Buffer.Text = e.ToString ();
		}

	}

}



