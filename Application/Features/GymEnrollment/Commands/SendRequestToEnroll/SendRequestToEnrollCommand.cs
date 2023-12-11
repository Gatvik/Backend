using MediatR;

namespace Application.Features.GymEnrollment.Commands.SendRequestToEnroll;

public class SendRequestToEnrollCommand : IRequest<int>
{
    public int GymId { get; set; }
}