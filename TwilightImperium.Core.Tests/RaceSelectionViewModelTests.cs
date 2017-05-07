//using MvvmCross.Test.Core;
//using NUnit.Framework;
//using TwilightImperiumMasterCompanion.Core;
//using MvvmCross.Core.Views;
//using MvvmCross.Platform.Core;
//using MvvmCross.Core.Platform;
//using MvvmCross.Platform.Platform;
//using MvvmCross.Platform;
//using MvvmCross.Plugins.Json;

//namespace TwilightImperium.Core.Tests
//{
//	[TestFixture]
//	public class RaceSelectionViewModelTests : MvxIoCSupportingTest
//	{
//		private static readonly int NUMBER_OF_DEFAULT_RACES = 10;
//		private static readonly int NUMBER_OF_SHATTERED_EMPIRES_RACES = 4;
//		private static readonly int NUMBER_OF_SHARDS_OF_THE_THRONES_RACES = 3;

//		protected MockDispatcher MockDispatcher
//		{
//			get;
//			private set;
//		}
//		// Setup is called before each test is run
//		[SetUp]
//		public void init()
//		{
//			base.ClearAll(); // This resets the IoC container.

//			MockDispatcher = new MockDispatcher();
//			Ioc.RegisterSingleton<IMvxViewDispatcher>(MockDispatcher);
//			Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(MockDispatcher);
//			Ioc.RegisterSingleton<IMvxJsonConverter>(new MvxJsonConverter());
//			// for navigation parsing
//			Ioc.RegisterSingleton<IMvxStringToTypeParser>(new MvxStringToTypeParser());
//		}

//		[Test]
//		public void Init_WithNoExpansions_CreatesValidRepository()
//		{
//			//Arrange
//			var parameter = new ExpansionsNavigationParameter()
//			{
//				ShatteredEmpiresExpansionEnabled = false,
//				ShardsofTheThroneExpansionEnabled = false
//			};
//			var serialized = Mvx.Resolve<IMvxJsonConverter>().SerializeObject(parameter);
//			var viewModel = Mvx.IocConstruct<RaceSelectionViewModel>();

//			//Act
//			viewModel.Init(serialized);

//			//Assert
//			var expected = NUMBER_OF_DEFAULT_RACES;
//			Assert.IsNotNull(viewModel.RaceRepository);
//			Assert.AreEqual(expected, viewModel.RaceRepository.GetRaces().Count);
//		}

//		[Test]
//		public void Init_WithShatteredEmpiresExpansion_CreatesValidRepository()
//		{
//			//Arrange
//			var parameter = new ExpansionsNavigationParameter()
//			{
//				ShatteredEmpiresExpansionEnabled = true,
//				ShardsofTheThroneExpansionEnabled = false
//			};
//			var serialized = Mvx.Resolve<IMvxJsonConverter>().SerializeObject(parameter);
//			var viewModel = Mvx.IocConstruct<ConfirmRaceViewModel>();

//			//Act
//			viewModel.Init(serialized);

//			//Assert
//			var expected = NUMBER_OF_DEFAULT_RACES + NUMBER_OF_SHATTERED_EMPIRES_RACES;
//			Assert.IsNotNull(viewModel.RaceRepository);
//			Assert.AreEqual(expected, viewModel.RaceRepository.GetRaces().Count);
//		}

//		[Test]
//		public void Init_WithShardsOfTheThroneExpansion_CreatesValidRepository()
//		{
//			//Arrange
//			var parameter = new ExpansionsNavigationParameter()
//			{
//				ShatteredEmpiresExpansionEnabled = false,
//				ShardsofTheThroneExpansionEnabled = true
//			};
//			var serialized = Mvx.Resolve<IMvxJsonConverter>().SerializeObject(parameter);
//			var viewModel = Mvx.IocConstruct<ConfirmRaceViewModel>();

//			//Act
//			viewModel.Init(serialized);

//			//Assert
//			var expected = NUMBER_OF_DEFAULT_RACES + NUMBER_OF_SHARDS_OF_THE_THRONES_RACES;
//			Assert.IsNotNull(viewModel.RaceRepository);
//			Assert.AreEqual(expected, viewModel.RaceRepository.GetRaces().Count);
//		}


//		[Test]
//		public void Init_WithAllExpansion_CreatesValidRepository()
//		{
//			//Arrange
//			var parameter = new ExpansionsNavigationParameter()
//			{
//				ShatteredEmpiresExpansionEnabled = true,
//				ShardsofTheThroneExpansionEnabled = true
//			};
//			var serialized = Mvx.Resolve<IMvxJsonConverter>().SerializeObject(parameter);
//			var viewModel = Mvx.IocConstruct<ConfirmRaceViewModel>();

//			//Act
//			viewModel.Init(serialized);

//			//Assert
//			var expected = NUMBER_OF_DEFAULT_RACES + NUMBER_OF_SHATTERED_EMPIRES_RACES + NUMBER_OF_SHARDS_OF_THE_THRONES_RACES;
//			Assert.IsNotNull(viewModel.RaceRepository);
//			Assert.AreEqual(expected, viewModel.RaceRepository.GetRaces().Count);
//		}
//	}
//}
