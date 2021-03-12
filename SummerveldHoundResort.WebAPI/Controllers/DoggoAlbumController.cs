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
    public class DoggoAlbumController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public DoggoAlbumController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(DoggoAlbum doggoAlbum)
        {
            var data = await unitOfWork.DoggoAlbums.Create(doggoAlbum);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.DoggoAlbums.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.DoggoAlbums.GetById(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(DoggoAlbum doggoAlbum)
        {
            var data = await unitOfWork.DoggoAlbums.Update(doggoAlbum);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.DoggoAlbums.Delete(id);
            return Ok(data);
        }
    }
}
