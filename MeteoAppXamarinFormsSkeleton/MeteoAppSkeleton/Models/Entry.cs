using SQLite;

namespace MeteoAppSkeleton.Models
{
    public class Entry
    {
        [PrimaryKey]
        public string ID { get; set; }
        public string Title { get; set; }
        public double AvgTemp { get; set; }
        public double LowestTemp { get; set; }
        public double HighestTemp { get; set; }

    }
}