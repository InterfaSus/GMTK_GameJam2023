using System.Linq;

public static class Rules {

    // Checks if rating is at least some value
    public static (bool, string) Rating(Mail mail, int threshold) {

        return (mail.StoreRating >= threshold, "Rating");
    }

    // Given a list of domains, checks if the mail is from one of them
    public static (bool, string) FromValid(Mail mail, string[] domains) {

        return (domains.Any(domain => mail.From.EndsWith(domain)), "Email domain");
    }

    // Given a list of domains, checks if the mail is not from one of them
    public static (bool, string) FromNeither(Mail mail, string[] domains) {
            
        return (!domains.Any(domain => mail.From.EndsWith(domain)), "Email domain");
    }

    // Given a list of genres, checks if the mail is from one of them
    public static (bool, string) GenreValid(Mail mail, string[] genres) {

        return (genres.Any(genre => mail.Genre == genre), "Genre");
    }

    // Given a list of genres, checks if the mail is not from one of them
    public static (bool, string) GenreNeither(Mail mail, string[] genres) {

        return (!genres.Any(genre => mail.Genre == genre), "Genre");
    }

    // Given a list of subgenres, checks if the mail is from one of them
    public static (bool, string) SubgenreValid(Mail mail, string[] subgenres) {

        return (subgenres.Any(subgenre => mail.Subgenres.Contains(subgenre)), "Subgenre");
    }

    // Given a critic and a threshold, check if its rating is at least the threshold
    public static (bool, string) CriticsRating(Mail mail, string critic, int threshold) {

        return (mail.Ratings[critic].Item1 >= threshold, "Critic");
    }

    // Returns false if the mail is spam
    public static (bool, string) NotSpam(Mail mail) {

        return (!mail.IsSpam, "Spam");
    }
}

