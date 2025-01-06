using MiddlewareApp.Model;
using MiddlewareApp.Model.Entity;

namespace MiddlewareApp.Service
{
    public interface IAdventurersService
    {
        public List<Adventurer> GetAllAdventurers();

        public void AddAdventurer(Adventurer adventurer);

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


    }
}
