using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using acidfox_api.Models;

namespace acidfox_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly AcidFoxContext _context;

        public MembersController(IConfiguration configuration, AcidFoxContext context) 
        {
            _context = context;
        }
        // GET api/members
        [HttpGet]
        public ActionResult<List<Member>> Get()
        {
            var members = _context.Members.OrderBy(m => m.First_Name).ToList();
            if(members.Count() <= 0)
            {
                return NotFound();
            }

            return members;
        }

        // GET api/members/5
        [HttpGet("{id}")]
        public ActionResult<Member> Get(int id)
        {
            var member = _context.Members
                .FirstOrDefault(m => m.MemberId == id);
            if(member == null)
            {
                return NotFound();
            }

            return member;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/members/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DataObject data)
        {
            var member = _context.Members
                .Where(m => m.MemberId == data.memberId)
                .FirstOrDefault();

            if(member == null) 
            {
                return NotFound();
            }

            if(data.rating != null && data.rating != member.Rating)
            {
                member.Rating = data.rating ?? 0;
            }

            if(data.called != null && data.called != member.Called)
            {
                member.Called = data.called ?? false;
            }

            if(data.called_Count != null && data.called_Count != member.Called_Count)
            {
                member.Called_Count = data.called_Count ?? 0;
            }
            
            _context.SaveChanges();

            return Ok(member);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var member = _context.Members
                .Where(x => x.MemberId == id)
                .FirstOrDefault();

            _context.Members.Remove(member);
            _context.SaveChanges();
        }

        public class DataObject {
            public int memberId { get; set; }
            public int? rating { get; set; }
            public bool? called { get; set; }
            public int? called_Count { get; set; }
        }
    }
}
