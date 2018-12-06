using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using secapi.Models;

namespace secapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HourTypeController: ControllerBase
    {
        private readonly SqlContext _context;
        public HourTypeController(SqlContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<HourType>> GetAll()
        {
            return _context.HourType.ToList();
        }

        [HttpGet("{HourTypeId}",Name="GetHourType")]
        public ActionResult<HourType> GetByHourTypeId(int HourTypeId)
        {
            var HourType = _context.HourType.Find(HourTypeId);

            if (HourType==null)
            {
                return NotFound();
            }
            return HourType;
        }
        [HttpPost]
        public IActionResult Create(HourType HourType)
        {
            _context.HourType.Add(HourType);
            _context.SaveChanges();
            return CreatedAtRoute("GetHourType",new {GetByHourTypeId=HourType.HourTypeId,HourType});
        }
        [HttpPut("{HourTypeId}")]
        public IActionResult Update(int HourTypeId,HourType data)
        {
            var HourType=_context.HourType.Find(HourTypeId);
            if (HourType==null)
            {
                return NotFound();
            }
            //HourType.HourTypeId=data.HourTypeId;
            HourType.HourTypeName=data.HourTypeName;
            _context.HourType.Update(HourType);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{HourTypeId}")]
        public IActionResult Delete(int HourTypeId)
        {
            var HourType=_context.HourType.Find(HourTypeId);
            if (HourType==null)
            {
                return NotFound();
            }
            _context.HourType.Remove(HourType);
            _context.SaveChanges();
            return NoContent();
        }
    }
}