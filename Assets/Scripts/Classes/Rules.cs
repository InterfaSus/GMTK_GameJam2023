using System.Linq;

public static class Rules {

    // Checks if rating is at least some value
    public static bool Rating(Mail mail, int threshold) {

        return mail.StoreRating >= threshold;
    }

    // Given a list of domains, checks if the mail is from one of them
    public static bool FromValid(Mail mail, string[] domains) {

        return domains.Any(domain => mail.From.EndsWith(domain));
    }

    // Given a list of domains, checks if the mail is not from one of them
    public static bool FromNeither(Mail mail, string[] domains) {
            
        return !domains.Any(domain => mail.From.EndsWith(domain));
    }

    // Given a list of genres, checks if the mail is from one of them
    public static bool GenreValid(Mail mail, string[] genres) {

        return genres.Any(genre => mail.Genre == genre);
    }

    // Given a list of genres, checks if the mail is not from one of them
    public static bool GenreNeither(Mail mail, string[] genres) {

        return !genres.Any(genre => mail.Genre == genre);
    }
}

