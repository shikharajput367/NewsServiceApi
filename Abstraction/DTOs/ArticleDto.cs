namespace Abstractions.DTOs
{
    /// <summary>
    /// Data Transfer Object representing an article.
    /// </summary>
    public class ArticleDto
    {
        /// <summary>
        /// Gets or sets the author of the article.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the title of the article.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the article.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the URL of the article.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the URL of the image associated with the article.
        /// </summary>
        public string UrlToImage { get; set; }

        /// <summary>
        /// Gets or sets the date and time the article was published.
        /// </summary>
        public DateTime PublishedAt { get; set; }

        /// <summary>
        /// Gets or sets the content of the article.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the source information for the article.
        /// </summary>
        public SourceDto Source { get; set; }
    }
}
