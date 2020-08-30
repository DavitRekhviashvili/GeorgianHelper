using System;

namespace GeorgianHelper.Abstraction
{
    public interface IStringHelper
    {
        /// <summary>
        /// ქართული უნიკოდ ტექსტის ლათინურ ასოებიან ტექსტად კონვერტირება
        /// </summary>
        /// <param name="geoUnicodeText">ქართული უნიკოდ ტექსტი, რომელიც დაკონვერტირდება ლათინურში</param>
        /// <returns>დაკონვერტირებული ლათინური ტექსტი</returns>
        string GeoUnicodeToLat(string geoUnicodeText);

        /// <summary>
        /// რიცხვის სახელის დასაგენერირებელი ფუნქცია
        /// </summary>
        /// <param name="number">რიცხვი რისი სახელიც გვაინტერესებს</param>
        /// <param name="separator">სახელში გამყოფი ობიექტი, (მაგ: თუ separator = "_" მაშინ რიცხვის 2021 სახელი იქნება "ორი_ათას_ოცდა_ორი" )</param>
        /// <returns>მიწოდებული რიცხვის სახელი</returns>
        string GetNumberName(long number, string separator = "");
    }
}
