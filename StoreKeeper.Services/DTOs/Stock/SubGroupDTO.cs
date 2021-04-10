namespace StoreKeeper.Services.DTOs
{
    public class SubGroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code {get; set;}
        public string Description {get; set;}
        public bool IsVisible {get; set;} = true;
        public int ProductGroupID {get; set;}
        public ProductGroupDTO ProductGroup {get; set;}
    }
}
