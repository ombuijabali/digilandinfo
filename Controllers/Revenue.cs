using System;

namespace Geoportal.Controllers
{
    public class Revenue
    {
        public DateTime Month { get; set; }
        public double RevenueCollected { get; set; }
        public double PendingPayments { get; set; }
        public double DefaultedPayments { get; set; }
    }
}
