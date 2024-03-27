using CrimeReportingSystem.Model;

namespace CrimeReportingSystem.Exceptions
{
    internal class CaseNotFoundException : Exception
    {
        public CaseNotFoundException(string message) : base(message)
        {

        }
        public static bool CaseIDNotFound(int value)
        {
            List<Cases> cases = new List<Cases>();

            foreach (Cases item in cases)
            {
                if (item.CaseId == value)

                { return true; }
            }

            return false;
        }
    }
}

