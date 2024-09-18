using MediatR;

namespace Application.Features.PoolEnrollment.Commands.SendRequestToEnroll;

public class SendRequestToEnrollCommand : IRequest<int>
{
    public int PoolId { get; set; }
}