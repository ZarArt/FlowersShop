using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowersShop.Models
{
    [MetadataType(typeof(FlowerMetaData))]
    public partial class Flower
    {
        [Bind(Exclude = "FlowerId")]
        public class FlowerMetaData
        {
            [ScaffoldColumn(false)]
            public int FlowerId { get; set; }

            [Display(Name = "Name")]
            [Required(ErrorMessage = "Flower name is required")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [StringLength(50)]
            public string Name { get; set; }

            [Display(Name = "Price")]
            [Required(ErrorMessage = "Flower price is required")]
            [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
            [Range(0.01, 1000, ErrorMessage = "Flower price has to be between 0,01 and 1000")]
            public decimal Price { get; set; }

            [Display(Name = "Article")]
            [Required(ErrorMessage = "Flower article is required")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [StringLength(50)]
            public string Article { get; set; }
        }
    }
}