using CrimeReportingSystem.Model;
using CrimeReportingSystem.Utility;
using System.Data.SqlClient;

namespace CrimeReportingSystem.Repositories
{
    internal class LawEnforcementAgencyRepository
    {

        SqlConnection connect = null;
        SqlCommand cmd = null;

        public LawEnforcementAgencyRepository()
        {
            connect = new SqlConnection(DBConnectUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public void AddLawEnforcementAgency(LawEnforcementAgencies agency)
        {

            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "INSERT INTO Agencies ( AgencyName, Jurisdication, Phone, OfficerID) VALUES (@AgencyName, @Jurisdiction, @Phone, @OfficerID)";

            cmd.Parameters.AddWithValue("@AgencyName", agency.AgencyName);
            cmd.Parameters.AddWithValue("@Jurisdication", agency.Jurisdiction);
            cmd.Parameters.AddWithValue("@Phone", agency.Phonenumber);
            cmd.Parameters.AddWithValue("@OfficerID", agency.Officer.OfficerID);
            cmd.ExecuteNonQuery();

            connect.Close();
            cmd.Parameters.Clear();

        }

        public List<LawEnforcementAgencies> DisplayLawEnforcementAgencies()
        {
            List<LawEnforcementAgencies> agencies = new List<LawEnforcementAgencies>();

            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM Agencies";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                LawEnforcementAgencies agency = new LawEnforcementAgencies();
                agency.AgencyID = (int)reader["AgencyID"];
                agency.AgencyName = reader["AgencyName"].ToString();
                agency.Jurisdiction = reader["Jurisdication"].ToString();
                agency.Phonenumber = reader["Phone"].ToString();
                agency.Officer = new Officers();
                agency.Officer.OfficerID = (int)reader["OfficerID"];
                agencies.Add(agency);
            }
            connect.Close();
            return agencies;

        }

        public void RemoveLawEnforcemtAgency(int Agencyid)
        {
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "Delete from Agencies where AgencyID=@Agencyid";
            cmd.Parameters.AddWithValue("@Agencyid", Agencyid);
            cmd.ExecuteNonQuery();
            connect.Close();
            cmd.Parameters.Clear();

        }

    }
}
