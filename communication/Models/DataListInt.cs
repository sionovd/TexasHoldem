using System.Collections.Generic;

namespace communication.Models
{
    class DataListInt:Data
    {
        public List<int> Content { set; get; }

        public DataListInt(List<int> content)
        {
            Content = content;
        }
    }
}
