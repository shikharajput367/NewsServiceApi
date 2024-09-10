using AutoMapper;
using Repository;
using Repository.Models;
using Abstractions.DTOs;
using System.Net.Http.Json;

namespace Business
{
    /// <summary>
    /// Service for fetching articles from an external API and storing them in the system.
    /// </summary>
    public class NewsService : INewsService
    {
        private readonly HttpClient _httpClient;
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsService"/> class.
        /// </summary>
        /// <param name="httpClient">The HttpClient for sending HTTP requests.</param>
        /// <param name="articleRepository">The repository for storing articles.</param>
        /// <param name="mapper">The AutoMapper instance for mapping DTOs to entities.</param>
        public NewsService(HttpClient httpClient, INewsRepository articleRepository, IMapper mapper)
        {
            _httpClient = httpClient;
            _newsRepository = articleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Fetches articles from an external API and stores them in the database.
        /// </summary>
        /// <returns>An <see cref="ArticleResponseDto"/> containing the fetched articles.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request to the external API fails.</exception>
        /// <exception cref="Exception">Thrown when the API response is invalid or no articles are found.</exception>
        public async Task<ArticleResponseDto> FetchAndStoreArticlesAsync()
        {
            Uri uri = new Uri("https://newsapi.org/v2/top-headlines?country=us&apiKey=24393c01574747789a66f9072deb69f8");
            var response = await _httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to fetch articles: {response.ReasonPhrase}");
            }

            var apiResponse = await response.Content.ReadFromJsonAsync<ArticleResponseDto>();

            if (apiResponse == null || apiResponse.Articles == null || !apiResponse.Articles.Any())
            {
                throw new Exception("Invalid API response or no articles found");
            }

            // Map the ArticleDto list from the API response to the Article entity list
            var articlesToSave = _mapper.Map<List<Article>>(apiResponse.Articles);

            // Save the mapped articles to the database
            await _newsRepository.SaveArticlesAsync(articlesToSave);

            return apiResponse;
        }
    }
}
