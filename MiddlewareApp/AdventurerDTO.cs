using MiddlewareApp.Model.Entity;

namespace MiddlewareApp
{
    public class AdventurerDTO
    {

        public Boolean Success { get; set; }

        public Adventurer? Result { get; set; }


        public string Message { get; set; } = ""; 

        public AdventurerDTO(string name, string fightingClass)
        {
            if (name == "")
            {
                Message = "Please provide a name";
            }  else if (!FightingClass.TryParse(fightingClass, out FightingClass parsedFightingClass))
            {
                Message = "Fighting class value incorrect"; 
            } else
            {
                Result = new Adventurer(name, parsedFightingClass);
                Success = true; 
            }

        }

    }
}
