using AutoMapper;
using E_commerce.Application.Dtos;
using E_commerce.Domain.Entities;

namespace E_commerce.Api.Helper
{
    public class ImageResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _configuration;

        public ImageResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)

        {
            if (!string.IsNullOrEmpty(source.Image))
                return $"{_configuration["ApiBaseUrl"]}{source.Image}";

            return string.Empty;
        }
    }
}
