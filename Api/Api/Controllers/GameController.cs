using Jokenpo.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Jokenpo.Api.Controllers;

[ApiController]
[Route("game")]
public class GameController : ControllerBase
{
    private readonly PlayGameUseCase _useCase;

    public GameController(PlayGameUseCase useCase)
    {
        _useCase = useCase;
    }

    public class PlayRequest
    {
        public string Player1 { get; set; } = string.Empty;
        public string Player2 { get; set; } = string.Empty;
    }

    [HttpPost("jogar")]
    public IActionResult Jogar([FromBody] PlayRequest request)
    {
        var result = _useCase.Execute(request.Player1, request.Player2);
        return Ok(new { resultado = result });
    }
}
