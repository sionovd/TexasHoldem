using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class ChatMessage
    {
        public string Username { get; set; }
        public string Message { get; set; }
        public string Color { get; set; }

        public ChatMessage()
        {
            
        }
        public ChatMessage(string username , string message , string color)
        {
            Color = color;
            Username = username;
            Message = message;

        }

        public override string ToString()
        {
            return Username + ": " + Message;
        }
    }
}
