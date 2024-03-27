using CrimeReportingSystem.Model;
using CrimeReportingSystem.Utility;
using System.Data.SqlClient;


namespace CrimeReportingSystem.Repositories
{
    internal class IncidentRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public IncidentRepository()
        {
            connect = new SqlConnection(DBConnectUtil.GetConnectionString());
            cmd = new SqlCommand();
        }



        public List<Incidents> DisplayAllIncidents()
        {
            List<Incidents> incidentslist = new List<Incidents>();
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "select * from Incidents";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Incidents incident = new Incidents();
                incident.IncidentID = reader["IncidentID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IncidentID"]);
                incident.IncidentType = reader["IncidentType"].ToString();
                incident.IncidentDate = reader["IncidentDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["IncidentDate"]);
                incident.Location = reader["Locationn"].ToString();
                incident.Description = reader["Descriptionn"].ToString();
                incident.Status = reader["Statuss"].ToString();
                incident.VictimID = reader["VictimID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["VictimID"]);
                incident.SuspectID = reader["SuspectID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SuspectID"]);
                incidentslist.Add(incident);
            }
            reader.Close();
            connect.Close();
            return incidentslist;
        }
        public Incidents GetIncidentsbyID(int incidentid)
        {
            Incidents incident = new Incidents();
            using (SqlConnection connect = new SqlConnection(DBConnectUtil.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    connect.Open();
                    cmd.Connection = connect;
                    cmd.CommandText = "Select * from Incidents where IncidentID=@Incidentid";
                    cmd.Parameters.AddWithValue("@incidentid", incidentid);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        incident.IncidentID = (int)reader["IncidentID"];
                        incident.IncidentType = reader["IncidentType"].ToString();
                        incident.IncidentDate = (DateTime)reader["IncidentDate"];
                        incident.Location = reader["Locationn"].ToString();
                        incident.Description = reader["Descriptionn"].ToString();
                        incident.Status = reader["Statuss"].ToString();
                        incident.VictimID = (int)reader["VictimID"];
                        incident.SuspectID = (int)reader["SuspectID"];
                    }

                    reader.Close();
                }
            }
            return incident;
        }

        public void RemoveIncident(int incidentid)
        {
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "DELETE FROM Incidents WHERE IncidentID = @incidentid";
            cmd.Parameters.AddWithValue("@incidentid", incidentid);
            int rowsaffected = cmd.ExecuteNonQuery();
            connect.Close();
        }



    }

}
