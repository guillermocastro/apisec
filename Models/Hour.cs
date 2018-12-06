using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace secapi.Models
{
    [Table("Hour",Schema="dba")]
    public class Hour
    {
        [Key]
        public int HourId {get;set;}
        public int BucketId {get;set;}
        public int ResourceId {get;set;}
        public int HourTypeId {get;set;}
        public DateTime? HourStart {get;set;}
        public DateTime? HourEnd {get;set;}
        public decimal? Cost {get;set;}
        [StringLength(255)]
        public string ShortComment {get;set;}
    }
}