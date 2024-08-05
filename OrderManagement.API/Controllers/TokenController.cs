using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Core.Helpers;

namespace OrderManagement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TokenController(ITokenService tokenService, ILogger<TokenController> logger) : ControllerBase
    {
        private readonly ITokenService _tokenService = tokenService;
        private readonly ILogger _logger = logger;

        [HttpGet()]
        public IActionResult GenerateToken()
        {
            _logger.LogInformation("================= GET /Token ==================");
            return Ok(new { Token = _tokenService.GenerateToken() });
        }
    }
}
