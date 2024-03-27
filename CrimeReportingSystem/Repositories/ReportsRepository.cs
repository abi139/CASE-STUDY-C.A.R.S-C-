using CrimeReportingSystem.Model;
using CrimeReportingSystem.Utility;
using System.Data.SqlClient;

namespace CrimeReportingSystem.Repositories
{
    internal class ReportsRepository
    {

        SqlConnection connect = null;
        SqlCommand cmd = null;

        public ReportsRepository()
        {
            connect = new SqlConnection(DBConnectUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        public void UpdateReportStatus(int reportID, string newStatus)
        {

            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "UPDATE Reports SET Report_status = @NewStatus WHERE ReportID = @ReportID";
            cmd.Parameters.AddWithValue("@NewStatus", newStatus);
            cmd.Parameters.AddWithValue("@ReportID", reportID);

            cmd.ExecuteNonQuery();
            connect.Close();
        }



        public void AddNewReport(Reports report)
        {
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "INSERT INTO Reports (IncidentID, ReportingOfficer, ReportDate, ReportDetails, Report_status) " +
                              "VALUES ( @IncidentID, @ReportingOfficer, @ReportDate, @ReportDetails, @ReportStatus)";
            // cmd.Parameters.AddWithValue("@ReportID", report.ReportID);
            cmd.Parameters.AddWithValue("@IncidentID", report.Incident);
            cmd.Parameters.AddWithValue("@ReportingOfficer", report.ReportingOfficer);
            cmd.Parameters.AddWithValue("@ReportDate", report.ReportDate);
            cmd.Parameters.AddWithValue("@ReportDetails", report.ReportDetails);
            cmd.Parameters.AddWithValue("@ReportStatus", report.Status);

            cmd.ExecuteNonQuery();
            connect.Close();
        }



        public List<Reports> DisplayReportInfo()
        {
            List<Reports> reportList = new List<Reports>();

            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM Reports";

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Reports report = new Reports();
                report.ReportID = (int)reader["ReportID"];
                report.Incident = new Incidents();
                report.Incident.IncidentID = (int)reader["IncidentID"];
                report.ReportingOfficer = new Officers();
                report.ReportingOfficer.OfficerID = (int)reader["ReportingOfficer"];
                report.ReportDate = (DateTime)reader["ReportDate"];
                report.ReportDetails = reader["ReportDetails"].ToString();
                report.Status = reader["Report_status"].ToString();
                reportList.Add(report);
            }


            connect.Close();

            return reportList;
        }

        //        


    }
}
