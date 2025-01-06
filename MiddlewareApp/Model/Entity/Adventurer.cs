using System.ComponentModel.DataAnnotations; 

namespace MiddlewareApp.Model.Entity
{
    public enum FightingClass {
        WARRIOR,
        ROGUE,
        MAGE
    }

    public class Adventurer
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public FightingClass FightingClass { get; set; }

        [Range(1, int.MaxValue)]
        public int Level { get; set; } = 1;

        [Range(0, int.MaxValue)]
        public int XP { get; set; } = 0; 


        public Adventurer(string name, FightingClass fightingClass)
        {
            Name = name;
            FightingClass = fightingClass;
        }


    }
}
