namespace Infastructure.Classes
{
    public class RockPaperScissorGame
    {
        private int playerWins = 0;
        private int computerWins = 0;
        private int ties = 0;

        public string PlayRound(string playerChoice)
        {
            int computerIndex = new Random().Next(0, 3);
            var computerChoice = ((Choice)computerIndex).ToString();

            playerChoice = playerChoice.ToLower();

            if (playerChoice == computerChoice)
            {
                ties++;
                return $"It's a tie! You both chose {playerChoice}.";
            }
            else if ((playerChoice == "rock" && computerChoice == "scissors") ||
                     (playerChoice == "paper" && computerChoice == "rock") ||
                     (playerChoice == "scissors" && computerChoice == "paper"))
            {
                playerWins++;
                return $"You win! {playerChoice} beats {computerChoice}.";
            }
            else
            {
                computerWins++;
                return $"Computer wins! {computerChoice} beats {playerChoice}.";
            }
        }

        public string GetStatistics()
        {
            return $"Player Wins: {playerWins}, Computer Wins: {computerWins}, Ties: {ties}";
        }

        public void EndGame()
        {
            playerWins = 0;
            computerWins = 0;
            ties = 0;
        }

        enum Choice
        {
            rock,
            paper,
            scissors
        }
    }

}
