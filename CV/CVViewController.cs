using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using System.Threading.Tasks;
using MultiThreading.Controls;


namespace CV
{
	public partial class CVViewController : UIViewController
	{
		protected LoadingOverlay _loadPop = null;




		public CVViewController () : base ("CVViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();



		




			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();


			Task.Factory.StartNew (
				// tasks allow you to use the lambda syntax to pass work
				() => {
				Console.WriteLine ( "Hello from taskA." );




			}
			// ContinueWith allows you to specify an action that runs after the previous thread
			// completes
			// 
			// By using TaskScheduler.FromCurrentSyncrhonizationContext, we can make sure that 
			// this task now runs on the original calling thread, in this case the UI thread
			// so that any UI updates are safe. in this example, we want to hide our overlay, 
			// but we don't want to update the UI from a background thread.
			).ContinueWith ( 
			                t => {

				Console.WriteLine ( "Finished, hiding our loading overlay from the UI thread." );
			}, TaskScheduler.FromCurrentSynchronizationContext()
			);


			// Output a message from the original thread. note that this executes before
			// the background thread has finished.
			Console.WriteLine("Hello from the calling thread.");

			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

