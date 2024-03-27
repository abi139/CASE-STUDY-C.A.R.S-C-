using CrimeReportingSystem.Model;
using CrimeReportingSystem.Utility;
using System.Data.SqlClient;

namespace CrimeReportingSystem.Repositories
{
    internal class SuspectRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public SuspectRepository()
        {
            connect = new SqlConnection(DBConnectUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public void AddSuspect(Suspects suspect)
        {

            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "INSERT INTO Suspects VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @Address, @PhoneNumber)";

            cmd.Parameters.AddWithValue("@FirstName", suspect.FirstName);
            cmd.Parameters.AddWithValue("@LastName", suspect.LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", suspect.DateOfBirth);
            cmd.Parameters.AddWithValue("@Gender", suspect.Gender);
            cmd.Parameters.AddWithValue("@Address", suspect.Address);
            cmd.Parameters.AddWithValue("@PhoneNumber", suspect.Phonenumber);
            cmd.ExecuteNonQuery();

            connect.Close();
        }


        public List<Suspects> DisplaySuspectInfo()
        {
            List<Suspects> suspectsList = new List<Suspects>();

            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM Suspects";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Suspects suspect = new Suspects
                {
                    SuspectID = (int)reader["SuspectID"],
                    FirstName = reader["S_FirstName"].ToString(),
                    LastName = reader["S_LastName"].ToString(),
                    DateOfBirth = (DateTime)reader["S_DateOfBirth"],
                    Gender = reader["S_Gender"].ToString(),
                    Address = reader["S_Addresss"].ToString(),
                    Phonenumber = reader["S_Phone"].ToString()
                };
                suspectsList.Add(suspect);
            }

            connect.Close();
            return suspectsList;
        }

        public void RemoveSuspect(int suspectID)
        {

            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "DELETE FROM Suspects WHERE SuspectID = @SuspectID";
            cmd.Parameters.AddWithValue("@SuspectID", suspectID);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            connect.Close();

        }

        public Suspects getSuspectsbyID(int suspectID)
        {
            Suspects suspect = null;
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "select * from Suspects where SuspectID=@suspectID";
            cmd.Parameters.AddWithValue("@SuspectID", suspectID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                suspect = new Suspects
                {
                    SuspectID = (int)reader["SuspectID"],
                    FirstName = reader["S_FirstName"].ToString(),
                    LastName = reader["S_LastName"].ToString(),
                    DateOfBirth = (DateTime)reader["S_DateOfBirth"],
                    Gender = reader["S_Gender"].ToString()

                };
            }
            connect.Close();
            return suspect;
        }
    }
}


