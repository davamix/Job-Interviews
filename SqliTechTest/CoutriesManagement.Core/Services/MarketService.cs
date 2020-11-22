using CoutriesManagement.Core.Database;
using CoutriesManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CoutriesManagement.Core.Services
{
    public class MarketService : IDataService<Market>
    {
        private readonly CountryContext _context;

        public MarketService(CountryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Market>> GetAll() => await _context.Markets.ToListAsync();//.AsNoTracking().ToListAsync();
        public async Task<Market> Get(int id) => await _context.Markets.SingleOrDefaultAsync(x => x.Id == id);
        public Task<Market> Create(Market entity) => throw new NotImplementedException();
        public Task<Market> Update(int id, Market entity) => throw new NotImplementedException();
        public Task<bool> Delete(int id) => throw new NotImplementedException();
    }
}
