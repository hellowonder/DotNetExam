using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QueFirstWebMVC.Models
{
    public class Product
    {
        [Key]
        [Required(ErrorMessage ="please enter ProductId")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "please enter ProductName")]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "please enter Rate ")]
        [Range(0,double.MaxValue,ErrorMessage ="Please enter valid value")]
        public decimal Rate { get; set; }
        [Required(ErrorMessage = "please enter Description")]
        [StringLength(150)]
        public string Description { get; set; }
        [Required(ErrorMessage = "please enter CategoryName")]
        [StringLength(50)]
        public string CategoryName { get; set; }
    }
}