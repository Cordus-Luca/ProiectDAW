namespace ProiectRestanta.Entities
{
    public class Design
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Culoare { get; set; }
        public int Pret { get; set; }
        public ICollection<ShirtDesign> ShirtDesigns { get; set; }
    }
}
