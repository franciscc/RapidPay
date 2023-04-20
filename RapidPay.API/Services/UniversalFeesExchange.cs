namespace RapidPay.API.Services
{
    public class UniversalFeesExchange
    {
        private static UniversalFeesExchange _instance;
        private decimal _lastFee;
        private int? _lastHour;

        private UniversalFeesExchange()
        {
            _lastHour = null; 
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

        private bool IsNewFeeNeeded(int hour)
        {
            if (_lastHour != hour)
            {
                _lastHour = hour;
                return true;
            }

            return _lastHour != hour;
        }

        public decimal GetNewFee()
        {
            var IsNewFeeNeeded = this.IsNewFeeNeeded(DateTime.UtcNow.Hour);
            if (IsNewFeeNeeded)
            {
                decimal randomDecimal = GetRandomDecimal();
                decimal newFee = Math.Round(_lastFee * randomDecimal);
                _lastFee = newFee;
                return newFee;
            }

            return _lastFee;
        }
    }
}
