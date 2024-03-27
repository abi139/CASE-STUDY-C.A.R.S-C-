using CrimeReportingSystem.Model;
using CrimeReportingSystem.Repositories;

namespace CrimeReportingSystem.Service
{
    internal class EvidenceService
    {
        EvidenceRepository evidenceRepository;

        public EvidenceService()
        {
            evidenceRepository = new EvidenceRepository();
        }

        public void AddEvidence(Evidence evidence)
        {
            try
            {
                evidenceRepository.AddEvidence(evidence);
                Console.WriteLine("Evidence added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while adding evidence: {ex.Message}");

            }
        }

        public void GetEvidenceByIncidentID(int incidentID)
        {
            try
            {
                List<Evidence> evidenceList = evidenceRepository.GetEvidenceByIncidentID(incidentID);
                if (evidenceList.Count == 0)
                {
                    Console.WriteLine("No evidence found for the given incident ID.");
                }
                else
                {
                    foreach (var evidence in evidenceList)
                    {
                        Console.WriteLine($"Evidence ID: {evidence.EvidenceID}");
                        Console.WriteLine($"Description: {evidence.Description}");
                        Console.WriteLine($"Location Found: {evidence.LocationFound}");
                        Console.WriteLine($"Incident ID: {evidence.IncidentID}");
                        Console.WriteLine();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting evidence: {ex.Message}");

            }
        }

        public void UpdateEvidence(Evidence evidence)
        {
            try
            {
                evidenceRepository.UpdateEvidence(evidence);
                Console.WriteLine("Evidence updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating evidence: {ex.Message}");

            }
        }

        public void DisplayAllEvidence()
        {
            try
            {
                List<Evidence> allEvidence = evidenceRepository.DisplayAllEvidence();
                if (allEvidence.Count == 0)
                {
                    Console.WriteLine("No evidence found.");
                }
                else
                {
                    foreach (var evidence in allEvidence)
                    {
                        Console.WriteLine($"Evidence ID: {evidence.EvidenceID}");
                        Console.WriteLine($"Description: {evidence.Description}");
                        Console.WriteLine($"Location Found: {evidence.LocationFound}");
                        Console.WriteLine($"Incident ID: {evidence.IncidentID}");
                        Console.WriteLine();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while displaying evidence: {ex.Message}");

            }
        }

        public void EvidenceMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("Evidence Service Menu:");
                Console.WriteLine("1. Add Evidence");
                Console.WriteLine("2. Update Evidence");
                Console.WriteLine("3. Get Evidence by Incident ID");
                Console.WriteLine("4. Display All Evidence");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Console.WriteLine("Adding New Evidence:");
                        Console.Write("Enter Description: ");
                        string description = Console.ReadLine();
                        Console.Write("Enter Location Found: ");
                        string locationFound = Console.ReadLine();

                        Console.Write("Enter Incident ID: ");
                        int incidentID = int.Parse(Console.ReadLine());
                        Evidence newEvidence = new Evidence
                        {
                            Description = description,
                            LocationFound = locationFound,
                            IncidentID = incidentID
                        };
                        AddEvidence(newEvidence);
                        break;

                    case 2:
                        Console.WriteLine("Updating Evidence:");

                        Console.Write("Enter Evidence ID to update: ");
                        int evidenceIDToUpdate = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Description: ");
                        string newDescription = Console.ReadLine();
                        Console.Write("Enter New Location Found: ");
                        string newLocationFound = Console.ReadLine();
                        Evidence updatedEvidence = new Evidence
                        {
                            EvidenceID = evidenceIDToUpdate,
                            Description = newDescription,
                            LocationFound = newLocationFound
                        };
                        UpdateEvidence(updatedEvidence);
                        break;
                    case 3:
                        Console.WriteLine("Getting Evidence by Incident ID:");

                        Console.Write("Enter Incident ID: ");
                        int incidentsID = int.Parse(Console.ReadLine());
                        GetEvidenceByIncidentID(incidentsID);
                        break;

                    case 4:
                        Console.WriteLine("Displaying All Evidence:");
                        DisplayAllEvidence();
                        break;
                    case 5:
                        Console.WriteLine("Exiting Evidence Service.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            } while (choice != 5);
        }
    }
}

