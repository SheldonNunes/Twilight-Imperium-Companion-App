using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

namespace TwilightImperiumMasterCompanion.Core
{
	public class BaseViewModel : MvxViewModel
	{

		protected bool ShowViewModel<TViewModel, TInit>(TInit parameter) where TViewModel : BaseViewModel<TInit>
		{
			var text = Mvx.Resolve<IMvxJsonConverter>().SerializeObject(parameter);
			return base.ShowViewModel<TViewModel>(new Dictionary<string, string> { { "parameter", text } });
		}
	}

	public abstract class BaseViewModel<TInit> : BaseViewModel
	{

		public void Init(string parameter)
		{
			var deserialized = Mvx.Resolve<IMvxJsonConverter>().DeserializeObject<TInit>(parameter);
			RealInit(deserialized);
		}

		protected abstract void RealInit(TInit parameter);
	}
}
