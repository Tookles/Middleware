using MiddlewareApp.Model.Entity;

namespace MiddlewareApp.DTO
{
    public class AdventurerDTOWrapper
    {

        public bool Success { get; set; }

        public Adventurer? Result { get; set; }


        public string Message { get; set; } = "";

        public AdventurerDTOWrapper(AdventurerDTO userInput)
        {
            if (userInput.name == "")
            {
                Message = "Please provide a name";
            }
            else if (!Enum.TryParse(userInput.fightingClass, out FightingClass parsedFightingClass))
            {
                Message = "Fighting class value incorrect";
            }
            else
            {
                Result = new Adventurer(userInput.name, parsedFightingClass);
                Success = true;
            }

        }

    }
}
