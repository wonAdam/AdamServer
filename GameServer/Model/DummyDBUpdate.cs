using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Model
{
    public class DummyDBUpdate
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DbId { get; set; }
        [Required]
        public long PlayerDbId { get; set; }
        [Required]
        public int Value { get; set; }
    }
}
