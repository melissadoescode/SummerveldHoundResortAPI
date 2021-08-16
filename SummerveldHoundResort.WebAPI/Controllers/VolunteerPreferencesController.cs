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
    public class VolunteerPreferencesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public VolunteerPreferencesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(VolunteerPreferences volunteerPreferences)
        {
            var data = await unitOfWork.VolunteerPreferences.Create(volunteerPreferences);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.VolunteerPreferences.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.VolunteerPreferences.GetById(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(VolunteerPreferences volunteerPreferences)
        {
            var data = await unitOfWork.VolunteerPreferences.Update(volunteerPreferences);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.VolunteerPreferences.Delete(id);
            return Ok(data);
        }
    }
}
