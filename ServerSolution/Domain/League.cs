using Domain.UserModule;

namespace Domain
{
    public abstract class League
    {
        protected int lowerBound;
        protected int upperBound;
        public int Id { get; protected set;  }
        public string Name { get; protected set; }

        public bool AddUserLegally(User user)
        {
            if (user.Stats.Points >= lowerBound && user.Stats.Points <= upperBound)
            {
                user.League = this;
                return true;
            }
            return false;
        }

    }

    class DefaultLeague : League
    {
        public DefaultLeague()
        {
            Id = 1;
            lowerBound = 0;
            upperBound = 10;
            Name = "Default";
        }
    }
}
