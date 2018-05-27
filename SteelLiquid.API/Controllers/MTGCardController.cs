﻿using System;
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
        private readonly Tasks _TasksRepo;

        public MTGCardController(ITasks TasksRepo, ILogger<MTGCardController> logger)
        {
            _TasksRepo = TasksRepo;
            _logger = logger;
        }

        // GET: api/MTGCard
        [HttpGet]
        public IEnumerable<Tasks> SelectAllAsync()
        {
            var data = _TasksRepo.SelectAllAsync().Result
                .Where(x=> x.IsDeleted == false);
            return data;
        }

        // GET: api/MTGCard/5
        [HttpGet("{id}", Name = "Get")]
        public Task<IEnumerable<Tasks>> ReadAsync(int id)
        {
            return _TasksRepo.ReadAsync(id);
        }

        // POST: api/MTGCard
        [HttpPost]
        public void Update(Tasks card)
        {
            _TasksRepo.UpdateAsync(card);
        }

        // PUT: api/MTGCard/5
        [HttpPut("{id}")]
        public void Insert(Tasks card)
        {
            _TasksRepo.InsertAsync(card);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _TasksRepo.DeleteAsync(id);
        }
    }
}
