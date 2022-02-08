using Xunit;

namespace Parrot.Tests
{
    public class ParrotTest
    {
        [Fact]
        public void GetSpeedNorwegianBlueParrot_nailed()
        {
            ICanGetSpeed parrot = new ParrotNorwegianBlue(0, true);
            Assert.Equal(0.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedNorwegianBlueParrot_not_nailed()
        {

            ICanGetSpeed parrot = new ParrotNorwegianBlue(1.5, false);
            Assert.Equal(18.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedNorwegianBlueParrot_not_nailed_high_voltage()
        {
            ICanGetSpeed parrot = new ParrotNorwegianBlue(4, false);
            Assert.Equal(24.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedOfAfricanParrot_With_No_Coconuts()
        {
            ICanGetSpeed parrot = new ParrotAfrican(0);
            Assert.Equal(12.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedOfAfricanParrot_With_One_Coconut()
        {
            ICanGetSpeed parrot = new ParrotAfrican(1);
            Assert.Equal(3.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedOfAfricanParrot_With_Two_Coconuts()
        {
            ICanGetSpeed parrot = new ParrotAfrican(2);
            Assert.Equal(0.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedOfEuropeanParrot()
        {
            ICanGetSpeed parrot = new ParrotEuropean();
            Assert.Equal(12.0, parrot.GetSpeed());
        }
    }
}