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
    public class PedidoController(IPedidoService pedidoService, ILogger<PedidoController> logger) : ControllerBase
    {
        private readonly IPedidoService _pedidoService = pedidoService;
        private readonly ILogger _logger = logger;

        [HttpGet()]
        public async Task<IActionResult> GetAllClientes()
        {
            _logger.LogInformation("================= GET /Pedido ==================");
            return Ok(await _pedidoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            _logger.LogInformation($"================= GET BY ID /Pedido/id = {id} ==================");
            var pedido = await _pedidoService.GetByIdAsync(id);

            if (pedido is null)
            {
                _logger.LogInformation($"================= GET BY ID /Pedido/id = {id} NOT FOUND ==================");
                return NotFound();
            }

            return Ok(pedido);
        }

        [HttpGet("frete")]
        public async Task<IActionResult> GetFreteByOrigemAndDestino(string origem, string destino)
        {
            _logger.LogInformation($"================= GET BY ORIGEM + DESTINO /Pedido/frete?origem{origem}&{destino} ==================");
            var pedido = await _pedidoService.GetFreteAsync(origem, destino);

            if (pedido.Data is null)
            {
                _logger.LogInformation($"================= GET BY ORIGEM + DESTINO /Pedido/frete?= {origem} + {destino} NOT FOUND ==================");
                return NotFound(pedido);
            }

            return Ok(pedido);
        }

        [HttpPost()]
        public async Task<IActionResult> Create(PedidoDto pedidoDto)
        {
            _logger.LogInformation("================= POST /Pedido ==================");

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("================= POST /Pedido MODELSTATE INVALID ==================");
                return BadRequest(ModelState.GetErrors());
            }

            try
            {
                var result = await _pedidoService.CreateAsync(pedidoDto);
                return Created(pedidoDto.Id.ToString(), result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"================= POST /Pedido ERROR: {ex.Message} ==================");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Update(PedidoDto pedidoDto)
        {
            _logger.LogInformation("================= PUT /Pedido ==================");

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("================= PUT /Pedido MODELSTATE INVALID ==================");
                return BadRequest(ModelState.GetErrors());
            }

            try
            {
                var result = await _pedidoService.UpdateAsync(pedidoDto);

                if (result is null)
                {
                    _logger.LogInformation($"================= PUT /Pedido NOT FOUND ==================");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"================= PUT /Pedido ERROR: {ex.Message} ==================");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete(PedidoDto pedidoDto)
        {
            _logger.LogInformation("================= DELETE /Pedido ==================");

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("================= DELETE /Pedido MODELSTATE INVALID ==================");
                return BadRequest(ModelState.GetErrors());
            }

            try
            {
                var result = await _pedidoService.RemoveAsync(pedidoDto);

                if(result is null)
                {
                    _logger.LogInformation($"================= DELETE /Pedido NOT FOUND ==================");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"================= DELETE /Pedido ERROR: {ex.Message} ==================");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            _logger.LogInformation($"================= DELETE /Pedido/id = {id} ==================");
  
            try
            {
                var result = await _pedidoService.RemoveByIdAsync(id);

                if (result is null)
                {
                    _logger.LogInformation($"================= DELETE /Pedido/id = {id} NOT FOUND ==================");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"================= DELETE /Pedido/id = {id} ERROR: {ex.Message} ==================");
                return BadRequest(ex.Message);
            }
        }
    }
}
