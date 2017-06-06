using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication.Replies
{
    public class DataInt : Data
    {
        public int Content { get; set; }
        public DataInt(int content)
        {
            Content = content;
        }
    }
}