
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;


namespace FADY.Services.Lookup.API.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
        //[Route("LoadData")]
        //public async Task<IActionResult> LoadData()
        //{
        
        //    using (var connection = new SqlConnection("Server=.;Initial Catalog=DB_A4F371_LookUpsV2;Integrated Security=true"))
        //    {
        //        connection.Open();
        //        var lookupres = await connection.QueryAsync<LookupItems>("SELECT *  FROM  [DB_A4F371_LookUpsV2].[dbo].[Governorates]");
        //        var lookuplist= new List<LookupItems>();
        //      foreach(var item in lookupres)
        //        {
        //            var lookupitem = new LookupItems
        //            {
        //                Id = item.Id,
        //                Code = item.Code,
        //                Name =item.Name
        //            };


        //            lookuplist.Add(lookupitem);
        //        }
        //        var lookupresjson = new JavaScriptSerializer().Serialize(lookuplist);
          
        //    var cache = RedisConnectorHelper.Connection.GetDatabase();

        //        cache.StringSet("Governorates", lookupresjson);
        //    }
        //    return Ok("load");
        //}

        //[Route("ReadData")]
        //public IActionResult ReadData()
        //{
        //    var cache = RedisConnectorHelper.Connection.GetDatabase();
          
        //        var value = cache.StringGet("Governorates");
        //    return Ok(value);
        //}
    }
}
