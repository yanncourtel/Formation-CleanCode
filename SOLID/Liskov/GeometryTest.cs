using Xunit;

namespace SOLID.Liskov
{
    public class GeometryTest
    {
        [Fact]
        public void Area_should_be_height_times_width_1()
        {
            var rect = new Rectangle(width:5, height:4);
            Assert.Equal(20, rect.Area);
        }

        [Fact]
        public void Area_should_be_height_times_width_2()
        {
            var rect = new Square(side: 5);
            Assert.Equal(25, rect.Area);
        }

    }
}