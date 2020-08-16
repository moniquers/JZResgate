using JZResgate.Domain.Models;
using JZResgate.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace JZResgate.Infra.Data.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
    }
}
