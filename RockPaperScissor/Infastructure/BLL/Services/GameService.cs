using Infastructure.BLL.IServices;
using Infastructure.Classes;

namespace Infastructure.BLL.Services
{
    public class GameService : IGameService
    {
        private static readonly RockPaperScissorGame game = new RockPaperScissorGame();

        public async Task EndGame() => game.EndGame();

        public async Task<string> GetGameOverallStats()
        {
            string overallStats = game.GetStatistics();
            return overallStats;
        }

        public async Task<string> GetGameResult(string playersChoice)
        {
            string result = game.PlayRound(playersChoice);
            return result;
        }
    }
}
