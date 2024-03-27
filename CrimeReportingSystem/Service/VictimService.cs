using CrimeReportingSystem.Model;
using CrimeReportingSystem.Repositories;

namespace CrimeReportingSystem.Service
{
    internal class VictimService
    {
        VictimRepository victimRepository;

        public VictimService()
        {
            victimRepository = new VictimRepository();
        }

        public void AddVictim(Victims victim)
        {
            try
            {
                victimRepository.AddVictim(victim);
                Console.WriteLine("Victim added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while adding victim: {ex.Message}");

            }
        }

        public void RemoveVictim(int victimID)
        {
            try
            {
                victimRepository.RemoveVictim(victimID);
                Console.WriteLine($"Victim with ID '{victimID}' removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while removing victim: {ex.Message}");
                throw;
            }
        }
        public List<Victims> DisplayAllVictims()
        {
            try
            {
                List<Victims> victims = victimRepository.DisplayVictimsDetials();
                if (victims.Count == 0)
                {
                    Console.WriteLine("No victims found.");
                    return victims;
                }

                foreach (var victim in victims)
                {
                    Console.WriteLine($"Victim ID: {victim.VictimID}");
                    Console.WriteLine($"First Name: {victim.FirstName}");
                    Console.WriteLine($"Last Name: {victim.LastName}");
                    Console.WriteLine($"Date of Birth: {victim.DateOfBirth}");
                    Console.WriteLine($"Gender: {victim.Gender}");
                    Console.WriteLine($"Address: {victim.Address}");
                    Console.WriteLine($"Phone Number: {victim.Phonenumber}");
                    Console.WriteLine();
                }

                return victims;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching victims: {ex.Message}");
                throw;
            }
        }
        public void VictimsMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1.Adding New Victim:");
                Console.WriteLine("2.Removing Victim:");
                Console.WriteLine("3.Displaying All Victims:");
                Console.WriteLine("4.Exit");
                Console.WriteLine("Enter your choice");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Adding New Victim:");
                        Console.Write("Enter First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter Last Name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Enter Date of Birth (MM/DD/YYYY): ");
                        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter Gender: ");
                        string gender = Console.ReadLine();
                        Console.Write("Enter Address: ");
                        string address = Console.ReadLine();
                        Console.Write("Enter Phone Number: ");
                        string phoneNumber = Console.ReadLine();

                        Victims newVictim = new Victims(0, firstName, lastName, dateOfBirth, gender, address, phoneNumber);
                        AddVictim(newVictim);
                        break;

                    case 2:
                        Console.WriteLine("Removing Victim:");

                        Console.Write("Enter Victim ID to remove: ");
                        int removeVictimID = int.Parse(Console.ReadLine());
                        RemoveVictim(removeVictimID);
                        break;

                    case 3:
                        Console.WriteLine("Displaying All Victims:");

                        DisplayAllVictims();
                        break;

                    case 4:
                        Console.WriteLine("Exiting Victim Service.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            } while (choice != 4);
        }
    }


}

