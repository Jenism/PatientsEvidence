using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore
{
    internal static class EntitiesExtensions
    {
        public static int GetAge(this DateTime dateOfBirth)
        {
            var currentDate = DateTime.Now;
            var age = currentDate.Year - dateOfBirth.Year;

            if (currentDate.Month < dateOfBirth.Month || (currentDate.Month == dateOfBirth.Month && currentDate.Day < dateOfBirth.Day))
                age--;

            return age;
        }
    }
}
