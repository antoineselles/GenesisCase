using System.Linq;
using System.Threading.Tasks;
using ContactManagement.Contracts;
using ContactManagement.Data;
using ContactManagement.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.Controllers
{
    [Route("contacts")]
    public class ContactController : Controller
    {
        private readonly IContext _context;

        public ContactController(IContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetContact(int id)
        {
            var contact = await _context.FindContact(id);

            if (contact == default) return new NotFoundResult();

            return new JsonResult(MapToResponse(contact));
        }

        [HttpPost]
        public async Task<ActionResult> CreateContact([FromBody] ContactCreateRequest request)
        {
            var company = await _context.FindCompany(request.CompanyId);

            if (company == default) return new BadRequestResult();

            var contact = new Contact(request.Name, request.Type, request.Address, request.Vat, company);

            var createdContact = await _context.CreateContact(contact);

            return new JsonResult(MapToResponse(createdContact));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContact(int id, [FromBody] ContactUpdateRequest request)
        {
            var contact = await _context.FindContact(id);

            if (contact == default) return new NotFoundResult();

            contact.Update(request.Name, request.Address, request.Type, request.Vat);

            var updatedContact = await _context.UpdateContact(contact);

            return new JsonResult(MapToResponse(updatedContact));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var contact = await _context.FindContact(id);

            if (contact != default)
            {
                await _context.DeleteContact(contact);
            }

            return new NoContentResult();
        }

        private static ContactResponse MapToResponse(Contact value)
        {
            return new ContactResponse
            {
                Id = value.Id,
                Name = value.Name,
                Address = value.Address,
                Type = value.Type,
                Vat = value.Vat,
                Companies = value.Companies.Select(c => new CompanyResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Vat = c.Vat,
                    Addresses = c.Addresses.Select(a => new CompanyAddressResponse
                    {
                        Id = a.Id,
                        Value = a.Value,
                        IsHQ = a.IsHQ
                    })
                })
            };
        }
    }
}