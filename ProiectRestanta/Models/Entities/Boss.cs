namespace ProiectRestanta.Entities
{
    public class Boss
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int Salariu { get; set; }
        public Shop Shop { get; set; }
    }
}
