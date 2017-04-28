using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    class SearchNodeFilter
    {
        private string field;
        private int value;

        public SearchNodeFilter(string field, int value)
        {
            this.field = field;
            this.value = value;
        }

        public string Field
        {
            get
            {
                return field;
            }

            set
            {
                field = value;
            }
        }

        public int Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }
    }
}
