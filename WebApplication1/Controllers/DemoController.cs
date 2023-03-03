using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using WebApplication1.Repositories;
using static WebApplication1.Controllers.DemoController;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IDemoRepository _demoRepository;
        public DemoController(IDemoRepository demoRepository)
        {
            _demoRepository = demoRepository;
        }
        
            [HttpGet]
            public async Task<IActionResult> Get()
            {
                var endpointUrl = "https://dummy.restapiexample.com/api/v1/employees";
                var token = "my-auth-token";
                var response= await _demoRepository.GetApiData(endpointUrl, token);
                return Ok(response);
            }
            [HttpPost]
            public async Task<IActionResult> Post(string jsonData)
            {
            //sample jsonData = {"name":"test","salary":"123","age":"23"}
            var endpointUrl = "https://dummy.restapiexample.com/api/v1/create";
                var token = "my-auth-token";
                var response = await _demoRepository.PostApiData(endpointUrl, token, jsonData);
                return Ok(response);
        }
        
    }
}

