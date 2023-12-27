using Sorted.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorted.Business.IContract
{
    public interface ISortedReadingStationService
    {
        Task<List<StationReading>> GetStationReading(string stationId, int count = 10);
    }
}
