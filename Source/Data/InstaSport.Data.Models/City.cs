using InstaSport.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaSport.Data.Models
{
    public class City : BaseModel<int>
    {
        public string Name { get; set; }
    }
}
