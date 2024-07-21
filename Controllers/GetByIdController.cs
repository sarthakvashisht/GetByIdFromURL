using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GetByIdFromURL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetByIdController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://jsonplaceholder.typicode.com/posts";

        public GetByIdController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<string> GetPostByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                // Handle the error or throw an exception
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }

}

