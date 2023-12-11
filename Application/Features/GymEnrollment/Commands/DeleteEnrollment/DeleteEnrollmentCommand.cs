using MediatR;

namespace Application.Features.GymEnrollment.Commands.DeleteEnrollment;

public class DeleteEnrollmentCommand : IRequest<Unit>
{
    public int GymEnrollmentId { get; set; }
}