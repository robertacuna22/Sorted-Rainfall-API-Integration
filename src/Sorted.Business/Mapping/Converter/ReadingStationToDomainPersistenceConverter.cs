using AutoMapper;
using Sorted.Rainfall.Model;

namespace Sorted.Business.Mapping.Converter
{
    public class ReadingStationToDomainPersistenceConverter : ITypeConverter<Sorted.Rainfall.Model.Items?, Domain.Model.StationReading?>
    {
        public Domain.Model.StationReading? Convert(Items? source, Domain.Model.StationReading? destination, ResolutionContext context)
        {
            if (source == null) return null;

            var result = new Domain.Model.StationReading()
            {
                ReadingDate = source.dateTime,
                Measure = source.measure,
                Value = source.value
            };

            return result;
        }
    }
}
