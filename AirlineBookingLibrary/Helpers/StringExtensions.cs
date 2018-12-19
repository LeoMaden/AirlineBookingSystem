namespace AirlineBookingLibrary.Helpers
{
    public static class StringExtensions
    {
        public static string NullIfEmpty(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }
            else
            {
                return s;
            }
        }
    }
}
