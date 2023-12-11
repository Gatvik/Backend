using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.GymEnrollment.Queries.Shared;
using AutoMapper;
using MediatR;

namespace Application.Features.GymEnrollment.Queries.GetAllEnrollments;

public class GetAllEnrollmentsQueryHandler : IRequestHandler<GetAllEnrollmentsQuery, List<GymEnrollmentDto>>
{
    private readonly IGymEnrollmentRepository _gymEnrollmentRepository;
    private readonly IMapper _mapper;

    public GetAllEnrollmentsQueryHandler(IGymEnrollmentRepository gymEnrollmentRepository, IMapper mapper)
    {
        _gymEnrollmentRepository = gymEnrollmentRepository;
        _mapper = mapper;
    }
    
    public async Task<List<GymEnrollmentDto>> Handle(GetAllEnrollmentsQuery request, CancellationToken cancellationToken)
    {
        var gymEnrollments = await _gymEnrollmentRepository.GetAllAsync();
        if (gymEnrollments.Count == 0)
            throw new NotFoundException("No enrollments found.");
        
        return _mapper.Map<List<GymEnrollmentDto>>(gymEnrollments);
    }
}