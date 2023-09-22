namespace copilot;

public class BlackJack
{
    private readonly List<(string Card, int Value)> _drawnCards = new List<(string Card, int Value)>();
    private readonly IDeckOfCardsApi _deckOfCardsApi;
    private readonly string _deckId;

    public BlackJack(IDeckOfCardsApi deckOfCardsApi, string deckId)
    {
        _deckOfCardsApi = deckOfCardsApi;
        _deckId = deckId;
    }

    public async Task<string> Draw()
    {
        //draw card from deck

        //add to drawn cards

        //check if value is over 21. if so. return lost message

        //return curently drawn cards and score
    }

    public int Stop()
    {
        //return the sumerized value of drawn cards
    }

    public int GetValue(string card)
    {
        if (int.TryParse(card, out var result))
        {
            return result;
        }

        return 10;
    }
}
