using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace secapi.Models
{
    [Table("HourType",Schema="dba")]
    public class HourType
    {
        [Key]
        public int HourTypeId {get;set;}
        [StringLength(128)]
        public string HourTypeName {get;set;}
    }
}