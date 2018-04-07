using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitties.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kitties.Controllers
{
    [Route("api/[controller]")]
    public class KittenController : Controller
    {

        private readonly KittiesContext kittyContext; 

        public KittenController(KittiesContext context)
        {
            kittyContext = context;

            if (kittyContext.KittyItems.Count() == 0)
            {
                kittyContext.KittyItems.Add(new Kitty {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Lars",
                    Body = Body.mainecoon,
                    Pattern = Pattern.jaguar,
                    Mouth = Mouth.gerbil,
                    Eye = Eye.otaku
                });
                kittyContext.KittyItems.Add(new Kitty {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Lars2",
                    Body = Body.chartreux,
                    Pattern = Pattern.jaguar,
                    Mouth = Mouth.pouty,
                    Eye = Eye.googly
                });
                kittyContext.KittyItems.Add(new Kitty {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Lars3",
                    Body = Body.chartreux,
                    Pattern = Pattern.totesbasic,
                    Mouth = Mouth.dali,
                    Eye = Eye.fabulous
                });
                kittyContext.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Kitty> GetAll()
        {
            return kittyContext.KittyItems.ToList();
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var kitty = kittyContext.KittyItems.FirstOrDefault(k => k.Id == id);
            if (kitty == null)
            {
                return NotFound();
            }

            var result = new ObjectResult(kitty);
            result.StatusCode = 200;
            return result;
        }

        
        [HttpPost]
        public void Create([FromBody]Body body, [FromBody]Pattern pattern, 
        [FromBody]Mouth mouth, [FromBody]Eye eye)
        {
            //Genera namn och id
            string id = Guid.NewGuid().ToString();


            var kitty = new Kitty {
                Id = id,
                Name = "Lars",
                Body = body,
                Pattern = pattern,
                Mouth = mouth,
                Eye = eye
            };


            kittyContext.KittyItems.Add(kitty);



        }
    }
}
