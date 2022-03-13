using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Model
{
    internal class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DbId { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string PasswordSalt { get; set; }
    }
}
