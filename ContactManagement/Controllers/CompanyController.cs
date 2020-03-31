using System.Linq;
using System.Threading.Tasks;
using ContactManagement.Contracts;
using ContactManagement.Data;
using ContactManagement.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.Controllers
{
    [Route("companies")]
    public class CompanyController
    {
        private readonly IContext _context;

        public CompanyController(IContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var company = await _context.FindCompany(id);

            if (company == default) return new NotFoundResult();

            return new JsonResult(MapToResponse(company));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompany([FromBody] CompanyCreateRequest request)
        {
            var company = new Company(request.Name, request.Address, request.Vat);

            var createdCompany = await _context.CreateCompany(company);

            return new JsonResult(MapToResponse(createdCompany));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCompany(int id, [FromBody] CompanyUpdateRequest request)
        {
            var company = await _context.FindCompany(id);

            if (company == default) return new NotFoundResult();

            company.Update(request.Name, request.Vat);

            var updatedCompany = await _context.UpdateCompany(company);

            return new JsonResult(MapToResponse(updatedCompany));
        }

        [HttpPatch("{id}/address")]
        public async Task<ActionResult> AddAddress(int id, [FromBody] CompanyAddressRequest request)
        {
            var company = await _context.FindCompany(id);

            if (company == default) return new NotFoundResult();

            company.AddAddress(request.Value, request.IsHQ);

            var result = await _context.UpdateCompany(company);

            return new JsonResult(MapToResponse(result));
        }

        [HttpPatch("{id}/address/{addressId}")]
        public async Task<ActionResult> UpdateAddress(int id, string addressId, [FromBody] CompanyAddressRequest request)
        {
            var company = await _context.FindCompany(id);

            if (company == default) return new NotFoundResult();

            if (!company.HasAddress(addressId)) return new BadRequestResult();

            company.UpdateAddress(addressId, request.Value, request.IsHQ);

            var result = await _context.UpdateCompany(company);

            return new JsonResult(MapToResponse(result));
        }

        private static CompanyResponse MapToResponse(Company value)
        {
            return new CompanyResponse
            {
                Id = value.Id,
                Name = value.Name,
                Vat = value.Vat,
                Addresses = value.Addresses.Select(a => new CompanyAddressResponse
                {
                    Id = a.Id, IsHQ = a.IsHQ, Value = a.Value
                })
            };
        }
    }
}