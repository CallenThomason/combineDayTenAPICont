//CargoServices will be where our logic happens
//This is our kitchen
using combineDayTenAPICont.Models;

namespace combineDayTenAPICont.Services
{
    //ICargoServices is a PROMISE that this class will implement EVERY method within our interface
    public class CargoServices : ICargoServices
    {
        private static List<CargoItem> _manafest = [
            new CargoItem{ Id = 1, Name = "Rations", Category = "Food", Masskg = 240},
            new CargoItem{Id = 2, Name = "Battery cells", Category = "Energy", Masskg = 1200},
            new CargoItem{Id = 3, Name = "Trauma kits", Category = "Medical", Masskg = 55},
             new CargoItem{Id = 4, Name = "Healing potion", Category = "Medical", Masskg = 10}
        ];
        //While the application runs static means it will keep track of the number and not reset
        static int newId = 5; 

        public List<CargoItem> GetAll()
        {
            return _manafest; 
        }

        public List<CargoItem> GetByCategory(string category)
        {
            //We do not want to mutate our original list
            //We are putting our manifest in a copy so their isn't a chance where we mutate
            //IEnumerable = List with Specific Rules. You can only iterate through
           IEnumerable<CargoItem> result = _manafest;
            //Linq Queries are handy methods that we use to Query Lists / Databases
            //Language Integrated Query
            //Where filters our and then stores the condition in a list
            // => is called an arrow function / LMBDA a short hand for an anomous function
            //this will run once per item c=> c.Category == category
            result = result.Where(c => c.Category == category); 

            return result.ToList(); 
        }

        public CargoItem GetById(int id)
        {
            CargoItem? item = _manafest.FirstOrDefault(c => c.Id == id);

            return item; 
        }

        public CargoItem Create(CargoItem item)
        {
            item.Id = newId; 
            newId++; 

            _manafest.Add(item); 

            return item; 
        }

        public bool Update(int id, CargoItem item)
        {
            //first or default checks the list against the condtion i.Id == Id
            //returns the first result or default (null)
            CargoItem? existing = _manafest.FirstOrDefault(c => c.Id == id); 
            if(existing is null)
            {
                return false; 
            }

            existing.Name = item.Name; 
            existing.Category = item.Category; 
            existing.Masskg = item.Masskg; 
            return true; 
        }

        public bool Delete(int id)
        {
            CargoItem?  existingItem = _manafest.FirstOrDefault(t => t.Id == id); 

            if(existingItem is null)
            {
                return false; 
            }

            _manafest.Remove(existingItem); 
            return true; 
        }

    }
}