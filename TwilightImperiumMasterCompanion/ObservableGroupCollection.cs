using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace TwilightImperiumMasterCompanion
{
	public class ObservableGroupCollection<S, T> : ObservableCollection<T>
	{
		private readonly S _key;

		public ObservableGroupCollection(IGrouping<S, T> group)
			: base(group)
		{
			_key = group.Key;
		}

		public S Key
		{
			get { return _key; }
		}
	}
}

