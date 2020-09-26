using Core.Commands;
using Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LikeApi.Controllers
{
    [Route("api/v1/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        [HttpGet("{articleId}/likes")]
        public async Task<IActionResult> GetArticleLikes(Guid articleId, [FromServices] IMediator mediator)
        {
            return Ok(await mediator.Send(new GetArticleLikesQuery(articleId)));
        }

        [HttpPost("{articleId}/likes")]
        public async Task<IActionResult> Like(Guid articleId, [FromServices] IMediator mediator)
        {
            return Ok(await mediator.Send(new LikeArticleCommand(articleId)));
        }
    }
}