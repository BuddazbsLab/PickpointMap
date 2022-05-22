using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pickpoint.Map.Application.PickpointMap.Commands.CreateAPT;
using Pickpoint.Map.Application.PickpointMap.Commands.UpdateAPT;
using Pickpoint.Map.Application.PickpointMap.Queries.GetAPTDetail;
using Pickpoint.Map.Application.PickpointMap.Queries.GetAPTList;
using PickpointMap_Backend.PickPointMap.WebApi.Model;
using PickpointMap_Backend.Queries.GetAPTDetail;

namespace PickpointMap_Backend.PickPointMap.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/apt/[controller]")] 
    public class MapApi : BaseController
    {
        private readonly IMapper _mapper;
        public MapApi(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of APT
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /note
        /// </remarks>
        /// <returns>Returns NoteListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<APTDetailVm>>> GetItems()
        {
            var query = new GetAPTListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the APT by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /note/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">APT id (guid)</param>
        /// <returns>Returns APTDetailVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APTDetailVm>> Get(Guid id)
        {
            var query = new GetAPTDetailQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the note
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /note
        /// {
        ///     title: "note title",
        ///     details: "note details"
        /// }
        /// </remarks>
        /// <param name="createNoteDto">CreateNoteDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePickpointMapAPT createNoteDto)
        {
            var command = _mapper.Map<CreateAPTCommand>(createNoteDto);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        /// <summary>
        /// Updates the APT
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /apt
        /// {
        ///     title: "updated APT title"
        /// }
        /// </remarks>
        /// <param name="updateAPTDto">UpdateAPTDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdatePickpointMapAPT updateNoteDto)
        {
            var command = _mapper.Map<UpdateAPTCommand>(updateNoteDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the APT by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /apt/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the apt (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var command = new DeleteAPTCommand
        //    {
        //        Id = id,
        //        UserId = UserId
        //    };
        //    await Mediator.Send(command);
        //    return NoContent();
        //}

    }
}