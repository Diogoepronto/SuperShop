using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SuperShop.Models
{
    public class AddItemViewModel
    {
        [DisplayName("Product")]
        [Range(1,int.MaxValue, ErrorMessage = "You must select a product")]
        public int ProductId { get; set; }


        [Range(0.0001, double.MaxValue, ErrorMessage = "The quantity must be a positive number")]
        public double Quantity{ get; set; }


        public IEnumerable<SelectListItem> Products { get; set; }
    }
}
