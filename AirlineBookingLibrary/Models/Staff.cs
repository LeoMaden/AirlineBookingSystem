using System;
using System.Collections.Generic;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents a member of staff.
    /// </summary>
    public class Staff : IHasPrimaryKey<int>, IEquatable<Staff>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }



        public override bool Equals(object obj)
        {
            return Equals(obj as Staff);
        }

        public bool Equals(Staff other)
        {
            return other != null &&
                   Id == other.Id &&
                   UserName == other.UserName &&
                   PasswordHash == other.PasswordHash;
        }

        public override int GetHashCode()
        {
            var hashCode = 569975081;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PasswordHash);
            return hashCode;
        }

        public static bool operator ==(Staff staff1, Staff staff2)
        {
            return EqualityComparer<Staff>.Default.Equals(staff1, staff2);
        }

        public static bool operator !=(Staff staff1, Staff staff2)
        {
            return !(staff1 == staff2);
        }
    }
}
