namespace ProiectRestanta.Entities
{
    public class Shirt
    {
        public int Id { get; set; }
        public string Culoare { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        public ICollection<ShirtDesign> ShirtDesigns { get; set; }
    }
}
