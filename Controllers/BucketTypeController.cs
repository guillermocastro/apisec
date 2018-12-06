using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using secapi.Models;

namespace secapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BucketTypeController: ControllerBase
    {
        private readonly SqlContext _context;
        public BucketTypeController(SqlContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<BucketType>> GetAll()
        {
            return _context.BucketType.ToList();
        }

        [HttpGet("{BucketTypeId}",Name="GetBucketType")]
        public ActionResult<BucketType> GetByBucketTypeId(int BucketTypeId)
        {
            var BucketType = _context.BucketType.Find(BucketTypeId);

            if (BucketType==null)
            {
                return NotFound();
            }
            return BucketType;
        }
        [HttpPost]
        public IActionResult Create(BucketType BucketType)
        {
            _context.BucketType.Add(BucketType);
            _context.SaveChanges();
            return CreatedAtRoute("GetBucketType",new {GetByBucketTypeId=BucketType.BucketTypeId,BucketType});
        }
        [HttpPut("{BucketTypeId}")]
        public IActionResult Update(int BucketTypeId,BucketType data)
        {
            var BucketType=_context.BucketType.Find(BucketTypeId);
            if (BucketType==null)
            {
                return NotFound();
            }
            //BucketType.BucketTypeId=data.BucketTypeId;
            BucketType.BucketTypeName=data.BucketTypeName;
            BucketType.StateList=data.StateList;
            BucketType.ParentList=data.ParentList;
            BucketType.CSS=data.CSS;
            _context.BucketType.Update(BucketType);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{BucketTypeId}")]
        public IActionResult Delete(int BucketTypeId)
        {
            var BucketType=_context.BucketType.Find(BucketTypeId);
            if (BucketType==null)
            {
                return NotFound();
            }
            _context.BucketType.Remove(BucketType);
            _context.SaveChanges();
            return NoContent();
        }
    }
}