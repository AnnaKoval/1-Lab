using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ad4You.Models
{
    public class Rubric
    {
        [Required] public int id { get; set; }
        [Required] public string name { get; set; }
        public virtual List<Ad> AdsByRubric { get; set; }
    }
}
