using CrimeReportingSystem.Exceptions;
using CrimeReportingSystem.Model;
using CrimeReportingSystem.Repositories;

namespace CrimeReportingSystem.Service
{
    internal class IncidentService
    {
        IncidentRepository incidentRepository;

        public IncidentService()
        {
            incidentRepository = new IncidentRepository();
        }

        public void DisplayAllIncidents()
        {
            try
            {
                List<Incidents> incidentsList = incidentRepository.DisplayAllIncidents();
                if (incidentsList.Count == 0)
                {
                    Console.WriteLine("No incidents found.");
                    return;
                }

                foreach (var incident in incidentsList)
                {
                    Console.WriteLine($"Incident ID: {incident.IncidentID}");
                    Console.WriteLine($"Type: {incident.IncidentType}");
                    Console.WriteLine($"Date: {incident.IncidentDate}");
                    Console.WriteLine($"Location: {incident.Location}");
                    Console.WriteLine($"Description: {incident.Description}");
                    Console.WriteLine($"Status: {incident.Status}");
                    Console.WriteLine($"Victim ID: {incident.VictimID}");
                    Console.WriteLine($"Suspect ID: {incident.SuspectID}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching incidents: {ex.Message}");
            }
        }
        public void GetIncidentsbyID(int incidentid)
        {
            try
            {
                Incidents incident = incidentRepository.GetIncidentsbyID(incidentid);

                if (incident == null)
                {
                    throw new IncidentIDNotFoundException($"Incident with ID '{incidentid}' not found.");

                }
                else
                {

                    Console.WriteLine($"Incident ID: {incident.IncidentID}");
                    Console.WriteLine($"Type: {incident.IncidentType}");
                    Console.WriteLine($"Date: {incident.IncidentDate}");
                    Console.WriteLine($"Location: {incident.Location}");
                    Console.WriteLine($"Description: {incident.Description}");
                    Console.WriteLine($"Status: {incident.Status}");
                    Console.WriteLine($"Victim ID: {incident.VictimID}");
                    Console.WriteLine($"Suspect ID: {incident.SuspectID}");
                    Console.WriteLine();
                }


            }

            catch (IncidentIDNotFoundException ex)
            {

                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }

        public void RemoveIncident(int incidentid)
        {
            try
            {
                incidentRepository.RemoveIncident(incidentid);
                Console.WriteLine($"Incident with ID '{incidentid}' removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");

            }
        }
        public void IncidentsMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("Incident Service Menu:");
                Console.WriteLine("1. Display All Incidents");
                Console.WriteLine("2. Get Incidents by ID");
                Console.WriteLine("3. Remove Incident");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DisplayAllIncidents();
                        break;
                    case 2:
                        Console.Write("Enter Incident ID: ");
                        int incidentID = int.Parse(Console.ReadLine());
                        GetIncidentsbyID(incidentID);
                        break;
                    case 3:
                        Console.Write("Enter Incident ID to remove: ");
                        int removeIncidentID = int.Parse(Console.ReadLine());
                        RemoveIncident(removeIncidentID);
                        break;
                    case 4:
                        Console.WriteLine("Exiting Incident Service.......");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            } while (choice != 4);
        }





    }
}
