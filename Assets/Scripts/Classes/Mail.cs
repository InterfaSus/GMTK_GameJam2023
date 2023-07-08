using System.Linq;
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
    public bool IsValid;
    public MailCategory Category;

    public Dictionary<string, (int, int)> Ratings = new Dictionary<string, (int, int)>();

    public Mail(string name, string from, string genre, string[] subgenres, int storeRating, string content) {

        Name = name;
        From = from;
        Genre = genre;
        StoreRating = storeRating;
        Content = content;
        Category = MailCategory.Inbox;
        Subgenres = subgenres;

        float accRatio = (float)storeRating / 5f;
        float lowerBound = accRatio - 0.2f;

        Ratings.Add("SaqueCritic", ((int)System.Math.Round(UnityEngine.Random.Range(lowerBound, accRatio) * Universe.critics["SaqueCritic"], 0),  Universe.critics["SaqueCritic"]));
        Ratings.Add("PDPE", ((int)System.Math.Round(UnityEngine.Random.Range(lowerBound, accRatio) * Universe.critics["PDPE"], 0), Universe.critics["PDPE"]));
        Ratings.Add("Game Location", ((int)System.Math.Round(UnityEngine.Random.Range(lowerBound, accRatio) * Universe.critics["Game Location"], 0), Universe.critics["Game Location"]));
        Ratings.Add("Green Mesa", ((int)System.Math.Round(UnityEngine.Random.Range(lowerBound, accRatio) * Universe.critics["Green Mesa"], 0), Universe.critics["Green Mesa"]));
    }

    public static Mail GenerateMail() {

        string title = "New Mail";
        string from = Universe.usernames[Random.Range(0, Universe.usernames.Length)] + "@" + Universe.domains[Random.Range(0, Universe.domains.Length)];

        string[] uGenresCopy = (string[])Universe.genres.Clone();
        int genreIndex = Random.Range(0, Universe.genres.Length);
        string genre = uGenresCopy[genreIndex];
        
        uGenresCopy = uGenresCopy.Where((val, idx) => idx != genreIndex).ToArray();
        int subgenresAmount = Random.Range(2, 5);
        string[] subgenres = new string[subgenresAmount];

        for (int i = 0; i < subgenresAmount; i++) {
            int index = Random.Range(0, uGenresCopy.Length);
            subgenres[i] = uGenresCopy[index];
            uGenresCopy = uGenresCopy.Where((val, idx) => idx != index).ToArray();
        }

        int ratingRange = Random.Range(1, 101);
        int storeRating = ratingRange > 80 ? 5 : ratingRange > 40 ? 4 : ratingRange > 15 ? 3 : 2;
        int rating = Random.Range(1, 6);
        string description = "New Description";

        return new Mail(title, from, genre, subgenres, rating, description);
    }
}
