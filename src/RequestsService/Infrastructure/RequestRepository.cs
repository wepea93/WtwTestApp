using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RequestsService.Infrastructure;

public class RequestRepository(RequestDbContext context) : Repository<RequestsService.Core.Request>(context)
{
    public async Task<IEnumerable<RequestsService.Core.Request>> GetFilteredAsync(Expression<Func<RequestsService.Core.Request, bool>> filter)
    {
        return await _dbSet.Where(filter).ToListAsync();
    }
}
