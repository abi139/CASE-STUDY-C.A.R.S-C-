namespace CrimeReportingSystem.Model
{
    public class Incidents
    {
        int incidentID;
        string incidenttype;
        DateTime incidentDate;
        string location;
        string description;
        string status;
        int victimID;
        int suspectID;

        public int IncidentID
        {
            get { return incidentID; }
            set { incidentID = value; }
        }

        public string IncidentType
        {
            get { return incidenttype; }
            set { incidenttype = value; }
        }

        public DateTime IncidentDate
        {
            get { return incidentDate; }
            set { incidentDate = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public int VictimID
        {
            get { return victimID; }
            set { victimID = value; }
        }

        public int SuspectID
        {
            get { return suspectID; }
            set { suspectID = value; }
        }
        public Incidents()
        {

        }

        public Incidents(int incidentID, string incidentType, DateTime incidentDate, string location, string description, string status, int victimID, int suspectID)
        {
            this.incidentID = incidentID;
            this.incidenttype = incidentType;
            this.incidentDate = incidentDate;
            this.location = location;
            this.description = description;
            this.status = status;
            this.victimID = victimID;
            this.suspectID = suspectID;
        }
    }
}
