using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Apiles.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowController : ControllerBase
    {
        BinaryFormatter formet = new BinaryFormatter();
        // GET: api/Windows
        [HttpGet]
        public ActionResult<Windows> GetWindow()
        {
            using (FileStream file = new FileStream("Windows.dat", FileMode.OpenOrCreate))
            {
                if (file.Length != 0)
                {
                    return (ActionResult<Windows>)formet.Deserialize(file);
                }
                return null;

            }
        }

        // GET: api/Windows/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Windows
        [HttpPost]
        public ActionResult<Windows> Post( Windows window)

        {
            using (FileStream file = new FileStream("Windows.dat", FileMode.OpenOrCreate))
            {
              
                formet.Serialize(file, window);
            }
            return Ok(window);

            
        }

        // PUT: api/Windows/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
