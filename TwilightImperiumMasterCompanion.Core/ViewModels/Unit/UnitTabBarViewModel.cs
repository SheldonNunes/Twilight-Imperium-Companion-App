﻿using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core
{
	public class UnitTabBarViewModel : BaseViewModel
	{
		public readonly IUnitReferenceViewModel UnitReferenceViewModel;
		public readonly IPurchaseUnitViewModel PurchaseUnitViewModel;




		public UnitTabBarViewModel(
			IUnitReferenceViewModel unitReferenceViewModel, 
			IPurchaseUnitViewModel purchaseUnitViewModel)
		{
			this.PurchaseUnitViewModel = purchaseUnitViewModel;
			this.UnitReferenceViewModel = unitReferenceViewModel;
		}


	}
}
