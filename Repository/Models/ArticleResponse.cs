namespace Repository.Models
{
    /// <summary>
    /// Represents the response containing articles from an external API.
    /// </summary>
    public class ArticleResponse
    {
        /// <summary>
        /// Gets or sets the status of the response.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the total number of articles available in the response.
        /// </summary>
        public int TotalResults { get; set; }

        /// <summary>
        /// Gets or sets the list of articles included in the response.
        /// </summary>
        public List<Article> Articles { get; set; }
    }
}