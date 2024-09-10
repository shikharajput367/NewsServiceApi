using System;

namespace Repository.Models
{
    /// <summary>
    /// Represents an article entity in the database.
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Gets or sets the primary key for the article.
        /// </summary>
        public int Id { get; set; }

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
        /// Gets or sets the URL to the image associated with the article.
        /// </summary>
        public string UrlToImage { get; set; }

        /// <summary>
        /// Gets or sets the publication date and time of the article.
        /// </summary>
        public DateTime PublishedAt { get; set; }

        /// <summary>
        /// Gets or sets the content of the article.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the foreign key reference to the source of the article.
        /// </summary>
        public int SourceId { get; set; }

        /// <summary>
        /// Gets or sets the source of the article.
        /// </summary>
        public Source Source { get; set; }
    }
}
