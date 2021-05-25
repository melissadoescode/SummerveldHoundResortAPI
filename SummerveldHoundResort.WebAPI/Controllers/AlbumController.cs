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
    public class AlbumController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public AlbumController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(Album doggoAlbum)
        {
            var data = await unitOfWork.Albums.Create(doggoAlbum);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Albums.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Albums.GetById(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Album doggoAlbum)
        {
            var data = await unitOfWork.Albums.Update(doggoAlbum);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Albums.Delete(id);
            return Ok(data);
        }
    }
}
