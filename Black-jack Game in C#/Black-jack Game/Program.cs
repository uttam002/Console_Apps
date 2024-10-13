using BlackjackGame.Services;

class Program
{
    static void Main(string[] args)
    {
        var blackjackService = new BlackjackService();
        blackjackService.StartGame();
    }
}
