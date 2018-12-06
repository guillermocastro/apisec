using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using secapi.Models;

namespace secapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HourController: ControllerBase
    {
        private readonly SqlContext _context;
        public HourController(SqlContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<Hour>> GetAll()
        {
            return _context.Hour.ToList();
        }

        [HttpGet("{HourId}",Name="GetHour")]
        public ActionResult<Hour> GetByHourId(int HourId)
        {
            var Hour = _context.Hour.Find(HourId);

            if (Hour==null)
            {
                return NotFound();
            }
            return Hour;
        }
        [HttpPost]
        public IActionResult Create(Hour Hour)
        {
            _context.Hour.Add(Hour);
            _context.SaveChanges();
            return CreatedAtRoute("GetHour",new {GetByHourId=Hour.HourId,Hour});
        }
        [HttpPut("{HourId}")]
        public IActionResult Update(int HourId,Hour data)
        {
            var Hour=_context.Hour.Find(HourId);
            if (Hour==null)
            {
                return NotFound();
            }
            //Hour.HourId=data.HourId;
            Hour.BucketId=data.BucketId;
            Hour.ResourceId=data.ResourceId;
            Hour.HourTypeId=data.HourTypeId;
            Hour.HourStart=data.HourStart;
            Hour.HourEnd=data.HourEnd;
            Hour.Cost=data.Cost;
            Hour.ShortComment=data.ShortComment;
            _context.Hour.Update(Hour);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{HourId}")]
        public IActionResult Delete(int HourId)
        {
            var Hour=_context.Hour.Find(HourId);
            if (Hour==null)
            {
                return NotFound();
            }
            _context.Hour.Remove(Hour);
            _context.SaveChanges();
            return NoContent();
        }
    }
}