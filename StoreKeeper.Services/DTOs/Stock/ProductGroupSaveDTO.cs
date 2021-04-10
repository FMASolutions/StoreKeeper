namespace StoreKeeper.Services.DTOs
{
    public class ProductGroupSaveDTO
    {
        public string Code {get; set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public bool IsVisible {get; set;} = true;
    }
}
