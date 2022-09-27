using DapperAppSample.Entities;
using DapperAppSample.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperAppSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repository;
        private readonly ILogger<UserController> _logger;

        public UserController(UserRepository repository, ILogger<UserController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<User> Get(int id)
        {
            return await _repository.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            return await _repository.Add(user) > 0 ? Ok() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(User user)
        {
            return await _repository.Update(user) > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return await _repository.Delete(id) > 0 ? Ok() : BadRequest();
        }
    }
}