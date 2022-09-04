namespace ProiectRestanta.Entities
{
    public class ShirtDesign
    {
        public int ShirtId { get; set; }
        public Shirt Shirt { get; set; }
        public int DesignId { get; set; }
        public Design Design { get; set; }
    }
}
