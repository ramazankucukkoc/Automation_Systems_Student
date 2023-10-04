using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Paging
{
    public class GetListResponse<T>
    {
        public List<T> Items { get; set; }

    }
}
