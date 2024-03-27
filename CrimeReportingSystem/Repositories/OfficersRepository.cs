using CrimeReportingSystem.Model;
using CrimeReportingSystem.Utility;
using System.Data.SqlClient;

namespace CrimeReportingSystem.Repositories
{
    internal class OfficersRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public OfficersRepository()
        {
            connect = new SqlConnection(DBConnectUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        public void AddOfficers(Officers officers)
        {

            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "INSERT INTO Officers ( Off_FirstName, Off_LastName, BadgeNumber, Ranks, Off_Phone, AgencyID) VALUES (@Off_FirstName, @Off_LastName, @BadgeNumber, @Ranks, @Off_Phone, @AgencyID)";

            cmd.Parameters.AddWithValue("@Off_FirstName", officers.FirstName);
            cmd.Parameters.AddWithValue("@Off_LastName", officers.LastName);
            cmd.Parameters.AddWithValue("@BadgeNumber", officers.BadgeNumber);
            cmd.Parameters.AddWithValue("@Ranks", officers.Rank);
            cmd.Parameters.AddWithValue("@Off_Phone", officers.Phone);
            cmd.Parameters.AddWithValue("@AgencyID", officers.AgencyID);
            cmd.ExecuteNonQuery();
            connect.Close();
            cmd.Parameters.Clear();

        }

        public void UpdateOfficers(Officers officers)
        {

            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "UPDATE Officers SET Off_FirstName = @Off_FirstName, Off_LastName = @Off_LastName, BadgeNumber = @BadgeNumber, Ranks = @Ranks, Off_Phone = @Off_Phone, AgencyID = @AgencyID WHERE OfficerID = @OfficerID";
            cmd.Parameters.AddWithValue("@OfficerID", officers.OfficerID);
            cmd.Parameters.AddWithValue("@Off_FirstName", officers.FirstName);
            cmd.Parameters.AddWithValue("@Off_LastName", officers.LastName);
            cmd.Parameters.AddWithValue("@BadgeNumber", officers.BadgeNumber);
            cmd.Parameters.AddWithValue("@Ranks", officers.Rank);
            cmd.Parameters.AddWithValue("@Off_Phone", officers.Phone);
            cmd.Parameters.AddWithValue("@AgencyID", officers.AgencyID);
            cmd.ExecuteNonQuery();
            connect.Close();
            cmd.Parameters.Clear();
        }


        public void DeleteOfficers(int officerID)
        {

            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "DELETE FROM Officers WHERE OfficerID = @OfficerID";
            cmd.Parameters.AddWithValue("@OfficerID", officerID);
            cmd.ExecuteNonQuery();

            connect.Close();
        }

        public List<Officers> DisplayOfficersInfo()
        {
            List<Officers> officersList = new List<Officers>();

            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM Officers";
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Officers officer = new Officers();
                officer.OfficerID = (int)reader["OfficerID"];
                officer.FirstName = reader["Off_FirstName"].ToString();
                officer.LastName = reader["Off_LastName"].ToString();
                officer.BadgeNumber = reader["BadgeNumber"].ToString();
                officer.Rank = reader["Ranks"].ToString();
                officer.Phone = reader["Off_Phone"].ToString();
                officer.AgencyID = (int)reader["AgencyID"];

                officersList.Add(officer);
            }
            connect.Close();

            return officersList;
        }

    }
}
