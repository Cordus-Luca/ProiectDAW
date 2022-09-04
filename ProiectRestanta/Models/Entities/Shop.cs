namespace ProiectRestanta.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int Stoc { get; set; }
        public int BossId { get; set; }
        public Boss Boss { get; set; }
        public ICollection<Shirt> Shirts { get; set; }
    }
}
