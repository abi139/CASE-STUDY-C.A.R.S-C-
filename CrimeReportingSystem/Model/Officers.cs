namespace CrimeReportingSystem.Model
{
    public class Officers
    {

        private int officerID;
        private string firstName;
        private string lastName;
        private string badgeNumber;
        private string rank;
        private string phone;
        private int agencyID;

        public int OfficerID
        {
            get { return officerID; }
            set { officerID = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string BadgeNumber
        {
            get { return badgeNumber; }
            set { badgeNumber = value; }
        }

        public string Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public int AgencyID
        {
            get { return agencyID; }
            set { agencyID = value; }
        }
        public Officers()
        {

        }
        public Officers(int officerID, string firstName, string lastName, string badgeNumber, string rank, string phone, int agencyID)
        {
            this.officerID = officerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.badgeNumber = badgeNumber;
            this.rank = rank;
            this.phone = phone;
            this.agencyID = agencyID;
        }
    }
}


