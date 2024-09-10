using Microsoft.AspNetCore.Mvc;
using Business;

namespace API.Controllers
{
    /// <summary>
    /// Controller responsible for managing news-related operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        /// <summary>
        /// Fetches and stores articles from an external source.
        /// </summary>
        /// <returns>An action result with a success or error status code.</returns>
        [HttpPost("fetch-and-store")]
        public async Task<IActionResult> FetchAndStoreArticles()
        {
            try
            {
                var response = await _newsService.FetchAndStoreArticlesAsync();

                if (response == null || !response.Articles.Any())
                {
                    return NotFound(new { message = "No articles found or fetched" });
                }

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = "Invalid request", detail = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred", detail = ex.Message });
            }
        }
    }
}
