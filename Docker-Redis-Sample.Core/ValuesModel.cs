using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docker_Redis_Sample.Core
{
    public class ValuesModel
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
    }
}
