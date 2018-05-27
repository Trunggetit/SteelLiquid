using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SteelLiquid.Entity.eBay;

namespace SteelLiquid.API.Controllers
{
    [Produces("application/json")]
    [Route("api/MTGCard")]
    public class TasksController : Controller
    {
        private readonly ILogger _logger;
        private readonly ITask _TaskRepo;

        public TasksController(ITask TaskRepo, ILogger<TasksController> logger)
        {
            _TaskRepo = TaskRepo;
            _logger = logger;
        }

        // GET: api/MTGCard
        //[HttpGet]
        //public IEnumerable<Tasks> SelectAllAsync()
        //{
        //    return 
        //    //var data = _TaskRepo.SelectAllAsync().Result
        //    //    .Where(x=> x.IsDeleted == false);
        //    //return data;
        //}

        //// GET: api/MTGCard/5
        //[HttpGet("{id}", Name = "Get")]
        //public Task<IEnumerable<Task>> ReadAsync(int id)
        //{
        //    return _TaskRepo.ReadAsync(id);
        //}

        //// POST: api/MTGCard
        //[HttpPost]
        //public void Update(Task card)
        //{
        //    _TaskRepo.UpdateAsync(card);
        //}

        //// PUT: api/MTGCard/5
        //[HttpPut("{id}")]
        //public void Insert(Task card)
        //{
        //    _TaskRepo.InsertAsync(card);
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    _TaskRepo.DeleteAsync(id);
        //}
    }
}
