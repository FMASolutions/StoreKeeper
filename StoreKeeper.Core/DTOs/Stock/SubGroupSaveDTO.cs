namespace StoreKeeper.Core.DTOs
{
    public class SubGroupSaveDTO
    {
        public string Code {get; set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public bool IsVisible {get; set;} = true;

        public int ProductGroupID {get; set;}
    }
}
