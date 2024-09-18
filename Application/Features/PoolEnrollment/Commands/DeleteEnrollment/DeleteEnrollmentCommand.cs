using MediatR;

namespace Application.Features.PoolEnrollment.Commands.DeleteEnrollment;

public class DeleteEnrollmentCommand : IRequest<Unit>
{
    public int PoolEnrollmentId { get; set; }
}