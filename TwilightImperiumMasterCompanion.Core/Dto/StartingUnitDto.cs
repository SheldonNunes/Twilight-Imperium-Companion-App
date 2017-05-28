namespace TwilightImperiumMasterCompanion.Core.Dto
{
    public class StartingUnitDto
    {
        public string Name
        {
            get;
            set;
        }

        public string Image
        {
            get { return Name.Replace(" ", string.Empty) + "Icon"; }
        }

        public string Title
        {
            get { return Quantity.ToString() + "x"; }
        }

        public int Quantity
        {
            get;
            set;
        }
    }
}
