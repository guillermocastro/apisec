using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace secapi.Models
{
    [Table("vBucket",Schema="dba")]
    public class vBucket
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
        public int? Owner {get;set;}
        public DateTime? StartDate {get;set;}
        public DateTime? DueDate {get;set;}
        public bool IsSuppressed {get;set;}
        public int Priority {get;set;}
        public string Tree {get;set;}
        public string Container {get;set;}
        public int? Level {get;set;}
        public decimal? PlannedDuration {get;set;}
        public decimal? CumulativePlannedDuration {get;set;}
        public decimal? CumulativeRealDuration {get;set;}
        public decimal? PlannedCost {get;set;}
        public decimal? CumulativePlannedCost {get;set;}
        public decimal? RealCost {get;set;}
        public int? Server {get;set;}
        public int? Client {get;set;}
        public string BucketTypeName {get;set;}
        public string StateList {get;set;}
        public string ParentList {get;set;}
        public string CSS {get;set;}
    }
}