using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.API.ViewModels;
using OrderManagement.Application.Dtos;
using OrderManagement.Application.Interfaces;

namespace OrderManagement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController(IClienteService clienteService, ILogger<ClienteController> logger) : ControllerBase
    {
        private readonly IClienteService _clienteService = clienteService;
        private readonly ILogger _logger = logger;

        [HttpGet()]
        public async Task<IActionResult> GetAllClientes()
        {
            _logger.LogInformation("================= GET /Cliente ==================");
            return Ok(await _clienteService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            _logger.LogInformation($"================= GET BY ID /Cliente/id = {id} ==================");
            var cliente = await _clienteService.GetByIdAsync(id);

            if (cliente is null)
            {
                _logger.LogInformation($"================= GET BY ID /Cliente/id = {id} NOT FOUND ==================");
                return NotFound();
            }
                

            return Ok(cliente);
        }

        [HttpPost()]
        public async Task<IActionResult> Create(ClienteDto clienteDto)
        {
            _logger.LogInformation("================= POST /Cliente ==================");

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("================= POST /Cliente MODELSTATE INVALID ==================");
                return BadRequest(ModelState.GetErrors());
            }

            try
            {
                var result = await _clienteService.CreateAsync(clienteDto);
                return CreatedAtAction(nameof(GetClienteById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"================= POST /Cliente ERROR: {ex.Message} ==================");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Update(ClienteDto clienteDto)
        {
            _logger.LogInformation("================= PUT /Cliente ==================");

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("================= PUT /Cliente MODELSTATE INVALID ==================");
                return BadRequest(ModelState.GetErrors());
            }

            try
            {
                var result = await _clienteService.UpdateAsync(clienteDto);

                if (result is null)
                {
                    _logger.LogInformation($"================= PUT /Cliente NOT FOUND ==================");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"================= PUT /Cliente ERROR: {ex.Message} ==================");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete(ClienteDto clienteDto)
        {
            _logger.LogInformation("================= DELETE /Cliente ==================");

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("================= DELETE /Cliente MODELSTATE INVALID ==================");
                return BadRequest(ModelState.GetErrors());
            }

            try
            {
                var result = await _clienteService.RemoveAsync(clienteDto);

                if (result is null)
                {
                    _logger.LogInformation($"================= DELETE /Cliente NOT FOUND ==================");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"================= DELETE /Cliente ERROR: {ex.Message} ==================");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            _logger.LogInformation($"================= DELETE /Cliente/id = {id} ==================");

            try
            {
                var result = await _clienteService.RemoveByIdAsync(id);

                if (result is null)
                {
                    _logger.LogInformation($"================= DELETE /Cliente/id = {id} NOT FOUND ==================");
                    return NotFound();
                }
                    
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"================= DELETE /Cliente/id = {id} ERROR: {ex.Message} ==================");
                return BadRequest(ex.Message);
            }
        }
    }
}
