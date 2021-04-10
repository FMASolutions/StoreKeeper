namespace StoreKeeper.Services.DTOs
{
    public class ProductGroupPreviewDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code {get; set;}
        public bool IsVisible {get; set;} = true;
    }
}
