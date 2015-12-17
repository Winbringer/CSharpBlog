
using System.ComponentModel.DataAnnotations;


namespace ДвижокНовостейЗМ.Models
{
  public  class TitleValidation: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            string title =(string)value;
            char upper = title[1];
            return !(char.IsUpper(upper));          
        }
    }
    public class ValidationAtributs
    {

    }
}
