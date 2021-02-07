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
    public class DoggoController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public DoggoController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(Doggo doggo)
        {
            var data = await unitOfWork.Doggos.Create(doggo);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data =  await unitOfWork.Doggos.GetAll();
            return Ok (data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Doggos.GetById(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Doggo doggo)
        {
            var data = await unitOfWork.Doggos.Update(doggo);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Doggos.Delete(id);
            return Ok(data);
        }
    }
}
