using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KemijskiSpojApp.Models
{
    public class ChemicalSymbolValidate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var chemicalsymbols = (ChemicalCompound)validationContext.ObjectInstance;
            var symbols = chemicalsymbols.ChemicalSymbol;
            int numberofSign = 0;
            int position = 0;
        
            if (String.IsNullOrEmpty(symbols))
                return new ValidationResult("Required!");


            //check if the formula starts with a digit
            if (!char.IsLetter(symbols[0]))
            {
                return new ValidationResult("Kemijski spoj počinje sa slovom!");
            }

            for (int i = 0; i < symbols.Length - 1; i++)
            {
                if (!char.IsLetterOrDigit(symbols[i]))
                {
                    return new ValidationResult("Kemijski spoj se sastoji od slova i brojeva npr: H2O, CO2, HO itd..");
                }
            }

            for (int i = 0; i < symbols.Length; i++)
            {  
                if (char.IsLetter(symbols[i]))
                {
                    if ((i + 1) < symbols.Length && !symbols[i].Equals('O') && !symbols[i].Equals('C') && !symbols[i].Equals('H'))
                    {
                        if (symbols[i].Equals('N') && (symbols[i + 1].Equals('a') || symbols[i + 1].Equals('A')))
                        {
                            i++;
                            numberofSign++;
                        }
                        else if (symbols[i].Equals('N'))
                        {
                            numberofSign++;
                        }

                    }
                 
                    else if (symbols[i].Equals('O') || symbols[i].Equals('C') || symbols[i].Equals('H') || symbols[i].Equals('N'))
                    {
                        numberofSign++;
                    }
                                      
                    else
                    {
                        return new ValidationResult("Kemijski spoj se može sastojati od kisika(O), vodika(H), uglika(C), natrija(Na), dušika(N).");
                    }                      
                }
            }

            if (numberofSign < 2)
            {
                return new ValidationResult("Kemiski spoj mora imati bar 2 elementa!");

            }
            return ValidationResult.Success;

        }
    }
}