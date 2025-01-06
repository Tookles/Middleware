using MiddlewareApp.Database;
using MiddlewareApp.Model.Entity;

namespace MiddlewareApp.Model
{

    public interface IAdventurersRepository
    {
        public List<Adventurer> FetchAdventurers();
        public void AddAdventurer(Adventurer adventurer); 
    }

    public class AdventurersRepository : IAdventurersRepository
    {

        private ThisDbContext _db; 

        public AdventurersRepository(ThisDbContext db)
        {
            _db = db;
        }

        public List<Adventurer> FetchAdventurers()
        {
            return _db.Adventurers.ToList();
        }

        public void AddAdventurer(Adventurer adventurer)
        {
            _db.Adventurers.Add(adventurer);
            _db.SaveChanges();
        }


    }
}
