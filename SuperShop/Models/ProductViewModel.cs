using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SuperShop.Data.Entities;

namespace SuperShop.Models
{
    public class ProductViewModel : Product
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
