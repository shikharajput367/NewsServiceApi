using Abstractions.DTOs;
using API.Controllers;
using Business;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class NewsControllerTests
{
    private readonly Mock<INewsService> _newsServiceMock;
    private readonly NewsController _newsController;

    public NewsControllerTests()
    {
        // Arrange: Initialize the mock service and the controller
        _newsServiceMock = new Mock<INewsService>();
        _newsController = new NewsController(_newsServiceMock.Object);
    }

    // Happy Flow: Should return OK with articles
    [Fact]
    public async Task FetchAndStoreArticles_ReturnsOkResult_WithArticles()
    {
        // Arrange: Mock the service to return some articles
        var articles = new List<ArticleDto>
        {
            new ArticleDto { Title = "Article 1", Author = "Author 1" },
            new ArticleDto { Title = "Article 2", Author = "Author 2" }
        };

        var articleResponse = new ArticleResponseDto
        {
            Status = "ok",
            TotalResults = articles.Count,
            Articles = articles
        };

        _newsServiceMock.Setup(service => service.FetchAndStoreArticlesAsync())
            .ReturnsAsync(articleResponse);

        // Act: Call the controller method
        var result = await _newsController.FetchAndStoreArticles();

        // Assert: Validate that the result is OkObjectResult and has the correct data
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ArticleResponseDto>(okResult.Value);
        Assert.Equal("ok", response.Status);
        Assert.Equal(2, response.Articles.Count);
    }

    // Bad Request Flow: Should return BadRequest if ArgumentException is thrown
    [Fact]
    public async Task FetchAndStoreArticles_ReturnsBadRequest_OnArgumentException()
    {
        // Arrange
        _newsServiceMock.Setup(service => service.FetchAndStoreArticlesAsync())
            .ThrowsAsync(new ArgumentException("Invalid request"));

        // Act
        var result = await _newsController.FetchAndStoreArticles();

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);

        // Access the anonymous object response
        var response = badRequestResult.Value;

        // Assert: Compare the values directly if possible
        Assert.NotNull(response);

        // We can access it as a JSON-like object if necessary or via reflection
        Assert.Contains("Invalid request", response.ToString());
    }
}
