using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace candyshop.Data
{
    public class candies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CID { get; set; }
        public string CSflavor { get; set; }
        public string Corigin { get; set; }
        public string Cwrapper { get; set; }
        public int CSID { get; set; }
        [ForeignKey("CSID")]
        public Cshop Candyshop { get; set; }
    }
}
