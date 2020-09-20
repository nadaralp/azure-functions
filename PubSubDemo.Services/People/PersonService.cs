using Microsoft.EntityFrameworkCore;
using PubSubDemo.Core.Entities;
using PubSubDemo.Core.Services;
using PubSubDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PubSubDemo.Services.People
{
    public class PersonService : IPersonService
    {
        private readonly PeopleDbContext _context;
        private readonly DbSet<Person> _people;

        public PersonService(PeopleDbContext context)
        {
            _context = context;
            _people = context.People;
        }


        public async Task<bool> Add(Person person)
        {
            try
            {
                if (person.RegisterDare.Ticks == 0)
                    person.RegisterDare = DateTime.Now;

                await _people.AddAsync(person);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(DbUpdateException)
            {
                return false;
            }
        }

        public async Task<Person> FirstOrDefault(Expression<Func<Person, bool>> predicateExpression)
        {
            return await _people.FirstOrDefaultAsync(predicateExpression);
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _people.ToListAsync();
        }
    }
}
