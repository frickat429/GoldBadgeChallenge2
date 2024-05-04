using System.Collections.Generic;
using System;
namespace KomodoOuting 
{
    public class OutingRepo 
    {
        private List<Outing> _outings = new List<Outing>() ;

        //Create 
        public void AddOuting(Outing outing) 
        {
            _outings.Add(outing) ;
        } 

        //Read
        public Outing GetOutingByDate(DateTime date) 
        {
            foreach(Outing outing in _outings) 
            {
                if(outing.Date.Date == date.Date) 
                {
                    return outing; 
                }
            }
            return null ;
        } 

        //Get all outings 
        public List<Outing> GetAllOutings() 
        {
            return new List<Outing>(_outings);
        }
        //Calculate combined cost for all outings 
        public decimal CalculateCombinedCost() 
        {
            decimal TotalCost = 0;
            foreach(Outing outing in _outings) 
            {
                TotalCost += outing.TotalCost;
            } 
            return TotalCost;
        }
    //Calculate outing costs by type
    public Dictionary<string, decimal> CalculateCostByType() 
    {
        var costByType = new Dictionary<string, decimal>() ;
        foreach(var outing in _outings) 
        {
            if (costByType.ContainsKey(outing.EventType))
            {
                costByType[outing.EventType] += outing.TotalCost;
            } 
            else
            {
                costByType.Add(outing.EventType, outing.TotalCost) ;
            }
        } 
        return costByType;
    }
   
    

        //Update 
        public void Updateouting(DateTime date, Outing updatedOuting) 
        {
        foreach(Outing outing in _outings) 
        {
        if(outing.Date.Date == date.Date) 
        {
            outing.EventType = updatedOuting.EventType;
            outing.NumberOfAttendees = updatedOuting.NumberOfAttendees;
            outing.Date = updatedOuting.Date;
            outing.CostPerPerson = updatedOuting.CostPerPerson;
            outing.TotalCost = updatedOuting.TotalCost;
            break;
        }
        }
        } 

        //Delete not used in the challenge, but here is what it might look like 
        // public void DeleteOuting(Outing outing) 
        // {
        //     _outings.Remove(outing) ;
        // } 

    } 


}