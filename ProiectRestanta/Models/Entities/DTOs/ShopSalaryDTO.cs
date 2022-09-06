namespace ProiectRestanta.Models.Entities.DTOs
{
    public class ShopSalaryDTO
    {
        public string ShopName { get; set; }
        public int BossSalary { get; set; }

        public ShopSalaryDTO(string shopName, int bossSalary)
        {
            this.ShopName = shopName;
            this.BossSalary = bossSalary;
        }
    }
}
