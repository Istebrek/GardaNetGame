using NetGameProjectBlazor.Entities;

namespace NetGameProjectBlazor.Interfaces;

public interface IReviewRepository
{
    Task NewReviewAsync(Review review);
    Task<IEnumerable<Review?>> GetReviewByCustomerIdAsync(string customerId);
    Task<IEnumerable<Review?>> GetReviewByProductIdAsync(int productId);
}
