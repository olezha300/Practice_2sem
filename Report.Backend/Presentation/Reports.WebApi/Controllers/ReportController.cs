using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reports.Application.Reports.Commands.CreateReport;
using Reports.Application.Reports.Commands.DeleteCommand;
using Reports.Application.Reports.Commands.UpdateReport;
using Reports.Application.Reports.Queries.GetReportDetails;
using Reports.Application.Reports.Queries.GetReportList;
using Reports.WebApi.Models;

namespace Reports.WebApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Produces("application/json")]
[Route("api/{version:apiVersion}[controller]")]
public class ReportController : BaseController
{
    private readonly IMapper _mapper;

    public ReportController(IMapper mapper) => _mapper = mapper;
    
    /// <summary>
    /// Gets the report of products
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /report
    /// </remarks>
    /// <returns>Returns ReportListVm</returns>
    /// <response code="200">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<ReportListVm>> GetAll()
    {
        var query = new GetReportListQuery
        {
            UserId = UserId
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    
    /// <summary>
    /// Gets the report by id
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /report/f6b7c25c-d4d6-49db-8060-cd88e48c5865
    /// </remarks>
    /// <param name="id">Report id (guid)</param>
    /// <returns>Returns ReportDetailsVm</returns>
    /// <response code="200">Success</response>
    /// <response code="401">If the user in unauthorized</response>
    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<ReportDetailsVm>> Get(Guid id)
    {
        var query = new GetReportDetailsQuery
        {
            UserId = UserId,
            Id = id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Creates the report
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /report
    /// {
    ///     product: "Dog",
    ///     count: 20,
    ///     price: 1000
    /// }
    /// </remarks>
    /// <param name="createReportDto">CreateReportDto object</param>
    /// <returns>Returns id (guid)</returns>
    /// <response code="201">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateReportDto createReportDto)
    {
        var command = _mapper.Map<CreateReportCommand>(createReportDto);
        command.UserId = UserId;
        var reportId = await Mediator.Send(command);
        return Ok(reportId);
    }

    /// <summary>
    /// Updates the report
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// PUT /report
    /// {
    ///     product: "updated Dog"
    ///     count: 100
    ///     price: 1000000
    /// }
    /// </remarks>
    /// <param name="updateReportDto">UpdateReportDto object</param>
    /// <returns>Returns NoContent</returns>
    /// <response code="204">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpPut]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Update([FromBody] UpdateReportDto updateReportDto)
    {
        var command = _mapper.Map<UpdateReportCommand>(updateReportDto);
        command.UserId = UserId;
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Deletes the report by id
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// DELETE /report/7b3332d5-b8e3-48bb-895d-dd105f279b5e
    /// </remarks>
    /// <param name="id">Id of the report (guid)</param>
    /// <returns>Returns NoContent</returns>
    /// <response code="204">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteReportCommand
        {
            Id = id,
            UserId = UserId
        };
        await Mediator.Send(command);
        return NoContent();
    }
}