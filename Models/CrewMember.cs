//A model is just a normal C# class describing One Thing your API works with
//This will "Describe our Crew Memeber Data" 

namespace combineDayTenAPICont.Models
{
    public class CrewMember
    {
        public int Id {get; set;} //Every Item needs a unique id so clients can address it
        public string Name{get; set;} //get allows us to get this property value, and set allows us to change it
        public string Rank{get; set;}
        public string Sector{get; set;}
        public bool IsOnDuty{get; set;}
    }
}

//CrewMember crew = new CrewMember(); 
// crew.Name="Chris"; <- this would be a set
//Console.WriteLine(crew.Name); <- This is a get