using CrimeReportingSystem.Model;
using CrimeReportingSystem.Repositories;

namespace CrimeReportingSystem.Service
{
    internal class ReportsService
    {
        ReportsRepository reportsRepository;

        public ReportsService()
        {
            reportsRepository = new ReportsRepository();
        }

        public void AddNewReport(Reports report)
        {
            try
            {
                reportsRepository.AddNewReport(report);
                Console.WriteLine("New report added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while adding new report: {ex.Message}");

            }
        }

        public void UpdateReportStatus(int reportID, string newStatus)
        {
            try
            {
                reportsRepository.UpdateReportStatus(reportID, newStatus);
                Console.WriteLine($"Report with ID '{reportID}' status updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating report status: {ex.Message}");

            }
        }

        public List<Reports> DisplayReportInfo()
        {
            try
            {
                List<Reports> reportList = reportsRepository.DisplayReportInfo();
                if (reportList.Count == 0)
                {
                    Console.WriteLine("No reports found.");
                }
                else
                {
                    foreach (var report in reportList)
                    {
                        Console.WriteLine($"Report ID: {report.ReportID}");
                        Console.WriteLine($"Incident Type: {report.Incident.IncidentType}");
                        Console.WriteLine($"Reporting Officer: {report.ReportingOfficer.FirstName}");
                        Console.WriteLine($"Report Date: {report.ReportDate}");
                        Console.WriteLine($"Report Details: {report.ReportDetails}");
                        Console.WriteLine($"Status: {report.Status}");
                        Console.WriteLine();
                    }
                }
                return reportList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while displaying reports: {ex.Message}");
                throw;
            }
        }
        public void ReportsMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1.Adding New Report:");
                Console.WriteLine("2.Updating report status:");
                Console.WriteLine("3.Displaying all reports:");
                Console.WriteLine("4.Exit");
                Console.WriteLine("Enter your choice");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {

                    case 1:

                        Console.WriteLine("Adding New Report:");
                        Console.Write("Enter Incident ID: ");
                        int incidentID = int.Parse(Console.ReadLine());
                        Console.Write("Enter Reporting Officer ID:  ");
                        int officerID = int.Parse(Console.ReadLine());
                        Console.Write("Enter Report Date: ");
                        DateTime reportDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter Report Details: ");
                        string reportDetails = Console.ReadLine();
                        Console.Write("Enter Report Status: ");
                        string reportStatus = Console.ReadLine();
                        Incidents incidents = new Incidents { IncidentID = incidentID };
                        Officers officers = new Officers { OfficerID = officerID };
                        Reports newReport = new Reports(0, incidents, officers, reportDate, reportDetails, reportStatus);

                        break;
                    case 2:
                        Console.WriteLine("Updating Report Status:");
                        Console.Write("Enter Report ID to update status: ");
                        int updateReportID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter New Status: ");
                        string newStatus = Console.ReadLine();
                        UpdateReportStatus(updateReportID, newStatus);
                        break;

                    case 3:
                        Console.WriteLine("Displaying All Report Info:");
                        DisplayReportInfo();
                        break;

                    case 4:
                        Console.WriteLine("Exiting Reports Service.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }

            } while (choice != 4);
        }
    }
}



