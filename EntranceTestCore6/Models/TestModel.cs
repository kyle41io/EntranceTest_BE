using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntranceTestCore6.Data;
using Microsoft.EntityFrameworkCore;

namespace EntranceTestCore6.Models
{
    public class TestModel
    {
        public string TestName { get; set; }
        public TimeSpan TestTime { get; set; }
        public string TestDesc { get; set; }
    }
}