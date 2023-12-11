using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Measurement.Queries.Shared;
using AutoMapper;
using MediatR;

namespace Application.Features.Measurement.Queries.GetMeasurementById;

public class GetMeasurementByIdQueryHandler : IRequestHandler<GetMeasurementByIdQuery, MeasurementDto>
{
    private readonly IMeasurementRepository _measurementRepository;
    private readonly IMapper _mapper;

    public GetMeasurementByIdQueryHandler(IMeasurementRepository measurementRepository, IMapper mapper)
    {
        _measurementRepository = measurementRepository;
        _mapper = mapper;
    }
    
    public async Task<MeasurementDto> Handle(GetMeasurementByIdQuery request, CancellationToken cancellationToken)
    {
        var measurement = await _measurementRepository.GetByIdAsync(request.Id);
        
        if (measurement is null)
            throw new NotFoundException(nameof(Domain.Measurement), request.Id);
        
        return _mapper.Map<MeasurementDto>(measurement);
    }
}