using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace secapi.Models
{
    [Table("EdgeType",Schema="dba")]
    public class EdgeType
    {
        [Key]
        public int EdgeTypeId {get;set;}
        [StringLength(128)]
        public string EdgeTypeName {get;set;}
        public string StateList {get;set;}
        public string CSS {get;set;}
    }
}