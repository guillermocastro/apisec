using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace secapi.Models
{
    [Table("BucketType",Schema="dba")]
    public class BucketType
    {
        [Key]
        public int BucketTypeId {get;set;}
        [StringLength(128)]
        public string BucketTypeName {get;set;}
        public string StateList {get;set;}
        public string ParentList {get;set;}
        public string CSS {get;set;}
    }
}