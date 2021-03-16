using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareFile.DAL.Entities
{
    public class Token
    {
        [Key]
        public int TokenId { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpirationDate { get; set; }
        [ForeignKey("SharedFileUser")]
        public int UserId { get; set; }
        public SharedFileUser SharedFileUser { get; set; }
    }
}
