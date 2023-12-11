using Application.Features.Recommendation.Queries.GetRecommendationsByLatestMeasurement;
using Application.Features.Recommendation.Queries.GetRecommendationsBySpecificMeasurement;
using Application.Features.Recommendation.Queries.Shared;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/recommendations")]
public class RecommendationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RecommendationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("getByLatestMeasurementByMember")]
    [Authorize(Roles = "Member")]
    public async Task<ActionResult<RecommendationDto>> GetByLatestMeasurementByMember()
    {
        return Ok(await _mediator.Send(new GetRecommendationByLatestMeasurementByMemberQuery()));
    }

    [HttpGet("getBySpecificMeasurementByMember")]
    [Authorize(Roles = "Member")]
    public async Task<ActionResult<RecommendationDto>> GetByLatestMeasurementByMember(
        int measurementId)
    {
        return Ok(await _mediator.Send(new GetRecommendationsBySpecificMeasurementByMemberQuery(measurementId)));
    }
}