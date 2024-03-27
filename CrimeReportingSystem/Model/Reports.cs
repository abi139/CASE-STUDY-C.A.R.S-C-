namespace CrimeReportingSystem.Model
{
    public class Reports
    {


        private int reportID;
        Incidents incident; // Foreign key linking to Incidents
        Officers reportingOfficer; // Foreign key linking to Officers
        private DateTime reportDate;
        private string reportDetails;
        private string status;

        public int ReportID
        {
            get { return reportID; }
            set { reportID = value; }
        }

        public Incidents Incident
        {
            get { return incident; }
            set { incident = value; }
        }

        public Officers ReportingOfficer
        {
            get { return reportingOfficer; }
            set { reportingOfficer = value; }
        }

        public DateTime ReportDate
        {
            get { return reportDate; }
            set { reportDate = value; }
        }

        public string ReportDetails
        {
            get { return reportDetails; }
            set { reportDetails = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public Reports()
        {

        }
        public Reports(int reportID, Incidents incident, Officers reportingOfficer, DateTime reportDate, string reportDetails, string status)
        {
            this.reportID = reportID;
            this.incident = incident;
            this.reportingOfficer = reportingOfficer;
            this.reportDate = reportDate;
            this.reportDetails = reportDetails;
            this.status = status;
        }
        public override string ToString()
        {
            return $"{reportID}{incident}{reportingOfficer}{reportDate}{reportDetails}{status}";

        }
    }
}

