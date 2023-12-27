using AutoMapper;
using Sorted.Business.Mapping.Converter;

namespace Sorted.Business.Mapping
{
    public class DomainToPersistenceToDomain : Profile
    {
        public DomainToPersistenceToDomain() {

            CreateMap<Sorted.Rainfall.Model.Items?, Domain.Model.StationReading?>().ConvertUsing<ReadingStationToDomainPersistenceConverter>();
        }
    }
}
