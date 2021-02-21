using Lookup.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lookup.API.Model
{
    public class LookupT
    {
        public string LookupName { get; set; }
        IEnumerable<LookupItems> LookupItems { get; set; }

    }
}
