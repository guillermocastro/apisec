using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using secapi.Models;

namespace secapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdgeController: ControllerBase
    {
        private readonly SqlContext _context;
        public EdgeController(SqlContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<Edge>> GetAll()
        {
            return _context.Edge.ToList();
        }

        [HttpGet("{EdgeId}",Name="GetEdge")]
        public ActionResult<Edge> GetByEdgeId(int EdgeId)
        {
            var Edge = _context.Edge.Find(EdgeId);

            if (Edge==null)
            {
                return NotFound();
            }
            return Edge;
        }
        [HttpPost]
        public IActionResult Create(Edge Edge)
        {
            _context.Edge.Add(Edge);
            _context.SaveChanges();
            return CreatedAtRoute("GetEdge",new {GetByEdgeId=Edge.EdgeId,Edge});
        }
        [HttpPut("{EdgeId}")]
        public IActionResult Update(int EdgeId,Edge data)
        {
            var Edge=_context.Edge.Find(EdgeId);
            if (Edge==null)
            {
                return NotFound();
            }
            //Edge.EdgeId=data.EdgeId;
            Edge.SourceId=data.SourceId;
            Edge.DestinationId=data.DestinationId;
            Edge.EdgeName=data.EdgeName;
            Edge.EdgeTypeId=data.EdgeTypeId;
            Edge.Comments=data.Comments;
            Edge.IsSuppressed=data.IsSuppressed;
            _context.Edge.Update(Edge);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{EdgeId}")]
        public IActionResult Delete(int EdgeId)
        {
            var Edge=_context.Edge.Find(EdgeId);
            if (Edge==null)
            {
                return NotFound();
            }
            _context.Edge.Remove(Edge);
            _context.SaveChanges();
            return NoContent();
        }
    }
}