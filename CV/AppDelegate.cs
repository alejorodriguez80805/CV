using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace CV
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow _window;
		UINavigationController _nav;
		DialogViewController _rootVC;
		RootElement _rootElement;
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			_window = new UIWindow (UIScreen.MainScreen.Bounds);
			

			_rootElement = new RootElement ("CV"){
				new Section ("Json"){
					new JsonElement ("Descargar Json URL", "http://127.0.0.1:8000/backend/")
				},
			};

			_rootVC = new DialogViewController (_rootElement);
			_nav = new UINavigationController (_rootVC);



			_window.RootViewController = _nav;
			_window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

