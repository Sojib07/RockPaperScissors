namespace Infastructure.BLL.IServices
{
    public interface IGameService
    {
        public Task<string> GetGameResult(string playersChoice);
        public Task<string> GetGameOverallStats();
        public Task EndGame();
    }
}
