using ProiectRestanta.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProiectRestanta.Models.Entities
{
    public class SessionToken
    {
        public SessionToken() { }
        public SessionToken(string Jti, int userId, DateTime expirationDate)
        {
            this.Jti = Jti;
            this.UserId = userId;
            this.ExpirationDate = expirationDate;
        }

        [Key]
        public string Jti { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
