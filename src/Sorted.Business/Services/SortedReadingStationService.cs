using AutoMapper;
using Sorted.Business.IContract;
using Sorted.Domain.Model;
using Sorted.Rainfall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorted.Business.Services
{
    public class SortedReadingStationService : ISortedReadingStationService
    {
        private readonly IMapper _mapper;
        private readonly IStationReadingService _service;

        public SortedReadingStationService(IStationReadingService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<List<StationReading>> GetStationReading(string stationId, int count = 10)
        {
            var result = await _service.Get(stationId, count);

            var mappedResult = _mapper.Map<List<StationReading>>(result.items);

            return mappedResult;
        }
    }
}
