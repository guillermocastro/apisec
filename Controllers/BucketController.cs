using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using secapi.Models;

namespace secapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BucketController: ControllerBase
    {
        private readonly SqlContext _context;
        public BucketController(SqlContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<Bucket>> GetAll()
        {
            return _context.Bucket.ToList();
        }

        [HttpGet("{BucketId}",Name="GetBucket")]
        public ActionResult<Bucket> GetByBucketId(string BucketId)
        {
            var Bucket = _context.Bucket.Find(BucketId);

            if (Bucket==null)
            {
                return NotFound();
            }
            return Bucket;
        }
        [HttpPost]
        public IActionResult Create(Bucket Bucket)
        {
            _context.Bucket.Add(Bucket);
            _context.SaveChanges();
            return CreatedAtRoute("GetBucket",new {GetByBucketId=Bucket.BucketId,Bucket});
        }
        [HttpPut("{BucketId}")]
        public IActionResult Update(string BucketId,Bucket data)
        {
            var Bucket=_context.Bucket.Find(BucketId);
            if (Bucket==null)
            {
                return NotFound();
            }
            //Bucket.BucketId=data.BucketId;
            Bucket.BucketName=data.BucketName;
            Bucket.BucketTypeId=data.BucketTypeId;
            Bucket.Reference=data.Reference;
            Bucket.State=data.State;
            Bucket.ParentId=data.ParentId;
            Bucket.Comments=data.Comments;
            Bucket.Owner=data.Owner;
            Bucket.StartDate=data.StartDate;
            Bucket.DueDate=data.DueDate;
            Bucket.IsSuppressed=data.IsSuppressed;
            Bucket.PlannedDuration=data.PlannedDuration;
            Bucket.PlannedCost=data.PlannedCost;
            Bucket.Priority=data.Priority;
            _context.Bucket.Update(Bucket);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{BucketId}")]
        public IActionResult Delete(string BucketId)
        {
            var Bucket=_context.Bucket.Find(BucketId);
            if (Bucket==null)
            {
                return NotFound();
            }
            _context.Bucket.Remove(Bucket);
            _context.SaveChanges();
            return NoContent();
        }
    }
}