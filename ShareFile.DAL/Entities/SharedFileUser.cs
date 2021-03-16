using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShareFile.DAL.Entities
{
    public class SharedFileUser
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public virtual ICollection<SharedFile> SharedFiles { get; set; }
        public virtual ICollection<Token> AccessTokens { get; set; }




    }
}
