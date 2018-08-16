using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KemijskiSpojApp.Models
{
    public class ChemicalCompound
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Unesite naziv spoja!")]
        [Display(Name="Naziv spoja:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Unesite kemijsku formulu spoja!")]
        [Display(Name = "Kemijska formula spoja (sastavljena od: Na, H, C, O, N):")]
        [ChemicalSymbolValidate]
        public string ChemicalSymbol { get; set; }


        public ChemicalType ChemicalType { get; set; }

        [Required(ErrorMessage = "Unesite tip spoja!")]
        [Display(Name = "Tip spoja:")]
        public byte ChemicalTypeId { get; set; }
    }
}