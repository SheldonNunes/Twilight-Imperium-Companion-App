using System;
using System.IO;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using TwilightImperiumMasterCompanion.Core.ViewModels.Rules;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS.ViewControllers.Rules
{
    public partial class RulesView : MvxViewController
    {
        public RulesView() : base("RulesView", null)
        {
        }

        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                pdfView.LoadRequest(new NSUrlRequest(new NSUrl(value, false)));
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string path = "";
			string filePath = Path.Combine(path, "ti3rules.pdf");

            pdfView.LoadRequest(new NSUrlRequest(new NSUrl(filePath, false)));
            pdfView.ScalesPageToFit = true;


			//Bindings
            var set = this.CreateBindingSet<RulesView, RulesViewModel>();
            set.Bind(this).For(v => v.FileName).To(vm => vm.RuleBookFileName);
			set.Apply();


            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

