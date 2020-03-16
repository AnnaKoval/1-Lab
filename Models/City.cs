using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ad4You.Models
{
    public class City
    {
        [Required] public int id { get; set; }
        [Required] public string name { get; set; }
        public virtual List<Ad> AdsByCity { get; set; }
    }
}