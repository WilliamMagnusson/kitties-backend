namespace Kitties.Models
{
    public class Kitty
    {
        public string Id { get; set; }     
        public string Name { get; set; }
        public Body Body { get; set; }
        public Pattern Pattern { get; set; }
        public Mouth Mouth { get; set; }
        public Eye Eye { get; set; }
        public string OwnerId { get; set; }
    }
}