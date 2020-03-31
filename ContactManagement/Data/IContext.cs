using System.Threading.Tasks;
using ContactManagement.Entities;

namespace ContactManagement.Data
{
    public interface IContext
    {
        Task<Company> CreateCompany(Company company);
        Task<Company> FindCompany(int id);
        Task<Company> UpdateCompany(Company company);
        Task<Contact> CreateContact(Contact contact);
        Task<Contact> FindContact(int id);
        Task<Contact> UpdateContact(Contact contact);
        Task DeleteContact(Contact contact);
    }
}