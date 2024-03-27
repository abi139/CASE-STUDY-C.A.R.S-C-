using CrimeReportingSystem.Model;
using CrimeReportingSystem.Repositories;

namespace CrimeReportingSystem.Service
{
    internal class LawEnforcementAgenciesService
    {
        LawEnforcementAgencyRepository agencyRepository;

        public LawEnforcementAgenciesService()
        {
            agencyRepository = new LawEnforcementAgencyRepository();
        }

        public void AddLawEnforcementAgency(LawEnforcementAgencies agency)
        {
            try
            {
                agencyRepository.AddLawEnforcementAgency(agency);
                Console.WriteLine("Law enforcement agency added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while adding law enforcement agency: {ex.Message}");

            }
        }

        public List<LawEnforcementAgencies> DisplayLawEnforcementAgencies()
        {
            try
            {
                List<LawEnforcementAgencies> agencies = agencyRepository.DisplayLawEnforcementAgencies();
                if (agencies.Count == 0)
                {
                    Console.WriteLine("No law enforcement agencies found.");
                }
                else
                {
                    foreach (var agency in agencies)
                    {
                        Console.WriteLine($"Agency ID: {agency.AgencyID}");
                        Console.WriteLine($"Agency Name: {agency.AgencyName}");
                        Console.WriteLine($"Jurisdiction: {agency.Jurisdiction}");
                        Console.WriteLine($"Phone Number: {agency.Phonenumber}");
                        Console.WriteLine($"Officer ID: {agency.Officer.OfficerID}");
                        Console.WriteLine();
                    }
                }
                return agencies;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while displaying law enforcement agencies: {ex.Message}");
                throw;
            }
        }

        public void RemoveLawEnforcementAgency(int agencyID)
        {
            try
            {
                agencyRepository.RemoveLawEnforcemtAgency(agencyID);
                Console.WriteLine("Law enforcement agency removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while removing law enforcement agency: {ex.Message}");

            }
        }
        public void LawEnforcementAgenciesMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("Law Enforcement Agencies Service Menu:");
                Console.WriteLine("1. Add Law Enforcement Agency");
                Console.WriteLine("2. Display Law Enforcement Agencies");
                Console.WriteLine("3. Remove Law Enforcement Agency");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Adding New Law Enforcement Agency:");

                        Console.Write("Enter Agency Name: ");
                        string agencyName = Console.ReadLine();
                        Console.Write("Enter Jurisdiction: ");
                        string jurisdiction = Console.ReadLine();
                        Console.Write("Enter Phone Number: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Enter Officer ID: ");
                        int officerID = int.Parse(Console.ReadLine());
                        Officers officer = new Officers { OfficerID = officerID };

                        LawEnforcementAgencies newAgency = new LawEnforcementAgencies(0, agencyName, jurisdiction, officer, phoneNumber);
                        AddLawEnforcementAgency(newAgency);
                        break;
                    case 2:
                        Console.WriteLine("Displaying Law Enforcement Agencies:");
                        DisplayLawEnforcementAgencies();
                        break;
                    case 3:
                        Console.WriteLine("Removing Law Enforcement Agency:");
                        Console.Write("Enter Agency ID to remove: ");
                        int removeAgencyID = Convert.ToInt32(Console.ReadLine());
                        RemoveLawEnforcementAgency(removeAgencyID);
                        break;
                    case 4:
                        Console.WriteLine("Exiting Law Enforcement Agencies Service.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            } while (choice != 4);
        }
    }
}


