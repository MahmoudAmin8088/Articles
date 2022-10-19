using Article.core.IUnitOfWork;
using Article.core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Article.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatigoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CatigoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Catagory>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetAll()
        {
            var catagory = _unitOfWork.Catagorys.GetAll();
            if (catagory is null)
                return NotFound();
            return Ok(catagory);

            
        }
    }
}
