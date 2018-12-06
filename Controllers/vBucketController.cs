using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using secapi.Models;

namespace secapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vBucketController: ControllerBase
    {
        private readonly SqlContext _context;
        public vBucketController(SqlContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<vBucket>> GetAll()
        {
            return _context.vBucket.ToList();
        }

        [HttpGet("{BucketId}",Name="GetvBucket")]
        public ActionResult<vBucket> GetByvBucketId(int BucketId)
        {
            var vBucket = _context.vBucket.Find(BucketId);

            if (vBucket==null)
            {
                return NotFound();
            }
            return vBucket;
        }
    }
}