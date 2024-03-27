using CrimeReportingSystem.Exceptions;
using CrimeReportingSystem.Model;
using CrimeReportingSystem.Repositories;

namespace CrimeReportingSystem.Service
{
    public  class CrimeaAnalysisManagementService
    {
        ICrimeAnalysisService crimeAnalysisService;

        public CrimeaAnalysisManagementService()
        {

            crimeAnalysisService = new CrimeAnalysisService();
        }

        public void CreateIncident(Incidents incidents)
        {
            try
            {
                crimeAnalysisService.CreateIncident(incidents);
                Console.WriteLine("Incident created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while creating incident: {ex.Message}");
            }
        }

        public void UpdateIncidentStatus(string newStatus, int incidentID)
        {
            try
            {
                crimeAnalysisService.UpdateIncidentStatus(newStatus, incidentID);
                Console.WriteLine("Incident status updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating incident status: {ex.Message}");
            }
        }

        public void GetIncidentsInDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<Incidents> incidents = crimeAnalysisService.GetIncidentsInDateRange(startDate, endDate);
                if (incidents.Count == 0)
                {
                    Console.WriteLine("No incidents found in the specified date range.");
                }
                else
                {
                    Console.WriteLine("Incidents found in the specified date range:");
                    foreach (var incident in incidents)
                    {
                        Console.WriteLine($"Incident ID: {incident.IncidentID}, Type: {incident.IncidentType}, Date: {incident.IncidentDate}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while fetching incidents: {ex.Message}");
            }
        }

        public void SearchIncidents(object criteria)
        {
            try
            {
                List<Incidents> incidents = crimeAnalysisService.SearchIncidents(criteria);
                if (incidents.Count == 0)
                {
                    Console.WriteLine("No incidents found matching the search criteria.");
                }
                else
                {
                    Console.WriteLine("Incidents found matching the search criteria:");
                    foreach (var incident in incidents)
                    {
                        Console.WriteLine($"Incident ID: {incident.IncidentID}, Type: {incident.IncidentType}, Date: {incident.IncidentDate}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while searching incidents: {ex.Message}");
            }
        }

        public void GenerateIncidentReport(Incidents incident)
        {
            try
            {
                Reports report = crimeAnalysisService.GenerateIncidentReport(incident);
                if (report != null)
                {
                    Console.WriteLine("Incident report generated successfully.");
                    Console.WriteLine($"Report ID: {report.ReportID}, Report Date: {report.ReportDate}, Status: {report.Status}");
                    Console.WriteLine("Incident Details:");
                    Console.WriteLine($"Incident ID: {report.Incident.IncidentID}, Type: {report.Incident.IncidentType}, Date: {report.Incident.IncidentDate}");
                }
                else
                {
                    Console.WriteLine("Failed to generate incident report.");
                }
            }
            catch (IncidentIDNotFoundException ex)
            {
                Console.WriteLine($"Incident ID not found: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while generating incident report: {ex.Message}");
            }
        }
        public void CreateCase(string caseDescription, Incidents incidents)
        {
            try
            {
                Cases newCase = crimeAnalysisService.CreateCase(caseDescription, incidents);
                Console.WriteLine($"Case '{newCase.CaseDescription}' created successfully with ID: {newCase.CaseId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while creating case: {ex.Message}");
            }
        }

        public void GetCaseDetails(int CaseId)
        {
            try
            {
                Cases caseDetails = crimeAnalysisService.GetCaseDetails(CaseId);
                if (caseDetails != null)
                {
                    Console.WriteLine($"Case ID: {caseDetails.CaseId}, Description: {caseDetails.CaseDescription}");
                    Console.WriteLine("Incidents associated with the case:");
                    Console.WriteLine($"Incident ID: {caseDetails.Incident.IncidentID}, Type: {caseDetails.Incident.IncidentType}, Date: {caseDetails.Incident.IncidentDate}");
                }


                else
                {
                    throw new CaseNotFoundException($"Case with ID {CaseId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting case details: {ex.Message}");
            }
        }

        public void UpdateCaseDetails(Cases updatedCase)
        {
            try
            {
                if (crimeAnalysisService.UpdateCaseDetails(updatedCase))
                {
                    Console.WriteLine($"Case with ID {updatedCase.CaseId} updated successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to update case with ID {updatedCase.CaseId}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while updating Case details: {ex.Message}");
            }
        }
        public void GetAllCases()
        {
            try
            {
                List<Cases> allCases = crimeAnalysisService.GetAllCases();
                if (allCases.Count == 0)
                {
                    Console.WriteLine("No cases found.");
                }
                else
                {
                    Console.WriteLine("All Cases:");
                    foreach (var caseDetails in allCases)
                    {
                        Console.WriteLine($"Case ID: {caseDetails.CaseId}, Description: {caseDetails.CaseDescription}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while fetching cases: {ex.Message}");
            }
        }

        public void CrimeAnalysisServiceMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("CRIME ANALYSIS SERVICE MANAGEMENT");
                Console.WriteLine("*************************************************");
                Console.WriteLine("\n");

                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create Incident");
                Console.WriteLine("2. Update Incident Status");
                Console.WriteLine("3. Get Incidents in Date Range");
                Console.WriteLine("4. Search Incidents");
                Console.WriteLine("5. Generate Incident Report");
                Console.WriteLine("6. Create Case");
                Console.WriteLine("7. Get Case Details");
                Console.WriteLine("8. Update Case Details");
                Console.WriteLine("9. Get All Cases");
                Console.WriteLine("10. Exit");

                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Console.WriteLine("---------------------Enter incident details------------------------");

                        Console.Write("Incident Type: ");
                        string incidentType = Console.ReadLine();
                        Console.Write("Incident Date (YYYY-MM-DD): ");
                        DateTime incidentDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Location: ");
                        string location = Console.ReadLine();
                        Console.Write("Description: ");
                        string description = Console.ReadLine();
                        Console.Write("Status: ");
                        string status = Console.ReadLine();
                        Console.Write("Victim ID: ");
                        int victimID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Suspect ID: ");
                        int suspectID = int.Parse(Console.ReadLine());
                        Incidents newIncident = new Incidents(0, incidentType, incidentDate, location, description, status, victimID, suspectID);
                        CreateIncident(newIncident);
                        break;

                    case 2:

                        Console.WriteLine("-----------------Update Incident Status------------------");
                        Console.WriteLine();
                        Console.Write("Enter new status: ");
                        string newStatus = Console.ReadLine();
                        Console.Write("Enter incident ID: ");
                        int incidentID = int.Parse(Console.ReadLine());
                        UpdateIncidentStatus(newStatus, incidentID);
                        break;

                    case 3:

                        Console.WriteLine("-------------------- Get Incidents in Date Range----------------");
                        Console.Write("Enter start date (YYYY-MM-DD): ");
                        DateTime startDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter end date (YYYY-MM-DD): ");
                        DateTime endDate = DateTime.Parse(Console.ReadLine());
                        GetIncidentsInDateRange(startDate, endDate);
                        break;

                    case 4:

                        Console.WriteLine("Performing action: Search Incidents");
                        Console.WriteLine("Enter search criteria:");
                        string criteria = Console.ReadLine();
                        SearchIncidents(criteria);
                        break;

                    case 5:

                        Console.WriteLine("---------------------- Generate Incident Report----------------");
                        Console.Write("Enter Incident ID: ");
                        int ID = Convert.ToInt32(Console.ReadLine());
                        Incidents incident = new Incidents { IncidentID = ID };
                        GenerateIncidentReport(incident);
                        break;

                    case 6:

                        Console.WriteLine("-------------------Create case-------------------");
                        Console.WriteLine(" Enter case description:");
                        string casedescription = Console.ReadLine();
                        Console.WriteLine("Enter incident id");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Incidents incidents = new Incidents { IncidentID = id };
                        CreateCase(casedescription, incidents);
                        break;

                    case 7:

                        Console.WriteLine(" ------------------Get Case Details---------------");
                        Console.WriteLine(" Enter case id");
                        int caseid = Convert.ToInt32(Console.ReadLine());
                        GetCaseDetails(caseid);
                        break;


                    case 8:
                        Console.WriteLine("Enter Case ID to update:");
                        int caseId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new case description: ");
                        String casedescrip = Console.ReadLine();

                        Cases updatedCase = new Cases
                        {
                            CaseId = caseId,
                            CaseDescription = casedescrip

                        };
                        UpdateCaseDetails(updatedCase);
                        break;

                    case 9:

                        GetAllCases();
                        break;


                    case 10:

                        Console.WriteLine("Exiting program.");
                        break;

                    default:
                        Console.WriteLine("Invalid option selected.");
                        break;
                }
            } while (choice != 10);
        }
    }
}


















