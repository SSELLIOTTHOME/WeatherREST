

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;






public class MobileProProxy
{
    /* DTOs */

    public async Task<string> ReturnLookups(Guid lic, int user, DateTime lastUpdate)
    {


        Dictionary<string, object> json = new Dictionary<string, object>();
        json.Add("lic", (lic));

        //json.Add("userID", (user));
        //json.Add("lastUpdate", (lastUpdate));

        var s = await this.GetData_Helper(json, "ReturnLookups");

      
        return "";
    }







    //string baseAddress = "http://10.0.0.52/PiranaDev/api/MobileProProxy/";
    string baseAddress = "http://www.google.com";

    public async Task<string> GetData_Helper(Dictionary<string, object> getparams, string method)
    {

        using (HttpClient client = new HttpClient())
        {

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                string responseObject = "";
                client.BaseAddress = new Uri("http://www.google.com");
         
                var p = "";
                foreach (var item in getparams)
                {
                    if (item.Value is DateTime)
                    {
                        p = p + item.Key + "=" + HttpUtility.UrlEncode(((DateTime)item.Value).ToString("o")) + "&";
                    }
                    else
                    {
                        p = p + item.Key + "=" + HttpUtility.UrlEncode(item.Value.ToString()) + "&";
                    }


                }

                if (p.EndsWith("&"))
                {
                    p = p.TrimEnd('&');
                }


                // await System.Threading.Tasks.Task.Delay(10000);

                if (p != "")
                {

                    responseObject = await client.GetStringAsync(baseAddress + method + "?" + p);
                  
                }
                else
                {

                    responseObject = await client.GetStringAsync(baseAddress + method);
                    

                }

                return responseObject;


            }
            catch (Exception ex)
            {
                return null;


            }

        }
    }



    





}