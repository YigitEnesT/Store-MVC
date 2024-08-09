using System.ComponentModel.DataAnnotations;

namespace StoreApp.Models
{
    public class AddressViewModel
    {
        public string? bolge { get; set; }
        public int id { get; set; }
        [Required(ErrorMessage = "City is required.")]
        public string? il { get; set; }
        [Required(ErrorMessage = "County is required.")]
        public string? ilce { get; set; }
        public int plaka { get; set; }
    }
}