
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Utilities
{
    
    //custom validation attribute creation
    //1) inherit ValdiationAttribute abstract class
    //2) override is Valid funtion
    public class ValidEmailDomainAttribute:ValidationAttribute
    {
        private readonly string allowedDomain;

        public ValidEmailDomainAttribute(string allowedDomain)
        {
            this.allowedDomain = allowedDomain;
        }

        public override bool IsValid(object? value)
        {
            string[] str = value.ToString().Split('@');
            return str[1]==allowedDomain;
        }
    }
}
