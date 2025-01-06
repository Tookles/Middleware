using MiddlewareApp.Database;
using MiddlewareApp.Model.Entity;

namespace MiddlewareApp.Model
{

    public interface IAdventurersRepository
    {
        public List<Adventurer> FetchAdventurers();
        public void AddAdventurer(Adventurer adventurer);

        public Boolean CheckAdventurerExists(int id);
        public void DeleteAdventurer(int id);
        public void UpdateAdventurerLevel(int id, int level);

        public void UpdateAdventurerXP(int id, int XP);

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

        public Boolean CheckAdventurerExists(int id)
        {
            return _db.Adventurers.Any(a => a.Id == id);
        }

        public void DeleteAdventurer(int id)
        {
            Adventurer aToDelete = _db.Adventurers.Where(a => a.Id == id).First();
            _db.Adventurers.Remove(aToDelete); 
            _db.SaveChanges();
        }

        public void UpdateAdventurerLevel(int id, int level)
        {
            Adventurer aToUpdate = _db.Adventurers.Where(a => a.Id == id).First();
            aToUpdate.Level = level;
            _db.SaveChanges();
        }

        public void UpdateAdventurerXP(int id, int XP)
        {
            Adventurer aToUpdate = _db.Adventurers.Where(a => a.Id == id).First();
            aToUpdate.GainXP(XP);
            _db.SaveChanges();
        }
    }
}
