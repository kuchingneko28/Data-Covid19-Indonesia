using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Data_Covid_Indonesia
{
    class Program
    {
        public static HttpClient client;
        static async Task Main(string[] args)
        {
         //Url api
         await getUrl("https://data.covid19.go.id/public/api/prov.json");   
        }
        static async Task<string> getUrl(string x)
        {
            string url = x;
            // Driver
            client = new HttpClient();
            //Get Resonse
            string response = await client.GetStringAsync(url);
            //Convert Json
            AllData json = JsonConvert.DeserializeObject<AllData>(response);
            foreach (var data in json.list_data)
            {
             Console.WriteLine("[+] " + data.key);
             Console.WriteLine("- Tanggal terakhir update : " + json.last_date);
             Console.WriteLine("- Jumlah kasus: " + data.jumlah_kasus);
             Console.WriteLine("- Jumlah sembuh: " + data.jumlah_sembuh);
             Console.WriteLine("- Jumlah dirawat: " + data.jumlah_dirawat);
             Console.WriteLine("- Jumlah meninggal: " + data.jumlah_meninggal);
             Console.WriteLine("[+] Kasus Penambahan");
             Console.WriteLine("- Penambahan positif: " + data.penambahan.positif);
             Console.WriteLine("- Penambahan sembuh: " + data.penambahan.sembuh);
             Console.WriteLine("- Penambahan meninggal: " + data.penambahan.meninggal + "\n");
             
            }
            
            return url;
        }
        
    }
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
