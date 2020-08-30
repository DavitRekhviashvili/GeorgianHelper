using FluentAssertions;
using GeorgianHelper.Abstraction;
using Xunit;

namespace GeorgianHelper.Tests
{
    public class StringHelperTests
    {
        [Theory]
        [InlineData(0, "ნული")]
        [InlineData(1, "ერთი")]
        [InlineData(2, "ორი")]
        [InlineData(3, "სამი")]
        [InlineData(4, "ოთხი")]
        [InlineData(5, "ხუთი")]
        [InlineData(6, "ექვსი")]
        [InlineData(7, "შვიდი")]
        [InlineData(8, "რვა")]
        [InlineData(9, "ცხრა")]
        [InlineData(10, "ათი")]
        [InlineData(11, "თერთმეტი")]
        [InlineData(12, "თორმეტი")]
        [InlineData(13, "ცამეტი")]
        [InlineData(14, "თოთხმეტი")]
        [InlineData(15, "თხუთმეტი")]
        [InlineData(16, "თექვსმეტი")]
        [InlineData(17, "ჩვიდმეტი")]
        [InlineData(18, "თვრამეტი")]
        [InlineData(19, "ცხრამეტი")]
        [InlineData(20, "ოცი")]
        [InlineData(40, "ორმოცი")]
        [InlineData(60, "სამოცი")]
        [InlineData(80, "ოთხმოცი")]
        [InlineData(100, "ასი")]
        [InlineData(111, "ასთერთმეტი")]
        [InlineData(101, "ასერთი")]
        [InlineData(102, "ასორი")]
        [InlineData(103, "ასსამი")]
        [InlineData(104, "ასოთხი")]
        [InlineData(105, "ასხუთი")]
        [InlineData(106, "ასექვსი")]
        [InlineData(107, "ასშვიდი")]
        [InlineData(108, "ასრვა")]
        [InlineData(109, "ასცხრა")]
        [InlineData(200, "ორასი")]
        [InlineData(300, "სამასი")]
        [InlineData(400, "ოთხასი")]
        [InlineData(500, "ხუთასი")]
        [InlineData(600, "ექვსასი")]
        [InlineData(700, "შვიდასი")]
        [InlineData(800, "რვაასი")]
        [InlineData(900, "ცხრაასი")]
        [InlineData(1000, "ერთიათასი")]
        [InlineData(1001, "ერთიათასერთი")]
        [InlineData(1002, "ერთიათასორი")]
        [InlineData(1003, "ერთიათასსამი")]
        [InlineData(1004, "ერთიათასოთხი")]
        [InlineData(1005, "ერთიათასხუთი")]
        [InlineData(1006, "ერთიათასექვსი")]
        [InlineData(1007, "ერთიათასშვიდი")]
        [InlineData(1008, "ერთიათასრვა")]
        [InlineData(1009, "ერთიათასცხრა")]
        [InlineData(10000, "ათიათასი")]
        [InlineData(100000, "ასიათასი")]
        [InlineData(1000000, "ერთიმილიონი")]
        [InlineData(10000000, "ათიმილიონი")]
        [InlineData(100000000, "ასიმილიონი")]
        [InlineData(1000000000, "ერთიმილიარდი")]
        [InlineData(10000000000, "ათიმილიარდი")]
        [InlineData(100000000000, "ასიმილიარდი")]
        [InlineData(1000000000000, "ერთიტრილიონი")]
        [InlineData(10000000000000, "ათიტრილიონი")]
        [InlineData(100000000000000, "ასიტრილიონი")]
        [InlineData(1000000000000000, "ერთიკვადრილიონი")]
        [InlineData(10000000000000000, "ათიკვადრილიონი")]
        [InlineData(100000000000000000, "ასიკვადრილიონი")]
        [InlineData(1000000000000000000, "ერთიკვინტილიონი")]
        [InlineData(1010101010101101010, "ერთიკვინტილიონათიკვადრილიონასერთიტრილიონათიმილიარდასერთიმილიონასერთიათასათი")]
        public void GetNumberNameTests(long digit, string digitName)
        {
            //Arrange
            IStringHelper textTransformHelper = new StringHelper();

            //Act
            var word = textTransformHelper.GetNumberName(digit);

            //Assert
            word.Should().Be(digitName);
        }

        [Theory]
        [InlineData(0, " ", "ნული")]
        [InlineData(1, " ", "ერთი")]
        [InlineData(2, " ", "ორი")]
        [InlineData(3, " ", "სამი")]
        [InlineData(4, " ", "ოთხი")]
        [InlineData(5, " ", "ხუთი")]
        [InlineData(6, " ", "ექვსი")]
        [InlineData(7, " ", "შვიდი")]
        [InlineData(8, " ", "რვა")]
        [InlineData(9, " ", "ცხრა")]
        [InlineData(10, " ", "ათი")]
        [InlineData(11, " ", "თერთმეტი")]
        [InlineData(12, " ", "თორმეტი")]
        [InlineData(13, " ", "ცამეტი")]
        [InlineData(14, " ", "თოთხმეტი")]
        [InlineData(15, " ", "თხუთმეტი")]
        [InlineData(16, " ", "თექვსმეტი")]
        [InlineData(17, " ", "ჩვიდმეტი")]
        [InlineData(18, " ", "თვრამეტი")]
        [InlineData(19, " ", "ცხრამეტი")]
        [InlineData(20, " ", "ოცი")]
        [InlineData(40, " ", "ორმოცი")]
        [InlineData(60, " ", "სამოცი")]
        [InlineData(80, " ", "ოთხმოცი")]
        [InlineData(100, " ", "ასი")]
        [InlineData(101, " ", "ას ერთი")]
        [InlineData(222, " ", "ორას ოცდა ორი")]
        [InlineData(2322, " ", "ორი ათას სამას ოცდა ორი")]
        [InlineData(22422, " ", "ოცდა ორი ათას ოთხას ოცდა ორი")]
        [InlineData(22520, "_", "ოცდა_ორი_ათას_ხუთას_ოცი")]
        [InlineData(20600, " ", "ოცი ათას ექვსასი")]
        [InlineData(200700, " ", "ორასი ათას შვიდასი")]
        [InlineData(2800900, " ", "ორი მილიონ რვაასი ათას ცხრაასი")]
        [InlineData(90800900, " ", "ოთხმოცდა ათი მილიონ რვაასი ათას ცხრაასი")]
        [InlineData(1010800900, " ", "ერთი მილიარდ ათი მილიონ რვაასი ათას ცხრაასი")]
        [InlineData(60010800900, " ", "სამოცი მილიარდ ათი მილიონ რვაასი ათას ცხრაასი")]
        [InlineData(760010800900, " ", "შვიდას სამოცი მილიარდ ათი მილიონ რვაასი ათას ცხრაასი")]
        [InlineData(1760010800900, " ", "ერთი ტრილიონ შვიდას სამოცი მილიარდ ათი მილიონ რვაასი ათას ცხრაასი")]
        [InlineData(23760010800900, " ", "ოცდა სამი ტრილიონ შვიდას სამოცი მილიარდ ათი მილიონ რვაასი ათას ცხრაასი")]
        [InlineData(145760010800900, " ", "ას ორმოცდა ხუთი ტრილიონ შვიდას სამოცი მილიარდ ათი მილიონ რვაასი ათას ცხრაასი")]
        [InlineData(4145760010800900, " ", "ოთხი კვადრილიონ ას ორმოცდა ხუთი ტრილიონ შვიდას სამოცი მილიარდ ათი მილიონ რვაასი ათას ცხრაასი")]
        [InlineData(40145760010800900, " ", "ორმოცი კვადრილიონ ას ორმოცდა ხუთი ტრილიონ შვიდას სამოცი მილიარდ ათი მილიონ რვაასი ათას ცხრაასი")]
        [InlineData(411145760010800900, " ", "ოთხას თერთმეტი კვადრილიონ ას ორმოცდა ხუთი ტრილიონ შვიდას სამოცი მილიარდ ათი მილიონ რვაასი ათას ცხრაასი")]
        [InlineData(2411145760010800900, " ", "ორი კვინტილიონ ოთხას თერთმეტი კვადრილიონ ას ორმოცდა ხუთი ტრილიონ შვიდას სამოცი მილიარდ ათი მილიონ რვაასი ათას ცხრაასი")]
        public void GetNumberName_SeparatorTests(long digit, string separator, string digitName)
        {
            //Arrange
            IStringHelper textTransformHelper = new StringHelper();

            //Act
            var word = textTransformHelper.GetNumberName(digit, separator);

            //Assert
            word.Should().Be(digitName);
        }

        [Theory]
        [InlineData("ტესტი", "testi")]
        [InlineData("დიგი2200", "digi2200")]
        [InlineData("ჩახმახი", "chakhmakhi")]
        [InlineData("წვენი", "tsveni")]
        [InlineData("ჟუჟუნა", "djudjuna")]
        [InlineData("7 ჯუჯა", "7 juja")]
        [InlineData("გულთგონთახარ?", "gultgontakhar?")]
        [InlineData("ყაყაჩო", "yayacho")]
        [InlineData("ძუა", "dzua")]
        [InlineData("ცა", "ca")]
        [InlineData("შაშვი", "shashvi")]
        [InlineData("ღვინო", "gvino")]
        [InlineData("ქვეყანა", "qveyana")]
        [InlineData("ფანქარი", "fanqari")]
        [InlineData("პეპელა", "pepela")]
        [InlineData("კრაზანა", "krazana")]
        [InlineData("ბაყაყი", "bayayi")]
        [InlineData("ჭრიჭინა", "chrichina")]
        [InlineData("ჰამაკი", "hamaki")]
        public void GeoUnicodeToLat(string geoText, string latText)
        {
            //Arrange
            IStringHelper stringHelper = new StringHelper();

            //Act
            var word = stringHelper.GeoUnicodeToLat(geoText);

            //Assert
            word.Should().Be(latText);
        }
    }
}
