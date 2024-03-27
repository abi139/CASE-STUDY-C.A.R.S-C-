using CrimeReportingSystem.Model;
using CrimeReportingSystem.Utility;
using System.Data.SqlClient;

namespace CrimeReportingSystem.Repositories
{
    internal class VictimRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public VictimRepository()
        {
            connect = new SqlConnection(DBConnectUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public void AddVictim(Victims victims)
        {

            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = @"INSERT INTO Victims (V_FirstName, V_LastName, V_DateOfBirth, V_Gender, V_Address, V_Phone) 
                                VALUES ( @V_FirstName, @V_LastName, @V_DateOfBirth, @V_Gender, @V_Address, @V_Phone)";

            cmd.Parameters.AddWithValue("@V_FirstName", victims.FirstName);
            cmd.Parameters.AddWithValue("@V_LastName", victims.LastName);
            cmd.Parameters.AddWithValue("@V_DateOfBirth", victims.DateOfBirth);
            cmd.Parameters.AddWithValue("@V_Gender", victims.Gender);
            cmd.Parameters.AddWithValue("@V_Address", victims.Address);
            cmd.Parameters.AddWithValue("@V_Phone", victims.Phonenumber);
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public List<Victims> DisplayVictimsDetials()
        {
            List<Victims> victimsList = new List<Victims>();


            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM Victims";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Victims victim = new Victims();
                victim.VictimID = (int)reader["VictimID"];
                victim.FirstName = reader["V_FirstName"].ToString();
                victim.LastName = reader["V_LastName"].ToString();
                victim.DateOfBirth = (DateTime)reader["V_DateOfBirth"];
                victim.Gender = reader["V_Gender"].ToString();
                victim.Address = reader["V_Address"].ToString();
                victim.Phonenumber = reader["V_Phone"].ToString();

                victimsList.Add(victim);
            }

            reader.Close();
            connect.Close();
            return victimsList;
        }
        public void RemoveVictim(int victimid)
        {

            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "DELETE FROM Victims WHERE VictimID = @VictimID";
            cmd.Parameters.AddWithValue("@VictimID", victimid);
            cmd.ExecuteNonQuery();

            connect.Close();
        }

    }
}
