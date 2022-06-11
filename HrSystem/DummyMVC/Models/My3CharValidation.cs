using System.ComponentModel.DataAnnotations;

namespace DummyMVC.Models
{
    public class My3CharValidation : ValidationAttribute
    {

        public override bool IsValid(object? value)
        {
            if (value == null) return false;
            if (value.ToString().Length < 3)
            {
                if (string.IsNullOrEmpty(ErrorMessage))
                {
                    ErrorMessage = "PLease enter 3 char.";
                }
                
                return false;
            }
            return true;
            
        }
    }
}
