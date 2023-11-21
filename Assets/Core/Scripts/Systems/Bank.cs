using System;

namespace RunnerECS
{
    //? Do i have to reset value every level?
    public class Bank
    {
        public static Bank Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Bank();
                return _instance;
            }
        }

        private static Bank _instance;

        public int Coins { get; private set; }

        public void Add(object sender, int coins)
        {
            if (coins < 1)
                throw new ArgumentException("Number of coins must be more than 0");

            Coins += coins;
        }
    }
}
