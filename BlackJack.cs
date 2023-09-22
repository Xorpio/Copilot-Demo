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
        var drawResponse = await _deckOfCardsApi.Draw(_deckId);

        //add to drawn cards
        var value = GetValue(drawResponse.cards.First().value);
        _drawnCards.Add((drawResponse.cards.First().code, value));

        //check if value is over 21. if so. return lost message
        if (_drawnCards.Sum(card => card.Value) > 21)
        {
            return $"You lost. Your score is {_drawnCards.Sum(card => card.Value)}";
        }

        //return curently drawn cards and score
        return $"Current drawn cards: {string.Join(", ", _drawnCards.Select(card => card.Card))}, total value: {_drawnCards.Sum(card => card.Value)}";
    }

    public int Stop()
    {
        //return the sumerized value of drawn cards
        return _drawnCards.Sum(card => card.Value);
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
