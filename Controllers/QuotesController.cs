using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        static List<Quote> Quotes = new List<Quote>()
        {
            new Quote(){ Id=0,Title="Islands",Author="Jobin", Description="story"},
            new Quote(){Id=1,Title="Land",Author="Robin",Description="mystory"}

        };

        [HttpGet]
         public  IEnumerable<Quote> Get()
        {
            return Quotes;
        }

        [HttpPost]
        public  void Post([FromBody]Quote quote)
        {
            Quotes.Add(quote);
        }

        [HttpPut("{Id}")]
        public void Put(int Id,[FromBody]Quote quote)
        {
            Quotes[Id] = quote;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try {
                Quotes.RemoveAt(id);
            }
            catch
            { }
            
        }
    }
}
