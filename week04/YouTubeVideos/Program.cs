using System;
using System.Collections.Generic;

// Comment class
public class Comment
{
    public string Name { get; }
    public string Text { get; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

// Video class
public class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

// Program class
class Program
{
    static void Main(string[] args)
    {
        // Create list of videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Learn C# in 10 Minutes", "CodeWithGifty", 600);
        video1.AddComment(new Comment("Alice", "This was super helpful, thank you!"));
        video1.AddComment(new Comment("Bob", "I love how concise this is."));
        video1.AddComment(new Comment("Charlie", "More videos like this, please!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Micro:bit Projects for Kids", "STEMMinds", 850);
        video2.AddComment(new Comment("Diana", "My students loved this!"));
        video2.AddComment(new Comment("Ethan", "Great resource for teachers."));
        video2.AddComment(new Comment("Fay", "Can you do one on sensors?"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Python for Data Analysis", "DataAcademy", 1200);
        video3.AddComment(new Comment("George", "Clear and well-explained."));
        video3.AddComment(new Comment("Hana", "Perfect for beginners."));
        video3.AddComment(new Comment("Ivan", "Subscribed!"));
        videos.Add(video3);

        // Display all video information
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.Name}: {comment.Text}");
            }

            Console.WriteLine(new string('-', 50)); // Divider
        }
    }
}