using Infastructure.BLL.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace RockPaperScissor.Controllers
{
    [ApiController]
    [Route("api/rockpaperscissors")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly ILogger _logger;

        public GameController(ILogger logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        [HttpPost]
        [Route("play")]
        public async Task<IActionResult> PlayGame(string playersChoice)
        {
            try
            {
                if (playersChoice.ToLower() != "rock" && playersChoice.ToLower() != "paper" && playersChoice.ToLower() != "scissors")
                {
                    return BadRequest("Invalid choice. Choose Rock, Paper, or Scissors.");
                }
                var result = await _gameService.GetGameResult(playersChoice);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("satistics")]
        public async Task<IActionResult> GetStatistics()
        {
            try
            {
                var overallStat = await _gameService.GetGameOverallStats();
                return Ok(overallStat);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("end")]
        public async Task<IActionResult> EndGame()
        {
            try
            {
                await _gameService.EndGame();
                return Ok("Game Ended. Restart the game to play");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}