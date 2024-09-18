using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.PoolEnrollment.Queries.Shared;
using AutoMapper;
using MediatR;

namespace Application.Features.PoolEnrollment.Queries.GetAllEnrollments;

public class GetAllEnrollmentsQueryHandler : IRequestHandler<GetAllEnrollmentsQuery, List<PoolEnrollmentDto>>
{
    private readonly IPoolEnrollmentRepository _poolEnrollmentRepository;
    private readonly IMapper _mapper;

    public GetAllEnrollmentsQueryHandler(IPoolEnrollmentRepository poolEnrollmentRepository, IMapper mapper)
    {
        _poolEnrollmentRepository = poolEnrollmentRepository;
        _mapper = mapper;
    }
    
    public async Task<List<PoolEnrollmentDto>> Handle(GetAllEnrollmentsQuery request, CancellationToken cancellationToken)
    {
        var gymEnrollments = await _poolEnrollmentRepository.GetAllWithDataAsync();
        if (gymEnrollments.Count == 0)
            throw new NotFoundException("No enrollments found.");
        
        return _mapper.Map<List<PoolEnrollmentDto>>(gymEnrollments);
    }
}