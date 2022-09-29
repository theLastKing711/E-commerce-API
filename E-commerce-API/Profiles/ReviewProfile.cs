using AutoMapper;
using ECommerce.API.Dtos;
using ECommerce.API.Dtos.AppUserDtos.Review;
using ECommerce.API.Dtos.Review;
using ECommerce.API.Models;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {

        CreateMap<ReviewDto, Review>();
        CreateMap<Review, ReviewDto>();
        CreateMap<Review, AddReviewDto>();
        CreateMap<AddReviewDto, Review>();

    }
}