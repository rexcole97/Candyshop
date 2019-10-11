using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace candyshop.Data
{
    public class Cshop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CSID { get; set; }
        public string CSstyle { get; set; }
        public string CSlocation { get; set; }
    }
}
