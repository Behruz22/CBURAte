using CBURate.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace CBURate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CBUController : ControllerBase
    {
        private readonly CBUContext _context;
        private readonly List<IncomingModel> models;

        public  CBUController(CBUContext cBUContext)
        {
            _context = cBUContext;
        }

        [HttpGet]
        public async Task<List<IncomingModel>> Get()
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://cbu.uz/oz/arkhiv-kursov-valyut/json/");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                List<IncomingModel> jokes = JsonConvert.DeserializeObject<List<IncomingModel>>(content);

                await _context.models.AddRangeAsync(jokes);
                _context.SaveChanges();
                return jokes;

            }
            return new List<IncomingModel>();
            
            
        }
       
    }
}
