using System;
namespace KomodoOuting;

public class ProgramUI
{
    private OutingRepo _outingRepo;
    public ProgramUI()
    {
        _outingRepo = new OutingRepo();
    }

    public void Run()
    {
        SeedData();
        DisplayMenu();
    }

    private void DisplayMenu()
    { 
         Console.WriteLine("=-=-=-=- Main Menu -=-=-=-="); 
        Console.WriteLine("1. Display list of all outings");
        Console.WriteLine("2. Add a new or future outing");
        Console.WriteLine("3. Update outing");
        Console.WriteLine("4. Calculate combined cost for all outings");
        Console.WriteLine("5. Calculate outing costs by type");
        Console.WriteLine("6. Exit");

        Console.WriteLine("Welcome to Komado Outings, what would you like to do?");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                DisplayAllOutings();
                break;
            case "2":
                AddNewOuting();
                break;
                case "3" :
                UpdateOuting();
                break;
            case "4":
                Console.WriteLine($"Combined cost for all outings: {_outingRepo.CalculateCombinedCost():C}");
                break;
            case "5":
                DisplayOutingCostsByType();
                break;
            case "6":
                Console.WriteLine("Exiting Program...");
                return;
            default:
                Console.WriteLine("Invaild choice. Please try again");
                break;
        }

        Console.WriteLine();
        DisplayMenu();
    }


    //Display All outings 
    private void DisplayAllOutings()
    {
        List<Outing> outings = _outingRepo.GetAllOutings();
        Console.WriteLine("List of all outings");
        foreach (var outing in outings)
        {
            Console.WriteLine($"Event: {outing.EventType}, Date: {outing.Date.ToShortDateString()}, Total Cost: {outing.TotalCost:C}");
        }
    } 
    //Add a new outing
    private void AddNewOuting() 
    {
    Outing newOuting = new Outing() ;
    Console.WriteLine("Enter Event Type (Golf, Bowling, Amusement Park, Concert) "); 
    newOuting.EventType = Console.ReadLine();
    Console.WriteLine("Enter Number of People Attending") ;
    newOuting.NumberOfAttendees = int.Parse(Console.ReadLine()) ;
    Console.WriteLine("Enter Date (MM/DD/YYYY)") ;
    newOuting.Date = DateTime.Parse(Console.ReadLine()) ;
    Console.WriteLine("Enter Total Cost Per Person") ; 
    newOuting.CostPerPerson = decimal.Parse(Console.ReadLine()) ;
    Console.WriteLine("Enter Total Cost for the Event") ;
    newOuting.TotalCost = decimal.Parse(Console.ReadLine()) ;
    _outingRepo.AddOuting(newOuting) ;
    Console.WriteLine("New outing added successfully") ;
    } 

    //Display outing cost by type 
    private void DisplayOutingCostsByType() 
    {
    Dictionary<string, decimal> costByType = _outingRepo.CalculateCostByType();
    Console.WriteLine("Outing Costs by Type") ;
    foreach(var kvp in costByType) 
    {
        Console.WriteLine($"{kvp.Key}: {kvp.Value: C}") ;

    }
    } 

    //Update an outing 
    private void UpdateOuting() 
    {
    Console.WriteLine("Enter date of the outing you wish tp update (mm/DD/YYYY):") ;
    DateTime date = DateTime.Parse(Console.ReadLine()) ;  

    Outing existingOuting = _outingRepo.GetOutingByDate(date) ;
    if (existingOuting == null) 
    {
        Console.WriteLine("Outing not found for specified date.") ;
        return;
    } 
    Outing updatedOuting = new Outing();
    Console.WriteLine("Enter updated Event Type (Golf, Bowling, Amusement Park, Concert)") ; 
    updatedOuting.EventType = Console.ReadLine();

    Console.WriteLine("Enter updated number of people") ;
    updatedOuting.NumberOfAttendees = int.Parse(Console.ReadLine()) ;
    Console.WriteLine("Enter Updated Date (mm/DD/YYYY)") ;
    updatedOuting.Date = DateTime.Parse(Console.ReadLine()) ;
    Console.WriteLine("Enter updated total cost per person") ;
    updatedOuting.CostPerPerson = decimal.Parse(Console.ReadLine()) ;
    Console.WriteLine("Enter updated cost for the Event") ;
    updatedOuting.TotalCost = decimal.Parse(Console.ReadLine()) ;
    _outingRepo.Updateouting(date, updatedOuting);
    Console.WriteLine("Outing updated successfully!") ;
    }
    
    
    private void SeedData()
    {
    _outingRepo.AddOuting(new Outing{
    EventType = "Golf", 
    NumberOfAttendees = 8,
    Date = new DateTime(2024, 05, 17),
    CostPerPerson = 60, 
    TotalCost = 480
    }) ; 

    _outingRepo.AddOuting(new Outing{
        EventType = "Bowling",
        NumberOfAttendees = 6, 
        Date = new DateTime(2024, 07, 15) ,
        CostPerPerson = 35, 
        TotalCost = 210 
    }); 

    _outingRepo.AddOuting(new Outing{
        EventType = "Amusement Park" ,
        NumberOfAttendees = 12, 
        Date = new DateTime(2024, 06, 17),
        CostPerPerson = 75, 
        TotalCost = 900 
    }); 

    _outingRepo.AddOuting(new Outing{
        EventType = "Concert" ,
        NumberOfAttendees = 20, 
        Date = new DateTime(2024, 08, 23),
        CostPerPerson = 40, 
        TotalCost = 800
    }) ;
    } 

    
}