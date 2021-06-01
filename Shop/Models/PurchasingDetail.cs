using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class PurchasingDetail
    {
        [Required(ErrorMessage = "Пожалуйста, введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните первую адресную линию")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название города")]
        public string City { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название штата")]
        public string State { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название страны")]
        public string Country { get; set; }
    }
}