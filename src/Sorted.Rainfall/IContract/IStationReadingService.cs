using Sorted.Rainfall.Model;

namespace Sorted.Rainfall
{
    public interface IStationReadingService
    {
        Task<StationReading> Get(string stationId, int count = 10);
    }
}
