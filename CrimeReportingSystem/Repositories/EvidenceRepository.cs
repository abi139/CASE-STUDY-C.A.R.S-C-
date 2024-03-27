using CrimeReportingSystem.Model;
using CrimeReportingSystem.Utility;
using System.Data.SqlClient;

namespace CrimeReportingSystem.Repositories
{
    internal class EvidenceRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public EvidenceRepository()
        {
            connect = new SqlConnection(DBConnectUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        public void AddEvidence(Evidence evidence)
        {

            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "INSERT INTO Evidence VALUES ( @Description, @LocationFound, @IncidentID)";
            cmd.Parameters.AddWithValue("@Description", evidence.Description);
            cmd.Parameters.AddWithValue("@LocationFound", evidence.LocationFound);
            cmd.Parameters.AddWithValue("@IncidentID", evidence.IncidentID);

            cmd.ExecuteNonQuery();

            connect.Close();
            cmd.Parameters.Clear();
        }

        public List<Evidence> GetEvidenceByIncidentID(int incidentID)
        {
            List<Evidence> evidenceList = new List<Evidence>();
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM Evidence WHERE IncidentID = @IncidentID";
            cmd.Parameters.AddWithValue("@IncidentID", incidentID);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Evidence evidence = new Evidence();
                evidence.EvidenceID = (int)reader["EvidenceID"];
                evidence.Description = reader["Descriptionn"].ToString();
                evidence.LocationFound = reader["Location_Found"].ToString();
                evidence.IncidentID = (int)reader["IncidentID"];

                evidenceList.Add(evidence);
            }
            connect.Close();
            return evidenceList;
            cmd.Parameters.Clear();
        }

        public void UpdateEvidence(Evidence evidence)
        {
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "UPDATE Evidence SET Descriptionn = @Description, Location_Found = @LocationFound WHERE EvidenceID = @EvidenceID";
            cmd.Parameters.AddWithValue("@Description", evidence.Description);
            cmd.Parameters.AddWithValue("@LocationFound", evidence.LocationFound);
            cmd.Parameters.AddWithValue("@EvidenceID", evidence.EvidenceID);

            cmd.ExecuteNonQuery();

            connect.Close();
            cmd.Parameters.Clear();
        }


        public List<Evidence> DisplayAllEvidence()
        {
            List<Evidence> allEvidence = new List<Evidence>();
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM Evidence";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Evidence evidence = new Evidence()
                {
                    EvidenceID = Convert.ToInt32(reader["EvidenceID"]),
                    Description = reader["Descriptionn"].ToString(),
                    LocationFound = reader["Location_Found"].ToString(),
                    IncidentID = Convert.ToInt32(reader["IncidentID"])
                };

                allEvidence.Add(evidence);
            }
            reader.Close();
            connect.Close();
            return allEvidence;
            cmd.Parameters.Clear();
        }
    }




}

