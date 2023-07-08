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
    public string Author { get; private set; }
    public string Genre { get; private set; }
    public int Rating { get; private set; }
    public string Content { get; private set; }
    public bool IsValid { get; private set; }
    public MailCategory Category;

    public Mail(string name, string author, string genre, int rating, string content, bool isCorrect) {
        Name = name;
        Author = author;
        Genre = genre;
        Rating = rating;
        Content = content;
        Category = MailCategory.Inbox;
        IsValid = isCorrect;
    }
}
