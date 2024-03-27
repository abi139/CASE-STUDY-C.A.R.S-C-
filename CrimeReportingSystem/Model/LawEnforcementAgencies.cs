namespace CrimeReportingSystem.Model
{
    public class LawEnforcementAgencies
    {

        int agencyID;
        string agencyName;
        string jurisdiction;
        string phonenumber;
        Officers officer;


        public int AgencyID
        {
            get { return agencyID; }
            set { agencyID = value; }
        }

        public string AgencyName
        {
            get { return agencyName; }
            set { agencyName = value; }
        }

        public string Jurisdiction
        {
            get { return jurisdiction; }
            set { jurisdiction = value; }
        }

        public string Phonenumber
        {
            get { return phonenumber; }
            set { phonenumber = value; }
        }

        public Officers Officer
        {
            get { return officer; }
            set { officer = value; }
        }
        public LawEnforcementAgencies()
        {

        }

        public LawEnforcementAgencies(int agencyID, string agencyName, string jurisdiction, Officers officer, string phonenumber)
        {
            this.agencyID = agencyID;
            this.agencyName = agencyName;
            this.jurisdiction = jurisdiction;
            this.officer = officer;
            this.phonenumber = phonenumber;

        }



    }
}



