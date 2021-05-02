using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Core;
using InfluxDB.Client.Writes;

namespace healtcheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        const string token = "WrAUI0bDH8sAyS6ExryX0e1XUsqMwA7IHMjgqDECiloiQBHKSemDQA5OoJTVJs_UnQ-npWoCA4gsnyvhadbSbg==";
        const string bucket = "test";
        const string org = "test";

        public async Task<JsonResult> test() {
            string res = "OK";
            await Task.Run(() => {

                // You can generate a Token from the "Tokens Tab" in the UI

                var client = InfluxDBClientFactory.Create("http://localhost:8086", token.ToCharArray());
                const string data = "mem,host=host1 used_percent=23.43234543";
                using (var writeApi = client.GetWriteApi())
                {
                    writeApi.WriteRecord(bucket, org, WritePrecision.Ns, data);
                }
            });
            return new JsonResult(res);
        }
    }
}
