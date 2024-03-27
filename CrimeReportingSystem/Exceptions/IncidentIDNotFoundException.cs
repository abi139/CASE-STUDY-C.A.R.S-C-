using CrimeReportingSystem.Model;

namespace CrimeReportingSystem.Exceptions
{
    internal class IncidentIDNotFoundException : Exception
    {
        public IncidentIDNotFoundException(string message) : base(message)
        {

        }
        public static bool IncidentIDNotFound(int value)
        {
            List<Incidents> incidents = new List<Incidents>();

            foreach (Incidents item in incidents)
            {
                if (item.IncidentID == value)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

