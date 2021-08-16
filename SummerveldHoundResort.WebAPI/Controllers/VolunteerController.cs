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
    public class VolunteerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public VolunteerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(Volunteer volunteer)
        {
            var data = await unitOfWork.Volunteer.Create(volunteer);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Volunteer.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Volunteer.GetById(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        //[HttpGet]
        //[Route("getAlbumByDoggoId")]
        //public async Task<IActionResult> GetAlbumById(int doggoId)
        //{
        //    var data = await unitOfWork.Albums.GetByDoggoId(doggoId);
        //    if (data == null) return Ok();
        //    return Ok(data);
        //}

        [HttpPut]
        public async Task<IActionResult> Update(Volunteer volunteer)
        {
            var data = await unitOfWork.Volunteer.Update(volunteer);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Volunteer.Delete(id);
            return Ok(data);
        }
    }
}
