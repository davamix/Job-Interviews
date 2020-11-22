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
    public class CountryService : IDataService<Country>
    {
        private readonly CountryContext _context;

        public CountryService(CountryContext countryContext)
        {
            _context = countryContext;
        }

        public async Task<IEnumerable<Country>> GetAll() => await _context.Countries.ToListAsync() ;//.AsNoTracking().ToListAsync();

        public async Task<Country> Get(int id) => await _context.Countries.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Country> Create(Country entity)
        {
            var country = _context.Countries.Add(entity);
            await _context.SaveChangesAsync();

            return country.Entity;
        }

        public async Task<Country> Update(int id, Country entity)
        {
            var country = await _context.Countries.FirstAsync(x => x.Id == id);

            await _context.SaveChangesAsync();

            return country;
        }

        public async Task<bool> Delete(int id)
        {
            var country = await _context.Countries.FirstAsync(x => x.Id == id);
            _context.Countries.Remove(country);

            var state = await _context.SaveChangesAsync();

            return state > 0;
        }
    }
}
