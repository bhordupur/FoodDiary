using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design
{
    public class breakfast
    {
        public int ID { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }

        public breakfast()
        {

        }

        public breakfast(string item, string description, DateTime time)
        {
            Item = item;
            Description = description;
            Time = time;
        }
    }

}