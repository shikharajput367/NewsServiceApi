using Abstractions.DTOs;

namespace Business
{
    /// <summary>
    /// Defines the contract for news-related operations, including fetching and storing articles.
    /// </summary>
    public interface INewsService
    {
        /// <summary>
        /// Fetches articles from an external source and stores them in the system.
        /// </summary>
        /// <returns>An <see cref="ArticleResponseDto"/> containing the fetched articles.</returns>
        Task<ArticleResponseDto> FetchAndStoreArticlesAsync();
    }
}
