using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrinityShop.Models.Client;
using TrinityShop.Services.Clients;

namespace TrinityShop.Controllers.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _context;

        public ClientController(ClientService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientModel>>> GetClients()
        {
            try
            {
                var clients = await _context.GetClients();
                if (clients.Count > 0)
                {
                    return Ok(clients);
                }
                else
                {
                    return NoContent();
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}