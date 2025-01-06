namespace MiddlewareApp.DTO
{
    public class AdventurerDTO(string name, string fightingClass)
    {
        public string name { get; set; } = name;

        public string fightingClass { get; set; } = fightingClass;


    }
}
