using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Measurement.Commands.CreateMeasurement;

public class CreateMeasurementCommandHandler : IRequestHandler<CreateMeasurementCommand, int>
{
    private readonly IMeasurementRepository _measurementRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IMemberRepository _memberRepository;

    public CreateMeasurementCommandHandler(IMeasurementRepository measurementRepository, IUserService userService,
        IMapper mapper, IMemberRepository memberRepository)
    {
        _measurementRepository = measurementRepository;
        _userService = userService;
        _mapper = mapper;
        _memberRepository = memberRepository;
    }

    public async Task<int> Handle(CreateMeasurementCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateMeasurementValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Data for creating measurement was invalid", validationResult);

        string userId = _userService.UserId;
        
        var member = await _memberRepository.GetByIdentityIdAsync(userId);
        if (member is null)
            throw new NotFoundException("Member don't binded to identity user... Please contact with admin.");
        if (member.GymId is null)
            throw new BadRequestException("Member not enrolled to gym");

        var measurementToCreate = _mapper.Map<Domain.Measurement>(request);
        measurementToCreate.DateAndTime = DateTime.UtcNow;
        measurementToCreate.MemberId = member.Id;

        // BMI = weight (kg) / height (m)2
        measurementToCreate.BodyMassIndex = Math.Round(measurementToCreate.Weight / Math.Pow(measurementToCreate.Height / 100, 2), 1);
        // Level of stress = (upper pressure + lower pressure) / 2
        measurementToCreate.LevelOfStress =
            Math.Round((measurementToCreate.UpperPressure + measurementToCreate.LowerPressure) / 2.0, 1);

        await _measurementRepository.CreateAsync(measurementToCreate);

        return measurementToCreate.Id;
    }
}