using System.Threading.Tasks;
using ContactManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Data
{
    public class Context : DbContext, IContext
    {
        private DbSet<Company> Companies { get; set; }
        private DbSet<Contact> Contacts { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().OwnsMany(c => c.Addresses);
        }

        public async Task<Contact> CreateContact(Contact contact)
        {
            var entry = Contacts.Add(contact);
            await SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Contact> FindContact(int id)
        {
            var contact = await Contacts.FindAsync(id);
            return contact;
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            var entry = Contacts.Update(contact);
            if (entry.State == EntityState.Unchanged) return entry.Entity;
            await SaveChangesAsync();
            return entry.Entity;
        }

        public async Task DeleteContact(Contact contact)
        {
            Contacts.Remove(contact);
            await SaveChangesAsync();
        }

        public async Task<Company> CreateCompany(Company company)
        {
            var entry = Companies.Add(company);
            await SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            var entry = Companies.Update(company);
            if (entry.State == EntityState.Unchanged) return entry.Entity;
            await SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Company> FindCompany(int id)
        {
            var company = await Companies.FindAsync(id);
            return company;
        }
    }
}