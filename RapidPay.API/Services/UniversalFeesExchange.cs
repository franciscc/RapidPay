namespace RapidPay.API.Services
{
    public class UniversalFeesExchange
    {
        private static UniversalFeesExchange _instance;
        private decimal _lastFee;

        private UniversalFeesExchange()
        {
            _lastFee = 1;
        }

        public static UniversalFeesExchange Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UniversalFeesExchange();
                }
                return _instance;
            }
        }

        private decimal GetRandomDecimal()
        {
            Random rnd = new Random();
            decimal randomDecimal = (decimal)rnd.NextDouble() * 2;
            return randomDecimal;
        }

        public decimal GetNewFee()
        {
            decimal randomDecimal = GetRandomDecimal();
            decimal newFee = Math.Round(_lastFee * randomDecimal);
            _lastFee = newFee;
            return newFee;
        }
    }
}
