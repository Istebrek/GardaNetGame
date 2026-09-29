using AutoMapper;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Interfaces;
using NetGameProjectBlazor.Repository;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Services;


public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;

    private readonly IUserService _userService;
    private readonly IGamesService _gameService;
    private readonly IPhysicalProductService _productService;

    public ReviewService(IReviewRepository reviewRepository,
    IMapper mapper)
    {
        _reviewRepository = reviewRepository
            ?? throw new ArgumentNullException(nameof(reviewRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<ReviewDto?>> GetReviewByCustomerId(string customerId)
    {
        var reviews = await _reviewRepository.GetReviewByCustomerIdAsync(customerId);
        return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
    }

    public async Task<IEnumerable<ReviewDto?>> GetReviewByProductId(int productId)
    {
        var reviews = await _reviewRepository.GetReviewByProductIdAsync(productId);
        return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
    }

    public async Task<ReviewDto?> NewReview(ReviewDto review)
    {
        var newReview = _mapper.Map<Review>(review);

        if(review.CustomerId != null && review.ProductId != null)
        {
            var customerExist = await _userService.GetUserAsync(review.CustomerId ?? "0");
            var productExist = await _productService.GetPhysicalProducAsync((int)review.ProductId);
            var gameExist = await _gameService.GetGameDetailsAsync((int)review.ProductId);

            if (customerExist != null && productExist != null || gameExist != null)
            {
                await _reviewRepository.NewReviewAsync(newReview);
                return _mapper.Map<ReviewDto>(newReview);
            }

        }
        return null;
    }
}
