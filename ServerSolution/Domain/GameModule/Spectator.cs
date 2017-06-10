namespace Domain.GameModule
{
    public class Spectator
    {
        private static int counter = 0;
        private int id;
        private string name;

        public Spectator(string name)
        {
            counter++;
            this.Username = name;
            Id = counter;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Username
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }
}
