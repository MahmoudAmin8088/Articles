using Article.core.IRepository;
using Article.core.Model;
using Article.Ef.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Article.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _auth;
        private readonly IMapper _mapper;
        public AuthController(IAuthRepository auth ,IMapper mapper)
        {
            _auth = auth;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(AuthModel))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _auth.RegisterAsync(model);

            if (!result.IsAuthentication)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(AuthModel))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _auth.LoginAsync(model);

            if (!result.IsAuthentication)
                return BadRequest(result.Message);

            return Ok(result);

        }
    }
}
