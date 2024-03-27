using CrimeReportingSystem.Model;
using CrimeReportingSystem.Utility;
using System.Data;
using System.Data.SqlClient;

namespace CrimeReportingSystem.Repositories
{
    internal class CaseRepository
    {

        SqlConnection connect = null;
        SqlCommand cmd = null;

        public CaseRepository()
        {
            connect = new SqlConnection(DBConnectUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        public Cases AddCase(string caseDescription, Incidents incidents)
        {
            Cases newCase = null;
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "INSERT INTO Cases (CaseDescription,IncidentID) VALUES (@CaseDescription,@IncidentID); SELECT SCOPE_IDENTITY();";

            cmd.Parameters.AddWithValue("@CaseDescription", caseDescription);
            cmd.Parameters.AddWithValue("@IncidentID", incidents.IncidentID);
            cmd.Parameters.Clear();
            cmd.ExecuteNonQuery();
            int caseId = Convert.ToInt32(cmd.ExecuteScalar());
            newCase = new Cases(caseId, caseDescription, incidents);
            cmd.Parameters.Clear();
            if (connect.State != ConnectionState.Closed)
            {
                connect.Close();
            }

            return newCase;
        }



        public bool updateCaseDetails(Cases updatedCase)
        {
            bool success = false;

            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "UPDATE Cases SET CaseDescription = @CaseDescription WHERE CaseId = @CaseId";

            cmd.Parameters.AddWithValue("@CaseDescription", updatedCase.CaseDescription);
            cmd.Parameters.AddWithValue("@CaseId", updatedCase.CaseId);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                success = true;

                return success;
            }
            connect.Close();
            return success;
        }

        public List<Cases> getAllCases()
        {
            List<Cases> allCases = new List<Cases>();

            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM Cases";


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cases caseDetails = new Cases();
                caseDetails.CaseId = Convert.ToInt32(reader["CaseID"]);
                caseDetails.CaseDescription = reader["CaseDescription"].ToString();
                caseDetails.Incident = new Incidents();
                caseDetails.Incident.IncidentID = (int)reader["IncidentID"];
                allCases.Add(caseDetails);
            }

            reader.Close();
            connect.Close();
            return allCases;
        }
    }





}



