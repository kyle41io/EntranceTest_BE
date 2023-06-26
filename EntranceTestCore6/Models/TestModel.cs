using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EntranceTestCore6.Data;
using Microsoft.EntityFrameworkCore;

namespace EntranceTestCore6.Models
{
    public class TestModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestId { get; set; }
        public string? TestName { get; set; }
        public int TestAmount { get; set; }
        public int TestTime { get; set; }
        public string? TestDesc { get; set; }
    }
}