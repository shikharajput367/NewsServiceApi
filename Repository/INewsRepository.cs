using Repository.Models;

namespace Repository
{
    /// <summary>
    /// Defines the contract for news-related data operations, including saving articles.
    /// </summary>
    public interface INewsRepository
    {
        /// <summary>
        /// Saves a list of articles to the database.
        /// </summary>
        /// <param name="articles">A list of articles to be saved.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SaveArticlesAsync(List<Article> articles);
    }
}