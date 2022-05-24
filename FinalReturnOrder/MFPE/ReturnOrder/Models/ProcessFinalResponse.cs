using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnOrder.Models
{
    public class ProcessFinalResponse
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public double ProcessingCharge { get; set; }
        public double PackagingAndDeliveryCharge { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public string CreditCardNumber { get; set; }
        public string ComponentName { get; set; }
        public int Qunatity { get; set; }
        public string Name { get; set; }
    }
}
