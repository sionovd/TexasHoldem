using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication7
{
    public class PlayerLeader
    {
        public string userName { get; set; }
        public int value { get; set; }

        public PlayerLeader()
        { }

        public PlayerLeader(string userName, int value)
        {
            this.userName = userName;
            this.value = value;
        }
    }
}