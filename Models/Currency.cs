using System.ComponentModel.DataAnnotations;

namespace Ad4You.Models
{
    public class Currency
    {
        [Required] public int id { get; set; }
        [Required] public string sign { get; set; }
    }
}