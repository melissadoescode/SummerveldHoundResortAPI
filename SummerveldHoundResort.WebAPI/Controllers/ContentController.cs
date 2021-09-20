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
    public class ContentController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ContentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(Content doggoContent)
        {
            var data = await unitOfWork.Contents.Create(doggoContent);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Contents.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Contents.GetById(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpGet]
        [Route("getContentByDoggoId")]
        public async Task<IActionResult> GetContentByDoggoId(int doggoId)
        {
            var data = await unitOfWork.Contents.GetByDoggoId(doggoId);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Content content)
        {
            var data = await unitOfWork.Contents.Update(content);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Contents.Delete(id);
            return Ok(data);
        }
    }
}
