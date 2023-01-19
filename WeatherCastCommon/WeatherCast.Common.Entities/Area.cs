namespace WeatherCast.Common.Entities
{
    public class Area
    {
        public string Name { get; set; }
        public string Status { get; set; }

        public Area(string name, string statues)
        {
            this.Name = name;
            this.Status = statues;
        }

    }
}