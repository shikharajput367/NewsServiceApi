using Abstractions.DTOs;
using AutoMapper;
using Repository.Models;

namespace Business.Mapper
{
    /// <summary>
    /// AutoMapper profile for mapping between article-related entities and DTOs.
    /// </summary>
    public class ArticleProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleProfile"/> class.
        /// Configures mappings between entity models and their corresponding DTOs.
        /// </summary>
        public ArticleProfile()
        {
            // Map Article to ArticleDto and vice versa
            CreateMap<Article, ArticleDto>()
                .ForMember(dest => dest.Source, opt => opt.MapFrom(src => src.Source));

            CreateMap<Source, SourceDto>();

            // Reverse mapping if needed
            CreateMap<ArticleDto, Article>()
                .ForMember(dest => dest.Source, opt => opt.MapFrom(src => src.Source));

            CreateMap<SourceDto, Source>();

            // Map ArticleResponseDto to ArticleResponse
            CreateMap<ArticleResponseDto, ArticleResponse>()
                .ForMember(dest => dest.Articles, opt => opt.MapFrom(src => src.Articles));

            // Map ArticleResponse to ArticleResponseDto
            CreateMap<ArticleResponse, ArticleResponseDto>()
                .ForMember(dest => dest.Articles, opt => opt.MapFrom(src => src.Articles));
        }
    }
}
