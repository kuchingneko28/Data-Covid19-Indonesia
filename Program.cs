using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        static async Task<object> getUrl(string x)
        {
            string url = x;
            string filePath ="data-covid.txt";
            // Driver
            List<string> lines = new List<string>();
            client = new HttpClient();
            //Get Resonse
            string response = await client.GetStringAsync(url);
            //Convert Json
            AllData json = JsonConvert.DeserializeObject<AllData>(response);
            foreach (var data in json.list_data)
            {
             // Print all to console
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
             
             // Print all to txt file
             lines.Add("[+] " + data.key);
             lines.Add("- Jumlah kasus: " + data.jumlah_kasus);
             lines.Add("- Jumlah sembuh: " + data.jumlah_sembuh);
             lines.Add("- Jumlah dirawat: " + data.jumlah_dirawat);
             lines.Add("- Jumlah meninggal: " + data.jumlah_meninggal);
             lines.Add("[+] Kasus Penambahan ");
             lines.Add("- Penambahan positif: " + data.penambahan.positif);
             lines.Add("- Penambahan sembuh: " + data.penambahan.sembuh);
             lines.Add("- Penambahan meninggal: " + data.penambahan.meninggal + "\n");
             File.WriteAllLines(filePath,lines);
            }
             return url;
        }
        
    }
}
