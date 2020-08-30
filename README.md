# GeorgianHelper
ბიბლიოთეკა შექმნილია პროგრამირებაში ქართული თავისებურებებთან სამუშაოდ.
ბიბლიოთეკე შეიცავს კლასს: "StringHelper:IStringHelper" რომელიც სტრიქონებთან სამუშაოდ დამხმარე ხელსაწყოდ გამოდგება.

StringHelper:IStringHelper აქვს ფუნქციები:
  1. string GeoUnicodeToLat(string geoUnicodeText)
  2. string GetNumberName(long number, string separator = "")

1. string GeoUnicodeToLat(string geoUnicodeText)
  გამოიყენება ქართული ტექსტის ლათინურში გადასაკონვერტირებლად, 
  მისი ძირითადი გამოყენება არის მოკლე ტექსტური შეტყობინებების გაგზავნისას ქართული უნიკოდი ტექსტი როცა გვჭირდება გავგზავნოთ კათინური ასოებით.
  
2. string GetNumberName(long number, string separator = "")
  გამოიყენება long ტიპის მნიშვნელობის რიცხვის ქართული სახელწოდების დასაგენერირებლად
  მისი ძირითადი გამოყენება არის ფინანსურ სფეროში სადაც საჭიროა რიცხვი როგორც რიცხვად ისე სიტყვიერად იყოს წარმოდგენილი.
