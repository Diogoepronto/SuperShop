using System.ComponentModel.DataAnnotations;
using System;

namespace SuperShop.Models
{
    public class DeliveryViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Delivery Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime? DeliveryDate { get; set; }
    }
}
