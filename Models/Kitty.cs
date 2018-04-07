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
    }
    // public class Kitty
    // {
    //     public string Id { get; set; }     
    //     public string Name { get; set; }
    //     public string Body { get; set; }
    //     public string Pattern { get; set; }
    //     public string Mouth { get; set; }
    //     public string Eye { get; set; }
    // }
}