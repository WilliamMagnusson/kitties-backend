using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitties.Models;
using Microsoft.AspNetCore.Mvc;
using Faker;

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
        
        // public IActionResult Create([FromBody]string body, [FromBody]string pattern, 
        // [FromBody]string mouth, [FromBody]string eye)
        [HttpPost]
        public IActionResult Create([FromBody] Kitty kitten)
        {
            //Genera namn och id
            string id = Guid.NewGuid().ToString();

            var kitty = new Kitty {
                Id = id,
                Name = NameFaker.Name(),
                Body = kitten.Body,
                Pattern = kitten.Pattern,
                Mouth = kitten.Mouth,
                Eye = kitten.Eye
            };

            kittyContext.KittyItems.Add(kitty);
            kittyContext.SaveChanges();

            var result = new ObjectResult(kitty);
            result.StatusCode = 201;
            return result;
        }
    }
}
