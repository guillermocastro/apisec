using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using secapi.Models;

namespace secapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdgeTypeController: ControllerBase
    {
        private readonly SqlContext _context;
        public EdgeTypeController(SqlContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<EdgeType>> GetAll()
        {
            return _context.EdgeType.ToList();
        }

        [HttpGet("{EdgeTypeId}",Name="GetEdgeType")]
        public ActionResult<EdgeType> GetByEdgeTypeId(int EdgeTypeId)
        {
            var EdgeType = _context.EdgeType.Find(EdgeTypeId);

            if (EdgeType==null)
            {
                return NotFound();
            }
            return EdgeType;
        }
        [HttpPost]
        public IActionResult Create(EdgeType EdgeType)
        {
            _context.EdgeType.Add(EdgeType);
            _context.SaveChanges();
            return CreatedAtRoute("GetEdgeType",new {GetByEdgeTypeId=EdgeType.EdgeTypeId,EdgeType});
        }
        [HttpPut("{EdgeTypeId}")]
        public IActionResult Update(int EdgeTypeId,EdgeType data)
        {
            var EdgeType=_context.EdgeType.Find(EdgeTypeId);
            if (EdgeType==null)
            {
                return NotFound();
            }
            //EdgeType.EdgeTypeId=data.EdgeTypeId;
            EdgeType.EdgeTypeName=data.EdgeTypeName;
            EdgeType.StateList=data.StateList;
            EdgeType.CSS=data.CSS;
            _context.EdgeType.Update(EdgeType);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{EdgeTypeId}")]
        public IActionResult Delete(int EdgeTypeId)
        {
            var EdgeType=_context.EdgeType.Find(EdgeTypeId);
            if (EdgeType==null)
            {
                return NotFound();
            }
            _context.EdgeType.Remove(EdgeType);
            _context.SaveChanges();
            return NoContent();
        }
    }
}