using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Manager.Infra.Interfaces;
using Manager.Infra.Context;
using Microsoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base;
        private readonly ManagerContext _context;

        public BaseRepository(ManagerContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangeAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangeAsync();

            return obj;
        }

        public virtual async Task Remove(long id)
        {
            var obj = await Get(id);

            if(obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangeAsync();
            }
        }

        public virtual async Task Get(long id)
        {
            var obj = await _context.Ser<T>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async Task<List<T>> GetTask()
        {
            return await _context.Set<T>()
                    .AsNoTracking()
                    .ToListAsync();
        }
}