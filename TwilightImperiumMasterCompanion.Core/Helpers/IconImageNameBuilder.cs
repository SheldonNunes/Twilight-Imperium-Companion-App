using System;
namespace TwilightImperiumMasterCompanion.Core.Helpers
{
    public class IconImageNameBuilder
    {
        public static string IconImageNameForString(string name){
            return name.Replace(" ", String.Empty) + "Icon";
        }
    }
}
