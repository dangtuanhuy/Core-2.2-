using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WineDemo.Model
{
    public class Wine
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wine Name can not null")]
        [Display(Name = "Wine Name")]

        [StringLength(100)]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "ISBS can not null")]
        [Display(Name = "ISBS")]
        public string ISBS { get; set; }

        [Required(ErrorMessage = "Publisher can not null")]
        [Display(Name = "Publisher")]
        public string Publisher { get; set; }
    }
}
