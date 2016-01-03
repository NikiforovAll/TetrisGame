namespace TetrisForm
{
    public class GameStatistics
    {
        public bool IsInGame { get; set; }

        public Form1 MainForm { get; set; }

        public Form2 PlayerForm { get; set; }

        public GameStatistics(bool inGame)
        {
            this.IsInGame = inGame;
        }

    }
}
