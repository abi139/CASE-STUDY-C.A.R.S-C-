using System.Text.RegularExpressions;

namespace CrimeReportingSystem.Exceptions
{
    internal class DataValidationExceptions : Exception
    {
        public DataValidationExceptions(string message) : base(message)
        {
        }

        //phone number validation
        public static bool IsValidPhoneNumber(string phoneNumber)
        {

            string pattern = @"^\d{10}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(phoneNumber);
        }
    }
}
