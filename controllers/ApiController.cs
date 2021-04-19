using System;
using Newtonsoft.Json;
using RestSharp;

namespace Project
{
    public class ApiController
    {

     public ApiController()
     {
         string url = "https://data.covid19.go.id/public/api/prov.json";
         getApi(url);
     }   

     private string getApi(string url)
     {
         var client = new RestClient(url);
         var request = new RestRequest(Method.GET);
         var response = client.Execute(request);
         Root json = JsonConvert.DeserializeObject<Root>(response.Content); 

         foreach (var dataJson in json.list_data)
         {
             Console.WriteLine("[+] " + dataJson.key);
             Console.WriteLine("- Tanggal terakhir update : " + json.last_date);
             Console.WriteLine("- Jumlah kasus : " + dataJson.jumlah_kasus);
             Console.WriteLine("- Jumlah sembuh : " + dataJson.jumlah_sembuh);
             Console.WriteLine("- Jumlah meninggal : " + dataJson.jumlah_meninggal);
             Console.WriteLine("- Jumlah dirawat : " + dataJson.jumlah_dirawat);
             Console.WriteLine("[+] Penambahan kasus");
             Console.WriteLine("- Penambahan positif : " + dataJson.penambahan.positif);
             Console.WriteLine("- Penambahan sembuh : " + dataJson.penambahan.sembuh);
             Console.WriteLine("- Penambahan meninggal : " + dataJson.penambahan.meninggal + "\n");

         }

         return url;
     }
    }
}