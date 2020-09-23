using Core.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LikeApi.Controllers
{
    [Route("api/v1/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        [HttpPost("{articleId}")]
        public async Task<IActionResult> Like(long articleId, [FromServices] IMediator mediator)
        {
            return Ok(await mediator.Send(new LikeArticleCommand(articleId)));
        }
    }
}