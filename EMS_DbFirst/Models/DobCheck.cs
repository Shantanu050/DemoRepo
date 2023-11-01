using System.ComponentModel.DataAnnotations;
namespace EMS_DbFirst.Models
{
    public class DobCheck:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime birthDate=Convert.ToDateTime(value);
            int birthYear=birthDate.Year;
            int  currentYear=DateTime.Now.Year;
            if(currentYear-birthYear>=25)
            return true;
            else
            return false;
        }
    }
}