namespace MiddlewareApp
{
    public enum Property
    {
        XP,
        LEVEL
    }

    public class UpdateAdventurerWrapper
    {
        public Property property {  get; set; }
        
        public int amount { get; set; }
    }
}
