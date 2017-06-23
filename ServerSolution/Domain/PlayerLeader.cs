using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PlayerLeader
    {
        public string userName { get; set; }
        public int value { get; set; }

        public PlayerLeader()
        {}

        public PlayerLeader(string userName,int value)
        {
            this.userName = userName;
            this.value = value;
        }

    }
}
