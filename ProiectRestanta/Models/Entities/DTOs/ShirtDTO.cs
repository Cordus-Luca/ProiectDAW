using ProiectRestanta.Entities;

namespace ProiectRestanta.Models.Entities.DTOs
{
    public class ShirtDTO
    {
        public int Id { get; set; }
        public string Culoare { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        public List<ShirtDesign> ShirtDesigns { get; set; }

        public ShirtDTO(Shirt shirt)
        {
            this.Id = shirt.Id;
            this.Culoare = shirt.Culoare;
            this.ShopId = shirt.ShopId;
            this.Shop = new Shop();
            this.ShirtDesigns = new List<ShirtDesign>();
        }
    }
}
