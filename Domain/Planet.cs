namespace search_engine.Domain
{
    public class Planet
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public Double Diameter { get; set; }
        public Double LengthOfDay { get; set; }
        public Double Density { get; set; }
        public Double EscapeVelocity { get; set; }
        public Double DistFromSun { get; set; }
    }
}
