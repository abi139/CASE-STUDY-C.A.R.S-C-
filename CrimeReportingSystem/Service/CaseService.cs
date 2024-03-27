using CrimeReportingSystem.Exceptions;
using CrimeReportingSystem.Model;
using CrimeReportingSystem.Repositories;

namespace CrimeReportingSystem.Service
{
    internal class CaseService
    {
        CaseRepository caseRepository;

        public CaseService()
        {
            caseRepository = new CaseRepository();
        }

        public void CreateCase(string caseDescription, Incidents incidentid)
        {
            try
            {
                Cases newCase = caseRepository.AddCase(caseDescription, incidentid);
                Console.WriteLine("New case created successfully:");
                Console.WriteLine($"Case ID: {newCase.CaseId}");
                Console.WriteLine($"Case Description: {newCase.CaseDescription}");
                Console.WriteLine($"IncidentID: {newCase.Incident.IncidentID}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while creating case: {ex.Message}");

            }
        }

        public void UpdateCaseDetails(Cases updatedCase)
        {
            try
            {

                if (!CaseNotFoundException.CaseIDNotFound(updatedCase.CaseId))
                {
                    bool success = caseRepository.updateCaseDetails(updatedCase);
                    if (success)
                    {
                        Console.WriteLine("Case details updated successfully:");
                        Console.WriteLine($"Case ID: {updatedCase.CaseId}");
                        Console.WriteLine($"New Case Description: {updatedCase.CaseDescription}");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to update case details for Case ID: {updatedCase.CaseId}");
                    }
                }
                else
                {
                    throw new CaseNotFoundException($"Case with ID '{updatedCase.CaseId}' not found.");
                }
            }
            catch (CaseNotFoundException ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating case details: {ex.Message}");
            }
        }
        public void DisplayAllCases()
        {
            try
            {
                List<Cases> allCases = caseRepository.getAllCases();
                Console.WriteLine("All Cases:");
                foreach (var caseDetails in allCases)
                {
                    Console.WriteLine($"Case ID: {caseDetails.CaseId}");
                    Console.WriteLine($"Case Description: {caseDetails.CaseDescription}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while retrieving all cases: {ex.Message}");

            }
        }
        public void CaseMenu()
        {

            int choice = 0;

            do
            {

                Console.WriteLine("\nCrime Reporting System Menu:");
                Console.WriteLine("1. Create New Case");
                Console.WriteLine("2. Update Case Details");
                Console.WriteLine("3. Display All Cases");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Case Description: ");
                        string caseDescription = Console.ReadLine();

                        Console.Write("Enter Incident ID: ");
                        int incidentId = Convert.ToInt32(Console.ReadLine());

                        Incidents incident = new Incidents();
                        incident.IncidentID = incidentId;
                        CreateCase(caseDescription, incident);
                        break;
                    case 2:

                        Console.Write("Enter Case ID to update: ");
                        int caseId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter new Case Description: ");
                        string newCaseDescription = Console.ReadLine();
                        Cases updatedCase = new Cases();
                        updatedCase.CaseId = caseId;
                        updatedCase.CaseDescription = newCaseDescription;
                        UpdateCaseDetails(updatedCase);

                        break;

                    case 3:

                        DisplayAllCases();
                        break;

                    case 4:
                        Console.WriteLine("Exiting...");
                        break;
                    default:

                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }

            while (choice != 4);

        }
    }
}
