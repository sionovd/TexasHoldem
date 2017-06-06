namespace communication.Models
{
    public class DataInt :Data
    {
        public int Content { get; set; }
        public DataInt(int content)
        {
            Content = content;
        }
    }
}
