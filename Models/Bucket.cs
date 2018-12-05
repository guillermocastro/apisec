using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace secapi.Models
{
    [Table("Bucket",Schema="dba")]
    public class Bucket
    {
        [Key]
        public int BucketId {get;set;}
        [StringLength(128)]
        public string BucketName {get;set;}
        public int BucketTypeId {get;set;}
        [StringLength(36)]
        public string Reference {get;set;}
        [StringLength(20)]
        public string State {get;set;}
        public int? ParentId {get;set;}
        public string Comments {get;set;}
        public string Owner {get;set;}
        public DateTime? StartDate {get;set;}
        public DateTime? DueDate {get;set;}
        public bool IsSuppressed {get;set;}
        public decimal? PlannedDuration {get;set;}
        public decimal? PlannedCost {get;set;}
        public int Priority {get;set;}
    }
}