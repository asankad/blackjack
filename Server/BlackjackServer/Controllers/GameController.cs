using BlackjackServer.Game;
using Microsoft.AspNetCore.Mvc;

namespace BlackjackServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly GameManager _gameManager;

    public GameController(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    [HttpPost("start")]
    public IActionResult StartGame()
    {
        var gameId = _gameManager.CreateGame();
        return Ok(new { gameId });
    }
}
