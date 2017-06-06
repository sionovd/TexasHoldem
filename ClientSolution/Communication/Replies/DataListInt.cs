using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication.Replies
{
    public class DataListInt : Data
    {
        public List<int> Content { set; get; }

        public DataListInt(List<int> content)
        {
            Content = content;
        }
    }
}
