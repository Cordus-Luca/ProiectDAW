using ProiectRestanta.Entities;

namespace ProiectRestanta.Models.Entities.DTOs
{
    public class BossDTO
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int Salariu { get; set; }
        public Shop Shop { get; set; }

        public BossDTO(Boss boss)
        {
            this.Id = boss.Id;
            this.Nume = boss.Nume;
            this.Prenume = boss.Prenume;
            this.Salariu = boss.Salariu;
            this.Shop = new Shop();

        }
    }
}
