using Microsoft.AspNetCore.Mvc;
using NetGameProjectBlazor.Interfaces;
using NetGameProjectBlazor.Services;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Controllers;

[ApiController]
[Route("api/review")]

public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService 
            ?? throw new ArgumentNullException(nameof(reviewService));
    }

    [HttpGet("get/{customerId}")]
    public ActionResult<IEnumerable<ReviewDto>> GetReviewByCustomerId(string customerId)
    {
        var reviews = _reviewService.GetReviewByCustomerId(customerId);

        return (reviews is null)
            ? NotFound("Customer has no reviews")
            : Ok(reviews);
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviewByProductId(int productId)
    {
        var reviews = await _reviewService.GetReviewByProductId(productId);

        return (reviews is null)
            ? NotFound("Product has no reviews")
            : Ok(reviews);
    }

    [HttpPost("{Review}")]
    public async Task<ActionResult> NewReview(ReviewDto review)
    {
        var newreview = await _reviewService.NewReview(review);
        return (newreview is null)
            ? StatusCode(500)
            : Ok(newreview);
    }
}
