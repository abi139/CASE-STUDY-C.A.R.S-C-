namespace CrimeReportingSystem.Model
{
    public class Suspects
    {


        private int suspectID;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string gender;
        private string address;
        private string phonenumber;

        public int SuspectID
        {
            get { return suspectID; }
            set { suspectID = value; }
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
        public Suspects()
        {

        }


        public Suspects(int suspectID, string firstName, string lastName, DateTime dateOfBirth, string gender, string address, string phonenumber)
        {
            this.suspectID = suspectID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.address = address;
            this.phonenumber = phonenumber;
        }
    }
}



