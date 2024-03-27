using CrimeReportingSystem.Model;
using CrimeReportingSystem.Utility;
using System.Data;
using System.Data.SqlClient;

namespace CrimeReportingSystem.Repositories
{
    public class CrimeAnalysisService : ICrimeAnalysisService
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public CrimeAnalysisService()
        {
            connect = new SqlConnection(DBConnectUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        public bool CreateIncident(Incidents incidents)
        {
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "insert into Incidents values(@incidentType,@incidentDate,@locationn,@descriptionn,@statuss,@victimID,@suspectID)";

            cmd.Parameters.AddWithValue("@incidentType", incidents.IncidentType);
            cmd.Parameters.AddWithValue("@incidentDate", incidents.IncidentDate);
            cmd.Parameters.AddWithValue("@locationn", incidents.Location);
            cmd.Parameters.AddWithValue("@descriptionn", incidents.Description);
            cmd.Parameters.AddWithValue("@statuss", incidents.Status);
            cmd.Parameters.AddWithValue("@victimID", incidents.VictimID);
            cmd.Parameters.AddWithValue("@SuspectID", incidents.SuspectID);

            cmd.ExecuteNonQuery();
            connect.Close();
            return true;
        }

        public bool UpdateIncidentStatus(string newStatus, int incidentID)
        {
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "UPDATE Incidents SET Status = @NewStatus WHERE IncidentID = @IncidentID";
            cmd.Parameters.AddWithValue("@NewStatus", newStatus);
            cmd.Parameters.AddWithValue("@IncidentID", incidentID);

            cmd.ExecuteNonQuery();

            connect.Close();
            return true;
        }

        public List<Incidents> GetIncidentsInDateRange(DateTime startDate, DateTime endDate)
        {
            List<Incidents> incidentList = new List<Incidents>();

            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM Incidents WHERE IncidentDate BETWEEN @StartDate AND @EndDate";
            cmd.Parameters.AddWithValue("@StartDate", startDate);
            cmd.Parameters.AddWithValue("@EndDate", endDate);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Incidents incident = new Incidents();
                incident.IncidentID = (int)reader["IncidentID"];
                incident.IncidentType = reader["IncdientType"].ToString();
                incident.IncidentDate = (DateTime)reader["IncidentDate"];
                incidentList.Add(incident);
            }
            cmd.Parameters.Clear();
            connect.Close();
            return incidentList;

        }


        public List<Incidents> SearchIncidents(object criteria)
        {
            List<Incidents> incidentList = new List<Incidents>();

            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = "SELECT * FROM Incidents WHERE IncidentType = @Incidenttype";
                cmd.Parameters.AddWithValue("@Incidenttype", criteria);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Incidents incident = new Incidents();
                    incident.IncidentID = (int)reader["IncidentID"];
                    incident.IncidentType = reader["IncidentType"].ToString();
                    incident.IncidentDate = (DateTime)reader["IncidentDate"];
                    incident.Description = reader["Descriptionn"].ToString();
                    incident.Status = reader["statuss"].ToString();
                    incident.VictimID = (int)reader["VictimID"];
                    incident.SuspectID = (int)reader["SuspectID"];
                    incidentList.Add(incident);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while searching incidents: {ex.Message}");
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }

            return incidentList;
        }
        public Reports GenerateIncidentReport(Incidents incident)
        {
            Reports report = new Reports();
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM Reports WHERE IncidentID = @incidentid";
            cmd.Parameters.AddWithValue("@incidentid", incident.IncidentID);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                report.ReportID = (int)reader["ReportID"];
                report.Incident = new Incidents();
                report.Incident.IncidentID = (int)reader["IncidentID"];
                report.ReportingOfficer.OfficerID = (int)reader["ReportingOfficerID"];
                report.ReportDate = (DateTime)reader["ReportDate"];
                report.ReportDetails = reader["ReportDetails"].ToString();
                report.Status = reader["Report_status"].ToString();
            }
            connect.Close();

            return report;
        }

        public Cases CreateCase(string caseDescription, Incidents incidents)
        {
            Cases newCase = null;
            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = "INSERT INTO Cases (CaseDescription, IncidentID) VALUES (@CaseDescription, @IncidentID); SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("@CaseDescription", caseDescription);
                cmd.Parameters.AddWithValue("@IncidentID", incidents.IncidentID);

                int caseId = Convert.ToInt32(cmd.ExecuteScalar());

                newCase = new Cases(caseId, caseDescription, incidents);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while creating case: {ex.Message}");
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
                cmd.Parameters.Clear();
            }
            return newCase;
        }



        public Cases GetCaseDetails(int CaseId)
        {
            cmd.Parameters.Clear();
            Cases caseDetails = null;
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT c.*, i.* FROM Cases c INNER JOIN Incidents i ON c.IncidentID = i.IncidentID  WHERE c.CaseId = @CaseId";

            cmd.Parameters.AddWithValue("@CaseId", CaseId);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                caseDetails = new Cases();
                caseDetails.CaseId = Convert.ToInt32(reader["CaseID"]);
                caseDetails.CaseDescription = reader["CaseDescription"].ToString();
                caseDetails.Incident = new Incidents();
                caseDetails.Incident.IncidentID = (int)(reader["IncidentID"]);
                caseDetails.Incident.IncidentType = reader["IncidentType"].ToString();
                caseDetails.Incident.IncidentDate = Convert.ToDateTime(reader["IncidentDate"]);
                caseDetails.Incident.Location = reader["Locationn"].ToString();
                caseDetails.Incident.Description = reader["Descriptionn"].ToString();
                caseDetails.Incident.Status = reader["statuss"].ToString();
                caseDetails.Incident.VictimID = (int)reader["VictimID"];
                caseDetails.Incident.SuspectID = (int)reader["SuspectID"];

            }

            reader.Close();
            connect.Close();


            return caseDetails;
        }

        public bool UpdateCaseDetails(Cases updatedCase)
        {
            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = "UPDATE Cases SET CaseDescription = @CaseDescription WHERE CaseId = @CaseId";
                cmd.Parameters.AddWithValue("@CaseDescription", updatedCase.CaseDescription);
                cmd.Parameters.AddWithValue("@CaseId", updatedCase.CaseId);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating case details: {ex.Message}");
                return false;
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        public List<Cases> GetAllCases()
        {
            List<Cases> allCases = new List<Cases>();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM Cases";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Cases caseDetails = new Cases();
                caseDetails.CaseId = Convert.ToInt32(reader["CaseID"]);
                caseDetails.CaseDescription = reader["CaseDescription"].ToString();
                allCases.Add(caseDetails);
            }

            reader.Close();
            return allCases;
        }
    }






}

