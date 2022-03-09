using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Model
{
    public class AccountDb
    {
        [Key]
        public int DbId { get; set; }
        public string PlayerNickname { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
