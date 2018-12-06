using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using secapi.Models;

namespace secapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController: ControllerBase
    {
        private readonly SqlContext _context;
        public ResourceController(SqlContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<Resource>> GetAll()
        {
            return _context.Resource.ToList();
        }

        [HttpGet("{ResourceId}",Name="GetResource")]
        public ActionResult<Resource> GetByResourceId(int ResourceId)
        {
            var Resource = _context.Resource.Find(ResourceId);

            if (Resource==null)
            {
                return NotFound();
            }
            return Resource;
        }
        [HttpPost]
        public IActionResult Create(Resource Resource)
        {
            _context.Resource.Add(Resource);
            _context.SaveChanges();
            return CreatedAtRoute("GetResource",new {GetByResourceId=Resource.ResourceId,Resource});
        }
        [HttpPut("{ResourceId}")]
        public IActionResult Update(int ResourceId,Resource data)
        {
            var Resource=_context.Resource.Find(ResourceId);
            if (Resource==null)
            {
                return NotFound();
            }
            //Resource.ResourceId=data.ResourceId;
            Resource.ResourceName=data.ResourceName;
            Resource.Username=data.Username;
            Resource.IsSuppressed=data.IsSuppressed;
            Resource.CostHour=data.CostHour;
            Resource.ShortComment=data.ShortComment;
            _context.Resource.Update(Resource);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{ResourceId}")]
        public IActionResult Delete(int ResourceId)
        {
            var Resource=_context.Resource.Find(ResourceId);
            if (Resource==null)
            {
                return NotFound();
            }
            _context.Resource.Remove(Resource);
            _context.SaveChanges();
            return NoContent();
        }
    }
}