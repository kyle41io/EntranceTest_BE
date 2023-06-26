using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EntranceTestCore6.Data

{
    public class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestId { get; set; }
        public string? TestName { get; set; }
        public int TestAmount { get; set; }
        public int TestTime { get; set; }
        public string? TestDesc { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}