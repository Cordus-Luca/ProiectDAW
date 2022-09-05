namespace ProiectRestanta.Entities.DTOs
{
    public class ShopDTO
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int Stoc { get; set; }
        public int BossId { get; set; }
        public Boss Boss { get; set; }
        public List<Shirt> Shirts { get; set; }

        public ShopDTO(Shop shop)
        {
            this.Id = shop.Id;
            this.Nume = shop.Nume;
            this.Stoc = shop.Stoc;
            this.BossId = shop.BossId;
            this.Boss = new Boss();
            this.Shirts = new List<Shirt>();

        }
    }
}
