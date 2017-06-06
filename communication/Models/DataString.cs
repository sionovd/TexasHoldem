namespace communication.Models
{
    public class DataString :Data
    {
        public string Content { set; get; }

        public DataString(string content)
        {
            Content = content;
        }
    }
}
