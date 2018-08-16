using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KemijskiSpojApp.Models
{
    public class ChemicalViewModel
    {
        public List<ChemicalType> ChemicalTypes { get; set; }
        public ChemicalCompound ChemicalCompound { get; set; }
    }
}