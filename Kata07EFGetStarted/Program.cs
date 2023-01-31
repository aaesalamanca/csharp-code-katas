using Kata07EFGetStarted;

using BloggingContext context = new();

Console.WriteLine($"Database path: {context.DbPath}.");

Console.WriteLine("Inserting a new blog.");
context.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
context.SaveChanges();

Console.ReadLine();

Console.WriteLine("Querying for a blog.");
Blog selectedBlog = (from blog in context.Blogs orderby blog.BlogId select blog).First();
Console.WriteLine($"Blog ID: {selectedBlog.BlogId} - Url: {selectedBlog.Url}");

Console.WriteLine("Updating the blog and adding a post.");
selectedBlog.Url = "https://devblogs.microsoft.com/dotnet";
selectedBlog.Posts.Add(
    new Post { Title = "Hello, World!", Content = "I wrote an app using EF Core!" }
);
context.SaveChanges();

Console.ReadLine();

Post post = selectedBlog.Posts.First();
Console.WriteLine($"Blog ID: {selectedBlog.BlogId} - Url: {selectedBlog.Url}");
Console.WriteLine(
    $"\tPost ID: {post.PostId} - Blog ID: {post.BlogId} - Title: {post.Title} - Content: {post.Content}"
);

Console.WriteLine("Delete the blog");
context.Remove(selectedBlog);
context.SaveChanges();
