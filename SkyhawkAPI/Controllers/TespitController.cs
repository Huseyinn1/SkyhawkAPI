using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkyhawkAPI.Data;
using SkyhawkAPI.Entities;
using System;

namespace SkyhawkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TespitController : ControllerBase
    {
        private readonly DataContext _context;

        public TespitController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult TespitEkle([FromBody] TespitRequest tespitRequest)
        {
            if (tespitRequest == null)
            {
                return BadRequest("Geçersiz istek.");
            }

            // Base64 verisini byte dizisine dönüştürme
            byte[] tespitFotografiBytes = Convert.FromBase64String(tespitRequest.TespitFotografi);

            // Yeni bir Tespit nesnesi oluşturma
            var newTespit = new Tespit
            {
                XKoordinatı = tespitRequest.XKoordinatı,
                Ykoordinatı = tespitRequest.Ykoordinatı,
                TespitZamani = DateTime.Now,
                TespitFotografi = tespitFotografiBytes
            };

            // Tespit nesnesini veritabanına ekleme
            _context.Tespitler.Add(newTespit);
            _context.SaveChanges();

            return Ok("Tespit başarıyla eklendi.");
        }
        [HttpGet("{id}")]
        public IActionResult TespitiGetir(int id)
        {
            var tespit = _context.Tespitler.FirstOrDefault(t => t.Id == id);

            if (tespit == null)
            {
                return NotFound("Tespit bulunamadı.");
            }

            return Ok(tespit);
        }
        [HttpGet]
        public IActionResult TumTespitleriGetir()
        {
            var tespitler = _context.Tespitler.ToList();
            return Ok(tespitler);
        }
    }

    // Tespit isteği için model
    public class TespitRequest
    {
        public double XKoordinatı { get; set; }
        public double Ykoordinatı { get; set; }
        public string TespitFotografi { get; set; }
    }
}
