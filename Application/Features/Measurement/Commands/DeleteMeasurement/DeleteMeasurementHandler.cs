using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Measurement.Commands.DeleteMeasurement;

public class DeleteMeasurementHandler : IRequestHandler<DeleteMeasurementCommand, Unit>
{
    private readonly IMeasurementRepository _measurementRepository;
    private readonly IMapper _mapper;

    public DeleteMeasurementHandler(IMeasurementRepository measurementRepository, IMapper mapper)
    {
        _measurementRepository = measurementRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteMeasurementCommand request, CancellationToken cancellationToken)
    {
        var measurementToDelete = await _measurementRepository.GetByIdAsync(request.Id);

        if (measurementToDelete is null)
            throw new NotFoundException(nameof(Domain.Measurement), request.Id);

        await _measurementRepository.DeleteAsync(measurementToDelete);

        return Unit.Value;
    }
}