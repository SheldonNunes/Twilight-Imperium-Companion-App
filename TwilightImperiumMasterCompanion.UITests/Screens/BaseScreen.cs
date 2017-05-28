using System;
using Xamarin.UITest;

namespace TwilightImperiumMasterCompanion.UITests
{
	public abstract class BaseScreen
	{
		protected IApp app { get; private set; }

		protected BaseScreen(IApp app)
		{
			this.app = app;
		}
	}
}
