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
    [Route("api/MTGCard")]
    public class MTGCardController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICardInventory _CardInventoryRepo;

        public MTGCardController(ICardInventory CardInventoryRepo, ILogger<MTGCardController> logger)
        {
            _CardInventoryRepo = CardInventoryRepo;
            _logger = logger;
        }

        // GET: api/MTGCard
        [HttpGet]
        public IEnumerable<CardInventory> SelectAllAsync()
        {
            var data = _CardInventoryRepo.SelectAllAsync().Result
                .Where(x=> x.IsDeleted == false);
            return data;
        }

        // GET: api/MTGCard/5
        [HttpGet("{id}", Name = "Get")]
        public Task<IEnumerable<CardInventory>> ReadAsync(int id)
        {
            return _CardInventoryRepo.ReadAsync(id);
        }

        // POST: api/MTGCard
        [HttpPost]
        public void Update(CardInventory card)
        {
            _CardInventoryRepo.UpdateAsync(card);
        }

        // PUT: api/MTGCard/5
        [HttpPut("{id}")]
        public void Insert(CardInventory card)
        {
            _CardInventoryRepo.InsertAsync(card);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _CardInventoryRepo.DeleteAsync(id);
        }
    }
}
