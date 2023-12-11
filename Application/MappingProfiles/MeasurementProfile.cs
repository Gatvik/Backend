using Application.Features.Measurement.Commands.CreateMeasurement;
using Application.Features.Measurement.Queries.Shared;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles;

public class MeasurementProfile : Profile
{
    public MeasurementProfile()
    {
        CreateMap<CreateMeasurementCommand, Measurement>();
        CreateMap<Measurement, MeasurementDto>();
    }
}