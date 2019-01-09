using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Models
{
    public class PaymentInfo : IEquatable<PaymentInfo>
    {
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CVV { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as PaymentInfo);
        }

        public bool Equals(PaymentInfo other)
        {
            return other != null &&
                   NameOnCard == other.NameOnCard &&
                   CardNumber == other.CardNumber &&
                   ExpirationDate == other.ExpirationDate &&
                   CVV == other.CVV;
        }

        public override int GetHashCode()
        {
            var hashCode = -1280891943;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NameOnCard);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CardNumber);
            hashCode = hashCode * -1521134295 + ExpirationDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CVV);
            return hashCode;
        }

        public static bool operator ==(PaymentInfo info1, PaymentInfo info2)
        {
            return EqualityComparer<PaymentInfo>.Default.Equals(info1, info2);
        }

        public static bool operator !=(PaymentInfo info1, PaymentInfo info2)
        {
            return !(info1 == info2);
        }
    }
}
