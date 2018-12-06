using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace secapi.Models
{
    [Table("Resource",Schema="dba")]
    public class Resource
    {
        [Key]
        public int ResourceId {get;set;}
        [StringLength(128)]
        public string ResourceName {get;set;}
        [StringLength(128)]
        public string Username {get;set;}
        public bool? IsSuppressed {get;set;}
        public decimal? CostHour {get;set;}
        [StringLength(255)]
        public string ShortComment {get;set;}
    }
}