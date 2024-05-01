namespace SkyhawkAPI.Entities
{
    public class Tespit
    {
        public int Id { get; set; } 
        public double XKoordinatı {get; set; } // X koordinatı
        public double Ykoordinatı { get; set; } // Y koordinatı
        public DateTime TespitZamani { get; set; } // Tespit zamanı
        public byte[] TespitFotografi { get; set; } // Tespit fotoğrafı (Base64 formatında)

    }
}
