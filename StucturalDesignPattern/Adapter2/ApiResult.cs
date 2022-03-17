using System.Collections.Generic;

namespace Adapter2
{
    public class ApiResult<T>
    {
        public int Count { get; set; }
        public List<T> Results { get; set; }
    }

}
