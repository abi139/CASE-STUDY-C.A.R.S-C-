namespace CrimeReportingSystem.Model
{
    public class Victims
    {
        private int victimID;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string gender;
        private string address;
        private string phonenumber;

        public int VictimID
        {
            get { return victimID; }
            set { victimID = value; }
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

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Phonenumber
        {
            get { return phonenumber; }
            set { phonenumber = value; }
        }


        public Victims()
        {

        }

        public Victims(int victimID, string firstName, string lastName, DateTime dateOfBirth, string gender, string address, string phonenumber)
        {
            this.victimID = victimID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.address = address;
            this.phonenumber = phonenumber;
        }

        public override string ToString()
        {
            return $"{VictimID}\t{FirstName}\t{LastName}\t{DateOfBirth}\t {Gender}\t{Address}\t {Phonenumber}";
        }

    }
}
