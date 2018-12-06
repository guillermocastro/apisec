using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace secapi.Models
{
    [Table("Edge",Schema="dba")]
    public class Edge
    {
        [Key]
        public int EdgeId {get;set;}
        public int SourceId {get;set;}
        public int DestinationId {get;set;}
        [StringLength(128)]
        public string EdgeName {get;set;}
        public int EdgeTypeId {get;set;}
        public string Comments {get;set;}
        public bool? IsSuppressed {get;set;}
    }
}