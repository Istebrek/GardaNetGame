
using Microsoft.EntityFrameworkCore;
using NetGameProjectBlazor.Context;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Interfaces;

namespace NetGameProjectBlazor.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly GardaNetGameContext _context;

    public ReviewRepository(GardaNetGameContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task NewReviewAsync(Review review)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Review?>> GetReviewByCustomerIdAsync(string customerId)
    {
        return await _context.Reviews
            .Where(r => r.CustomerId == customerId).ToListAsync();
    }

    public async Task<IEnumerable<Review?>> GetReviewByProductIdAsync(int productId)
    {
        return await _context.Reviews
            .Where(r => r.ProductId == productId).ToListAsync();
    }
}
