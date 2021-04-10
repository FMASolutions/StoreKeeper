namespace StoreKeeper.Core.DTOs
{
    public class ProductGroupDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code {get; set;}
        public string Description {get; set;}
        public bool IsVisible {get; set;} = true;
    }
}
