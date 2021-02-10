using System.Collections.Generic;

namespace Data_Covid_Indonesia
{
    public class JenisKelamin    {
        public string key { get; set; } 
        public int doc_count { get; set; } 
    }

    public class Usia    {
        public double value { get; set; } 
    }

    public class KelompokUmur    {
        public string key { get; set; } 
        public int doc_count { get; set; } 
        public Usia usia { get; set; } 
    }

    public class Lokasi    {
        public double lon { get; set; } 
        public double lat { get; set; } 
    }

    public class Penambahan    {
        public int positif { get; set; } 
        public int sembuh { get; set; } 
        public int meninggal { get; set; } 
    }

    public class ListData    {
        public string key { get; set; } 
        public double doc_count { get; set; } 
        public int jumlah_kasus { get; set; } 
        public int jumlah_sembuh { get; set; } 
        public int jumlah_meninggal { get; set; } 
        public int jumlah_dirawat { get; set; } 
        public List<JenisKelamin> jenis_kelamin { get; set; } 
        public List<KelompokUmur> kelompok_umur { get; set; } 
        public Lokasi lokasi { get; set; } 
        public Penambahan penambahan { get; set; } 
    }

    public class AllData    {
        public string last_date { get; set; } 
        public double current_data { get; set; } 
        public double missing_data { get; set; } 
        public int tanpa_provinsi { get; set; } 
        public List<ListData> list_data { get; set; } 
        
    }

}