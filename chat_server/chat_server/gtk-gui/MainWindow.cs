
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.Fixed fixed1;
	
	private global::Gtk.Label StatusLBL;
	
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	
	private global::Gtk.TextView ConsoleTXT;
	
	private global::Gtk.Button button1;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.fixed1 = new global::Gtk.Fixed ();
		this.fixed1.Name = "fixed1";
		this.fixed1.HasWindow = false;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.StatusLBL = new global::Gtk.Label ();
		this.StatusLBL.Name = "StatusLBL";
		this.StatusLBL.LabelProp = global::Mono.Unix.Catalog.GetString ("Status");
		this.fixed1.Add (this.StatusLBL);
		global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.StatusLBL]));
		w1.X = 64;
		w1.Y = 11;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.ConsoleTXT = new global::Gtk.TextView ();
		this.ConsoleTXT.WidthRequest = 300;
		this.ConsoleTXT.HeightRequest = 200;
		this.ConsoleTXT.CanFocus = true;
		this.ConsoleTXT.Name = "ConsoleTXT";
		this.ConsoleTXT.Editable = false;
		this.GtkScrolledWindow.Add (this.ConsoleTXT);
		this.fixed1.Add (this.GtkScrolledWindow);
		global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.GtkScrolledWindow]));
		w3.X = 34;
		w3.Y = 59;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.button1 = new global::Gtk.Button ();
		this.button1.CanFocus = true;
		this.button1.Name = "button1";
		this.button1.UseUnderline = true;
		this.button1.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
		this.fixed1.Add (this.button1);
		global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.button1]));
		w4.X = 25;
		w4.Y = 26;
		this.Add (this.fixed1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 400;
		this.DefaultHeight = 333;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
	}
}
