// See https://aka.ms/new-console-template for more information

using copilot;
using Refit;

Console.WriteLine("Hello. Want to play a game?");

var deckOfCardsApi = RestService.For<IDeckOfCardsApi>("https://deckofcardsapi.com/api/deck");

var deck = await deckOfCardsApi.Shuffle();

var blackJack = new BlackJack(deckOfCardsApi, deck.DeckId);

var drawn = await blackJack.Draw();
Console.WriteLine($"Your first card is: {drawn}");

//ask if they want to draw again
//if yes, draw again
//if no, stop
Console.WriteLine("Do you want to draw again?");
var answer = Console.ReadLine();

while (answer == "yes" || answer == "y")
{
    drawn = await blackJack.Draw();
    Console.WriteLine(drawn);
    if (drawn.Contains("lost"))
    {
        break;
    }
    Console.WriteLine("Do you want to draw again?");
    answer = Console.ReadLine();
}

var score = blackJack.Stop();
Console.WriteLine($"Your score is: {score}");