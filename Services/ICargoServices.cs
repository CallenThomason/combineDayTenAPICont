//This is our menu
//Interface as a contract
//It is a list of what our cargo services MUST do. This is not where the data is kept

using combineDayTenAPICont.Models;

namespace combineDayTenAPICont.Services
{
    public interface ICargoServices
    {
        //We are creating updating reading and deleting data from our cargo database

        List<CargoItem> GetAll(); 

        List<CargoItem> GetByCategory(string category);
        CargoItem GetById(int id);

        CargoItem Create(CargoItem item);
        bool Update(int id, CargoItem item);

        bool Delete(int id);   
    }
}