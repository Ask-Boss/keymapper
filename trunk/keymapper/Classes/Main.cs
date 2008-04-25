using System;
using System.Windows.Forms;
using System.Security.Permissions;

[assembly: CLSCompliant(true)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true, UnmanagedCode = true)]

// TODO: Figure out what needs to be done so exception doesn't occur calling registry access 
// [assembly: PermissionSet(SecurityAction.RequestOptional, Name = "Nothing")]

namespace KeyMapper
{
	class main
	{

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{

			// Redirect console first of all..
			
#if DEBUG
#else
			Console.Write("Redirecting console output");
			AppController.RedirectConsoleOutput();
#endif
			
			// Look for a running copy and activate it if it exists
			// (Writing to log if it does)
			if (AppController.CheckForExistingInstances() == true)
			{
				Console.WriteLine("Switching to existing instance");
				AppController.CloseConsoleOutput();
				return;
			}

			// Now, look at the arguments passed:

			// First up - look for the flag which orders us to reset the user config..

			foreach (string arg in args)
			{
				if (arg == "-reset")
					AppController.CreateNewUserConfigFile();
			}

AppController.CreateNewUserConfigFile();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

	 		Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
		 	Application.ThreadException += ApplicationThreadException;
		 	AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

			AppController.StartAppController();

			Application.Run(new KeyboardForm());

			AppController.CloseAppController();
			Application.ThreadException -= ApplicationThreadException; // Release static event or else..
			AppDomain.CurrentDomain.UnhandledException -= UnhandledExceptionHandler;

		}

		static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
		{
			MessageBox.Show("There's been a terrible error!");

			Exception ex = e.ExceptionObject as Exception;
			if (ex != null)
			{
				Console.WriteLine("Unhandled exception: {0}", ex);
			}
		}

		static void ApplicationThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			ArgumentException aex = e.Exception as ArgumentException;
			if (aex != null)
			{
				if (aex.ParamName != null && aex.ParamName.ToUpperInvariant() == "CULTURE")
				{
					// This is a bug in the .NET framework where some cultures won't load on Windows Server 2003
					// and throw "Culture ID x (0xX) is not a supported culture"

					// MessageBox.Show("Handled");
					return;
				}
			}

			MessageBox.Show("Unhandled exception: " + e.Exception.ToString());
		}
	}
}