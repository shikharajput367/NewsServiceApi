namespace Repository.Models
{
    /// <summary>
    /// Represents a source entity in the database.
    /// </summary>
    public class Source
    {
        /// <summary>
        /// Gets or sets the primary key for the source.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the source identifier from the API.
        /// </summary>
        public string SourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the source.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of articles related to this source.
        /// </summary>
        public ICollection<Article> Articles { get; set; }
    }
}
