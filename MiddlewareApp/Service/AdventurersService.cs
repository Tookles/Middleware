using MiddlewareApp.Model;
using MiddlewareApp.Model.Entity;

namespace MiddlewareApp.Service
{
    public interface IAdventurersService
    {
        public List<Adventurer> GetAllAdventurers();

        public void AddAdventurer(Adventurer adventurer);

        public Boolean DeleteAdventurer(int adventurerId);

        public Boolean UpdateAdventurer(int id, UpdateAdventurerWrapper adventurerMod); 

    }

    public class AdventurersService : IAdventurersService
    {
        
        private readonly IAdventurersRepository _adventurersModel;

        public AdventurersService(IAdventurersRepository adventurersModel)
        {
            _adventurersModel = adventurersModel;
        }


        public List<Adventurer> GetAllAdventurers()
        {
            return _adventurersModel.FetchAdventurers();
        }

        public void AddAdventurer(Adventurer adventurer)
        {
            _adventurersModel.AddAdventurer(adventurer);
        }

        public Boolean DeleteAdventurer(int adventurerId)
        {
            if (_adventurersModel.CheckAdventurerExists(adventurerId))
            {
                _adventurersModel.DeleteAdventurer(adventurerId);
                return true;
            }
            return false; 
        }


        public Boolean UpdateAdventurer(int id, UpdateAdventurerWrapper adventurerMod)
        {
            if (_adventurersModel.CheckAdventurerExists(id))
            {
                if (adventurerMod.property == Property.XP)
                {
                    _adventurersModel.UpdateAdventurerXP(id, adventurerMod.amount);
                    return true;

                }
                else if (adventurerMod.property == Property.LEVEL)
                {
                    _adventurersModel.UpdateAdventurerLevel(id, adventurerMod.amount);
                    return true;
                }
            }
            return false; 

        }


    }
}
