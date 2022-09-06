using ProiectRestanta.Entities;

namespace ProiectRestanta.Models.Entities.DTOs
{
    public class DesignDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Culoare { get; set; }
        public int Pret { get; set; }
        public List<ShirtDesign> ShirtDesigns { get; set; }

        public DesignDTO(Design design)
        {
            this.Id = design.Id;
            this.Model = design.Model;
            this.Culoare = design.Culoare;
            this.Pret = design.Pret;
            this.ShirtDesigns = new List<ShirtDesign>();
        }
    }
}
