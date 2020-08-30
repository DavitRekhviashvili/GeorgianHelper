using System;
using System.Text;
using GeorgianHelper.Abstraction;

namespace GeorgianHelper
{
    public class StringHelper:IStringHelper
    {
        public string GeoUnicodeToLat(string geoUnicodeText)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var c in geoUnicodeText)
            {
                switch (c)
                {
                    case 'ა':
                        stringBuilder.Append('a');
                        break;
                    case 'ბ':
                        stringBuilder.Append('b');
                        break;
                    case 'გ':
                        stringBuilder.Append('g');
                        break;
                    case 'დ':
                        stringBuilder.Append('d');
                        break;
                    case 'ე':
                        stringBuilder.Append('e');
                        break;
                    case 'ვ':
                        stringBuilder.Append('v');
                        break;
                    case 'ზ':
                        stringBuilder.Append('z');
                        break;
                    case 'თ':
                        stringBuilder.Append('t');
                        break;
                    case 'ი':
                        stringBuilder.Append('i');
                        break;
                    case 'კ':
                        stringBuilder.Append('k');
                        break;
                    case 'ლ':
                        stringBuilder.Append('l');
                        break;
                    case 'მ':
                        stringBuilder.Append('m');
                        break;
                    case 'ნ':
                        stringBuilder.Append('n');
                        break;
                    case 'ო':
                        stringBuilder.Append('o');
                        break;
                    case 'პ':
                        stringBuilder.Append('p');
                        break;
                    case 'ჟ':
                        stringBuilder.Append("dj");
                        break;
                    case 'რ':
                        stringBuilder.Append('r');
                        break;
                    case 'ს':
                        stringBuilder.Append('s');
                        break;
                    case 'ტ':
                        stringBuilder.Append('t');
                        break;
                    case 'უ':
                        stringBuilder.Append('u');
                        break;
                    case 'ფ':
                        stringBuilder.Append('f');
                        break;
                    case 'ქ':
                        stringBuilder.Append('q');
                        break;
                    case 'ღ':
                        stringBuilder.Append('g');
                        break;
                    case 'ყ':
                        stringBuilder.Append('y');
                        break;
                    case 'შ':
                        stringBuilder.Append("sh");
                        break;
                    case 'ჩ':
                        stringBuilder.Append("ch");
                        break;
                    case 'ც':
                        stringBuilder.Append('c');
                        break;
                    case 'ძ':
                        stringBuilder.Append("dz");
                        break;
                    case 'წ':
                        stringBuilder.Append("ts");
                        break;
                    case 'ჭ':
                        stringBuilder.Append("ch");
                        break;
                    case 'ხ':
                        stringBuilder.Append("kh");
                        break;
                    case 'ჯ':
                        stringBuilder.Append('j');
                        break;
                    case 'ჰ':
                        stringBuilder.Append('h');
                        break;
                    default:
                        stringBuilder.Append(c);
                        break;
                }
            }
            return stringBuilder.ToString();
        }

        #region DigitToWord
        string GetOneSignDigitName(string digit)
        {
            if (digit.Length == 1)
            {
                switch (digit[0])
                {
                    case '0': return "ი";
                    case '1': return "ერთი";
                    case '2': return "ორი";
                    case '3': return "სამი";
                    case '4': return "ოთხი";
                    case '5': return "ხუთი";
                    case '6': return "ექვსი";
                    case '7': return "შვიდი";
                    case '8': return "რვა";
                    case '9': return "ცხრა";
                }
            }
            return "";
        }
        string GetToNineteenName(string number)
        {
            if (number.Length == 2)
            {
                switch (number)
                {
                    case "10": return "ათი";
                    case "11": return "თერთმეტი";
                    case "12": return "თორმეტი";
                    case "13": return "ცამეტი";
                    case "14": return "თოთხმეტი";
                    case "15": return "თხუთმეტი";
                    case "16": return "თექვსმეტი";
                    case "17": return "ჩვიდმეტი";
                    case "18": return "თვრამეტი";
                    case "19": return "ცხრამეტი";
                }
            }
            else if (number.Length < 2)
            {
                return GetOneSignDigitName(number);
            }
            return "";
        }
        string GetTwoSignDigitName(string number, string separator)
        {
            if (number.Length == 2)
            {
                var integer = Convert.ToInt64(number);
                switch (number[0])
                {
                    case '0': return GetOneSignDigitName(number[1].ToString());
                    case '1': return GetToNineteenName(number);
                    case '2':
                    case '3': return number == "20" ? "ოცი" : $"ოცდა{separator}{GetToNineteenName((integer % 20).ToString())}";
                    case '4':
                    case '5': return number == "40" ? "ორმოცი" : $"ორმოცდა{separator}{GetToNineteenName((integer % 20).ToString())}";
                    case '6':
                    case '7': return number == "60" ? "სამოცი" : $"სამოცდა{separator}{GetToNineteenName((integer % 20).ToString())}";
                    case '8':
                    case '9': return number == "80" ? "ოთხმოცი" : $"ოთხმოცდა{separator}{GetToNineteenName((integer % 20).ToString())}";
                }
            }
            else if (number.Length < 2)
            {
                return GetOneSignDigitName(number);
            }
            return "";
        }
        string GetThreeSignDigitName(string number, string separator)
        {
            if (number.Length == 3)
            {
                var ineger = Convert.ToInt64(number);
                var twoSignDigitName = GetTwoSignDigitName(Convert.ToString(ineger % 100), separator);
                switch (number[0])
                {
                    case '0': return GetTwoSignDigitName($"{number[1]}{number[2]}", separator);
                    case '1': return $"ას{(twoSignDigitName == "ი" ? twoSignDigitName : $"{separator}{twoSignDigitName}")}";
                    case '2': return $"ორას{(twoSignDigitName == "ი" ? twoSignDigitName : $"{separator}{twoSignDigitName}")}";
                    case '3': return $"სამას{(twoSignDigitName == "ი" ? twoSignDigitName : $"{separator}{twoSignDigitName}")}";
                    case '4': return $"ოთხას{(twoSignDigitName == "ი" ? twoSignDigitName : $"{separator}{twoSignDigitName}")}";
                    case '5': return $"ხუთას{(twoSignDigitName == "ი" ? twoSignDigitName : $"{separator}{twoSignDigitName}")}";
                    case '6': return $"ექვსას{(twoSignDigitName == "ი" ? twoSignDigitName : $"{separator}{twoSignDigitName}")}";
                    case '7': return $"შვიდას{(twoSignDigitName == "ი" ? twoSignDigitName : $"{separator}{twoSignDigitName}")}";
                    case '8': return $"რვაას{(twoSignDigitName == "ი" ? twoSignDigitName : $"{separator}{twoSignDigitName}")}";
                    case '9': return $"ცხრაას{(twoSignDigitName == "ი" ? twoSignDigitName : $"{separator}{twoSignDigitName}")}";
                }
            }
            else if (number.Length < 3)
            {
                return GetTwoSignDigitName(number, separator);
            }
            return "";
        }
        string GetFourSignDigitName(string number, string separator)
        {
            if (number.Length == 4)
            {
                var substringWithOutFirst = number.Substring(1);
                switch (number[0])
                {
                    case '0': return GetThreeSignDigitName(substringWithOutFirst, separator);
                    default: return $"{GetThreeSignDigitName(number[0].ToString(), separator)}{separator}ათას{separator}{(GetThreeSignDigitName(substringWithOutFirst, separator))}";
                }
            }
            else if (number.Length < 4)
            {
                return GetThreeSignDigitName(number, separator);
            }
            return "";
        }
        string GetFiveSignDigitName(string number, string separator)
        {
            if (number.Length == 5)
            {
                switch (number[0])
                {
                    case '0': return GetFourSignDigitName(number.Substring(1), separator);
                    default: return $"{GetThreeSignDigitName(number.Substring(0, 2), separator)}{separator}ათას{separator}{GetThreeSignDigitName(number.Substring(2), separator)}";
                }
            }
            else if (number.Length < 5)
            {
                return GetFourSignDigitName(number, separator);
            }
            return "";
        }
        string GetSixSignDigitName(string number, string separator)
        {
            if (number.Length == 6)
            {
                switch (number[0])
                {
                    case '0': return GetFiveSignDigitName(number.Substring(1), separator);
                    default: return $"{GetThreeSignDigitName(number.Substring(0, 3), separator)}{separator}ათას{separator}{GetThreeSignDigitName(number.Substring(3), separator)}";
                }
            }
            else if (number.Length < 6)
            {
                return GetFiveSignDigitName(number, separator);
            }
            return "";
        }
        string GetSevenSignDigitName(string number, string separator)
        {
            if (number.Length == 7)
            {
                var substringWithOutFirst = number.Substring(1);
                switch (number[0])
                {
                    case '0': return GetSixSignDigitName(substringWithOutFirst, separator);
                    default: return $"{GetSixSignDigitName(number.Substring(0, 1), separator)}{separator}მილიონ{separator}{GetSixSignDigitName(substringWithOutFirst, separator)}";
                }
            }
            else if (number.Length < 7)
            {
                return GetSixSignDigitName(number, separator);
            }
            return "";
        }
        string GetEightSignDigitName(string number, string separator)
        {
            if (number.Length == 8)
            {
                switch (number[0])
                {
                    case '0': return GetSevenSignDigitName(number.Substring(1), separator);
                    default: return $"{GetSixSignDigitName(number.Substring(0, 2), separator)}{separator}მილიონ{separator}{GetSixSignDigitName(number.Substring(2), separator)}";
                }
            }
            else if (number.Length < 8)
            {
                return GetSevenSignDigitName(number, separator);
            }
            return "";
        }
        string GetNineSignDigitName(string number, string separator)
        {
            if (number.Length == 9)
            {
                switch (number[0])
                {
                    case '0': return GetEightSignDigitName(number.Substring(1), separator);
                    default: return $"{GetSixSignDigitName(number.Substring(0, 3), separator)}{separator}მილიონ{separator}{GetSixSignDigitName(number.Substring(3), separator)}";
                }
            }
            else if (number.Length < 9)
            {
                return GetEightSignDigitName(number, separator);
            }
            return "";
        }
        string GetTenSignDigitName(string number, string separator)
        {
            if (number.Length == 10)
            {
                var substringWithOutFirst = number.Substring(1);
                switch (number[0])
                {
                    case '0': return GetNineSignDigitName(substringWithOutFirst, separator);
                    default: return $"{GetNineSignDigitName(number.Substring(0, 1), separator)}{separator}მილიარდ{separator}{GetNineSignDigitName(substringWithOutFirst, separator)}";
                }
            }
            else if (number.Length < 10)
            {
                return GetNineSignDigitName(number, separator);
            }
            return "";
        }
        string GetElevenSignDigitName(string number, string separator)
        {
            if (number.Length == 11)
            {
                switch (number[0])
                {
                    case '0': return GetTenSignDigitName(number.Substring(1), separator);
                    default: return $"{GetNineSignDigitName(number.Substring(0, 2), separator)}{separator}მილიარდ{separator}{GetNineSignDigitName(number.Substring(2), separator)}";
                }
            }
            else if (number.Length < 11)
            {
                return GetTenSignDigitName(number, separator);
            }
            return "";
        }
        string GetTwelveSignDigitName(string number, string separator)
        {
            if (number.Length == 12)
            {
                switch (number[0])
                {
                    case '0': return GetElevenSignDigitName(number.Substring(1), separator);
                    default: return $"{GetNineSignDigitName(number.Substring(0, 3), separator)}{separator}მილიარდ{separator}{GetNineSignDigitName(number.Substring(3), separator)}";
                }
            }
            else if (number.Length < 12)
            {
                return GetElevenSignDigitName(number, separator);
            }
            return "";
        }
        string GetThirteenSignDigitName(string number, string separator)
        {
            if (number.Length == 13)
            {
                var substringWithOutFirst = number.Substring(1);
                switch (number[0])
                {
                    case '0': return GetTwelveSignDigitName(substringWithOutFirst, separator);
                    default: return $"{GetTwelveSignDigitName(number.Substring(0, 1), separator)}{separator}ტრილიონ{separator}{GetTwelveSignDigitName(substringWithOutFirst, separator)}";
                }
            }
            else if (number.Length < 13)
            {
                return GetTwelveSignDigitName(number, separator);
            }
            return "";
        }
        string GetFourteenSignDigitName(string number, string separator)
        {
            if (number.Length == 14)
            {
                switch (number[0])
                {
                    case '0': return GetThirteenSignDigitName(number.Substring(1), separator);
                    default: return $"{GetTwelveSignDigitName(number.Substring(0, 2), separator)}{separator}ტრილიონ{separator}{GetTwelveSignDigitName(number.Substring(2), separator)}";
                }
            }
            else if (number.Length < 14)
            {
                return GetThirteenSignDigitName(number, separator);
            }
            return "";
        }
        string GetFiveteenSignDigitName(string number, string separator)
        {
            if (number.Length == 15)
            {
                switch (number[0])
                {
                    case '0': return GetFourteenSignDigitName(number.Substring(1), separator);
                    default: return $"{GetTwelveSignDigitName(number.Substring(0, 3), separator)}{separator}ტრილიონ{separator}{GetTwelveSignDigitName(number.Substring(3), separator)}";
                }
            }
            else if (number.Length < 15)
            {
                return GetFourteenSignDigitName(number, separator);
            }
            return "";
        }
        string GetSixteenSignDigitName(string number, string separator)
        {
            if (number.Length == 16)
            {
                var substringWithOutFirst = number.Substring(1);
                switch (number[0])
                {
                    case '0': return GetFiveteenSignDigitName(substringWithOutFirst, separator);
                    default: return $"{GetFiveteenSignDigitName(number.Substring(0, 1), separator)}{separator}კვადრილიონ{separator}{GetFiveteenSignDigitName(substringWithOutFirst, separator)}";
                }
            }
            else if (number.Length < 16)
            {
                return GetFiveteenSignDigitName(number, separator);
            }
            return "";
        }
        string GetSeventeenSignDigitName(string number, string separator)
        {
            if (number.Length == 17)
            {
                switch (number[0])
                {
                    case '0': return GetSixteenSignDigitName(number.Substring(1), separator);
                    default: return $"{GetFiveteenSignDigitName(number.Substring(0, 2), separator)}{separator}კვადრილიონ{separator}{GetFiveteenSignDigitName(number.Substring(2), separator)}";
                }
            }
            else if (number.Length < 17)
            {
                return GetSixteenSignDigitName(number, separator);
            }
            return "";
        }
        string GetEightteenSignDigitName(string number, string separator)
        {
            if (number.Length == 18)
            {
                switch (number[0])
                {
                    case '0': return GetSeventeenSignDigitName(number.Substring(1), separator);
                    default: return $"{GetFiveteenSignDigitName(number.Substring(0, 3), separator)}{separator}კვადრილიონ{separator}{GetFiveteenSignDigitName(number.Substring(3), separator)}";
                }
            }
            else if (number.Length < 18)
            {
                return GetSeventeenSignDigitName(number, separator);
            }
            return "";
        }
        string GetNineteenSignDigitName(string number, string separator)
        {
            if (number.Length == 19)
            {
                var substringWithOutFirst = number.Substring(1);
                switch (number[0])
                {
                    case '0': return GetEightteenSignDigitName(substringWithOutFirst, separator);
                    default: return $"{GetEightteenSignDigitName(number.Substring(0, 1), separator)}{separator}კვინტილიონ{separator}{GetEightteenSignDigitName(substringWithOutFirst, separator)}";
                }
            }
            else if (number.Length < 19)
            {
                return GetEightteenSignDigitName(number, separator);
            }
            return "";
        }

        public string GetNumberName(long number, string separator = "")
        {
            var result = number == 0 ? "ნული" : GetNineteenSignDigitName(number.ToString(), separator);
            return result;
        }
        #endregion
    }
}
