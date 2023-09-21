﻿using System.Text.Json.Serialization;
using Refit;

namespace copilot;

public interface IDeckOfCardsApi
{
    [Get("/new/shuffle/?deck_count=1")]
    Task<Deck> Shuffle();

    [Get("/{deckId}/draw/?count=1")]
    Task<DrawResponse> Draw(string deckId);
}

public class Card
{
    public string code { get; set; }
    public string image { get; set; }
    public Images images { get; set; }
    public string value { get; set; }
    public string suit { get; set; }
}

public class Images
{
    public string svg { get; set; }
    public string png { get; set; }
}

public class DrawResponse
{
    public bool success { get; set; }
    public string deck_id { get; set; }
    public List<Card> cards { get; set; }
    public int remaining { get; set; }
}



public class Deck
{
    public bool Success { get; set; }
    [JsonPropertyName("deck_id")]
    public string DeckId { get; set; }
    public int Remaining { get; set; }
    public bool Shuffled { get; set; }
}