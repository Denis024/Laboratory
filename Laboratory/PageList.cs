using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory
{
    class PageList
    {
        public List<LastEnter> LastEnters { get; set; }
        public List<LastEnter> OffsetlastEnters => LastEnters.ToList();
        public PageList(List<LastEnter> lastEnters) => LastEnters = lastEnters;
    }
}
