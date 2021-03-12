using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SummerveldHoundResort.Infrastructure.Interfaces;
using SummerveldHoundResort.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerveldHoundResort.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifeEventController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public LifeEventController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(LifeEvent lifeEvent)
        {
            var data = await unitOfWork.LifeEvents.Create(lifeEvent);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.LifeEvents.GetAll();
            return Ok(data);
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.LifeEvents.GetById(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpGet]
        [Route("getDoggoById")]
        public async Task<IActionResult> GetLifeEventById(int doggoId)
        {
            var data = await unitOfWork.LifeEvents.GetLifeEventById(doggoId);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(LifeEvent lifeEvent)
        {
            var data = await unitOfWork.LifeEvents.Update(lifeEvent);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.LifeEvents.Delete(id);
            return Ok(data);
        }
    }
}
