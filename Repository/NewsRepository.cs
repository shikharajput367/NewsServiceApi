using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository
{
    /// <summary>
    /// Provides data access operations for news articles and their sources.
    /// </summary>
    public class NewsRepository : INewsRepository
    {
        private readonly NewsDbContext _context;

        public NewsRepository(NewsDbContext context)
        {
            _context = context;
        }

        public async Task SaveArticlesAsync(List<Article> articles)
        {
            foreach (var article in articles)
            {
                var existingSource = await _context.Sources
                    .FirstOrDefaultAsync(s => s.SourceId == article.Source.SourceId);

                if (existingSource != null)
                {
                    article.SourceId = existingSource.Id;
                }
                else
                {
                    await _context.Sources.AddAsync(article.Source);
                    await _context.SaveChangesAsync();
                }

                var existingArticle = await _context.Articles
                    .FirstOrDefaultAsync(a => a.Url == article.Url);

                if (existingArticle == null)
                {
                    await _context.Articles.AddAsync(article);
                }
                else
                {
                    existingArticle.Author = article.Author;
                    existingArticle.Title = article.Title;
                    existingArticle.Description = article.Description;
                    existingArticle.UrlToImage = article.UrlToImage;
                    existingArticle.PublishedAt = article.PublishedAt;
                    existingArticle.Content = article.Content;
                    existingArticle.SourceId = article.SourceId;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
