using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiroClone.Server.BLL.RepositoryInterfaces;
using MiroClone.Server.DAL.Model;

namespace MiroClone.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IGenericRepository<AppUser> genericRepository) : ControllerBase
    {
        private readonly IGenericRepository<AppUser> _genericRepository = genericRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var result = await _genericRepository.GetAllAsync();
            return Ok(result);
        }


    }
}
