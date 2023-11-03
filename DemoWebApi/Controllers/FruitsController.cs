using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DemoWebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class FruitsController:ControllerBase
    {
        static List<string> Fruits=new List<string>()
        {
          "Apple","Mango","Ornage","Grpaes","Banana"
        };

       [HttpGet]
       [Route("ShowFruits")]
        public IEnumerable<string> GetFruits()
        {
            return Fruits;
        }
        
        [HttpGet]
        [Route("ShowFruits/{id}")]
        public string GetFruits(int id)
        {
            return Fruits[id];
        }
        [HttpPost]
        [Route("AddFruits")]
        public void Post([FromBody] string data)
        {
           Fruits.Add(data);
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public void EditFruits(int id,[FromBody] string data)
        {
            Fruits[id]=data;
        }

        [HttpDelete]
        [Route("Kill/{id}")]
        public void Delete(int id)
        {
            Fruits.RemoveAt(id);
        }


    }
}