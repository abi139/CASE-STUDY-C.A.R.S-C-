using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeReportingSystem.Exceptions
{
    public class InvalidStatusUpdateException:Exception
    {
        public InvalidStatusUpdateException(string message):base(message) 
        { 
        }

        public static void InvalidIncidentStatus(string status)
        {
            bool value = false;

            if (status == "Open" || status == "Closed" || status == "Under Investigation")
            {
                value = true;
            }
            else
            {
                throw new IncidentIDNotFoundException("Invalid status.....");
            }
        }
    }
}

