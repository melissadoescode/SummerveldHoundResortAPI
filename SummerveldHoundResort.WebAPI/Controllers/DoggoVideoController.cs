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
    public class DoggoVideoController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public DoggoVideoController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(DoggoVideo doggoVideo)
        {
            var data = await unitOfWork.DoggoVideos.Create(doggoVideo);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.DoggoVideos.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.DoggoVideos.GetById(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(DoggoVideo doggoVideo)
        {
            var data = await unitOfWork.DoggoVideos.Update(doggoVideo);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.DoggoVideos.Delete(id);
            return Ok(data);
        }
    }
}
