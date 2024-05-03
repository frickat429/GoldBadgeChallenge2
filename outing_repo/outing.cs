namespace KomodoOuting 
{
    public enum EventType{Golf =1, Bowling, AmusementPark, Concert }
public class Outing
{
public string EventType { get; set; } 
public int NumberOfAttendees { get; set; } 
public DateTime Date { get; set; }
public decimal CostPerPerson { get; set; } 
public decimal TotalCost { get; set; }
}
}

