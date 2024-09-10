namespace Abstractions.DTOs
{
    /// <summary>
    /// Data Transfer Object representing the source of an article.
    /// </summary>
    public class SourceDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the source.
        /// </summary>
        public string SourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the source.
        /// </summary>
        public string Name { get; set; }
    }
}
