using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication.Replies
{
    public class DataString : Data
    {
        public string Content { set; get; }

        public DataString(string content)
        {
            Content = content;
        }
    }
}
