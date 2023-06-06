using System.ComponentModel.DataAnnotations;

namespace MvcRiku.Models
{
    public class SuperHeroe
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public string? Genre { get; set; }
        public string Power { get; set; }
        public string BestSeller { get; set; }
    }
}