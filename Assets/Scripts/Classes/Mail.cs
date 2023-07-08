using System;
using System.Collections.Generic;
using UnityEngine;

public enum MailStatus
{
    Unmarked,
    Accepted,
    Rejected,
}

public enum MailCategory {
    Inbox,
    Correct,
    Incorrect,
    Spam,
}

public class Mail {
    
    public string Name { get; private set; }
    public string From { get; private set; }
    public string Genre { get; private set; }
    public string[] Subgenres { get; private set; }
    public int StoreRating { get; private set; }
    public string Content { get; private set; }
    public bool IsValid { get; private set; }
    public MailCategory Category;

    public Dictionary<string, (int, int)> Ratings = new Dictionary<string, (int, int)>();

    public Mail(string name, string from, string genre, string[] subgenres, int storeRating, string content, bool isCorrect) {

        Name = name;
        From = from;
        Genre = genre;
        StoreRating = storeRating;
        Content = content;
        Category = MailCategory.Inbox;
        IsValid = isCorrect;

        float accRatio = (float)storeRating / 5f;
        float lowerBound = accRatio - 0.2f;

        Ratings.Add("SaqueCritic", ((int)Math.Round(UnityEngine.Random.Range(lowerBound, accRatio) * 100, 0), 100));
        Ratings.Add("PDPE", ((int)Math.Round(UnityEngine.Random.Range(lowerBound, accRatio) * 60, 0), 60));
        Ratings.Add("Game Location", ((int)Math.Round(UnityEngine.Random.Range(lowerBound, accRatio) * 10, 0), 10));
        Ratings.Add("Green Mesa", ((int)Math.Round(UnityEngine.Random.Range(lowerBound, accRatio) * 50, 0), 50));
    }
}
