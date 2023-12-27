namespace Sorted.Domain.Model
{
    public class StationReading
    {
        public DateTime ReadingDate { get; set; }

        public string Measure { get; set; }

        public decimal Value { get; set; }

    }
}
