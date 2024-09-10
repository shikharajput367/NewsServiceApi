namespace Abstractions.DTOs
{
    /// <summary>
    /// Data Transfer Object representing the response for an article request.
    /// </summary>
    public class ArticleResponseDto
    {
        /// <summary>
        /// Gets or sets the status of the response, e.g., "ok" or "error".
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the total number of articles available in the response.
        /// </summary>
        public int TotalResults { get; set; }

        /// <summary>
        /// Gets or sets the list of articles returned in the response.
        /// </summary>
        public List<ArticleDto> Articles { get; set; }
    }
}
