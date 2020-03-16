using System.ComponentModel.DataAnnotations;

namespace Ad4You.Models
{
    public class Ad
    {
        [Required] public int id { get; set; }
        [Required] public string name { get; set; }
        public string description { get; set; }
        [Required] public string phone_number { get; set; }
        [Required] public int rubricid { get; set; }
        public virtual Rubric rubric { get; set; }
        public int cityid { get; set; }
        public virtual City city { get; set; }
        public uint price { get; set; }
        public int currencyid { get; set; }
        public virtual Currency currency { get; set; }
    }
}