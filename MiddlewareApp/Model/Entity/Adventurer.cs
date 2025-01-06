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

        [Required(ErrorMessage = "No Name provided")]
        public string Name { get; set; }

        [Required(ErrorMessage = "FightingClass is required")]
        [Range(0, 3, ErrorMessage = "This is not a valid Fighting Class")]
        public FightingClass FightingClass { get; set; }

        [Range(1, int.MaxValue)]
        public int Level { get; set; } = 1;

        [Range(0, 100)]
        public int XP { get; set; } = 0; 


        public Adventurer(string name, FightingClass fightingClass)
        {
            Name = name;
            FightingClass = fightingClass;
        }


        public void GainXP(int changeInXP)
        {
            int tempXP = this.XP + changeInXP; 
            if (tempXP < 100) 
            {
                this.XP = tempXP;
            } else
            {
                this.Level += 1;
                tempXP -= 100; 
                this.GainXP(tempXP);
            }
        }

    }
}
