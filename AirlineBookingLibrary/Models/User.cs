using System;
using System.Collections.Generic;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents a user of the system.
    /// </summary>
    public class User : IHasPrimaryKey<int>, IEquatable<User>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public string PasswordHash { get; set; }



        public override bool Equals(object obj)
        {
            return Equals(obj as User);
        }

        public bool Equals(User other)
        {
            return other != null &&
                   Id == other.Id &&
                   Title == other.Title &&
                   FirstName == other.FirstName &&
                   LastName == other.LastName &&
                   UserName == other.UserName &&
                   DateOfBirth == other.DateOfBirth &&
                   EqualityComparer<Address>.Default.Equals(Address, other.Address) &&
                   Email == other.Email &&
                   PhoneNumber == other.PhoneNumber &&
                   DateCreated == other.DateCreated &&
                   PasswordHash == other.PasswordHash;
        }

        public override int GetHashCode()
        {
            var hashCode = -1139607398;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserName);
            hashCode = hashCode * -1521134295 + DateOfBirth.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Address>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PhoneNumber);
            hashCode = hashCode * -1521134295 + DateCreated.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PasswordHash);
            return hashCode;
        }

        public static bool operator ==(User user1, User user2)
        {
            return EqualityComparer<User>.Default.Equals(user1, user2);
        }

        public static bool operator !=(User user1, User user2)
        {
            return !(user1 == user2);
        }
    }
}
