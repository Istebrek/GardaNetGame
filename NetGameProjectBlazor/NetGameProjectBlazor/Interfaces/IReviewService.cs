using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Interfaces;

public interface IReviewService
{
    Task<ReviewDto?> NewReview(ReviewDto review);
    Task<IEnumerable<ReviewDto?>> GetReviewByCustomerId(string customerId);
    Task<IEnumerable<ReviewDto?>> GetReviewByProductId(int productId);
}
