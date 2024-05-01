using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkyhawkAPI.Data;
using SkyhawkAPI.Entities;

namespace SkyhawkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login([FromBody] Login loginRequest)
        {
            if (loginRequest == null || string.IsNullOrWhiteSpace(loginRequest.Kod))
            {
                return BadRequest("Geçersiz istek.");
            }

            var existingLogin = _context.Logins.FirstOrDefault(l => l.Kod == loginRequest.Kod);

            if (existingLogin == null)
            {
                return NotFound("Girilen kod bulunamadı.");
            }

            return Ok("Giriş başarılı.");
        }

        // Request bodyden sadece kodu göndeririz.
        /*public class LoginRequest
        {
            public string Kod { get; set; }
        }*/
    }
}
