using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SteelLiquid.Entity.MTG;

namespace SteelLiquid.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Contacts")]
    public class ContactsController : Controller
    {
        private readonly ILogger _logger;
        private readonly IContact _ContactsRepo;

        public ContactsController(IContacts ContactsRepo, ILogger<ContactsController> logger)
        {
            _ContactsRepo = ContactsRepo;
            _logger = logger;
        }

        // GET: api/Contacts
        [HttpGet]
        public IEnumerable<Contacts> SelectAllAsync()
        {
            var data = _ContactsRepo.SelectAllAsync().Result
                .Where(x=> x.IsDeleted == false);
            return data;
        }

        // GET: api/Contacts/5
        [HttpGet("{id}", Name = "Get")]
        public Task<IEnumerable<Contacts>> ReadAsync(int id)
        {
            return _ContactsRepo.ReadAsync(id);
        }

        // POST: api/Contacts
        [HttpPost]
        public void Update(Contacts card)
        {
            _ContactsRepo.UpdateAsync(card);
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public void Insert(Contacts card)
        {
            _ContactsRepo.InsertAsync(card);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ContactsRepo.DeleteAsync(id);
        }
    }
}
