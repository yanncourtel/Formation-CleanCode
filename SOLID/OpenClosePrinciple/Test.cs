using System;
using Xunit;

namespace SOLID.OpenClosePrinciple
{

    public class ItinerarySearchTest
    {

        private readonly ItinerarySearchEngine search = new ItinerarySearchEngine();

        [Fact]
        public void should_find_shortest_itinerary()
        {
            var trip = Trip.from(City.Paris).to(City.Tokyo);

            var shortest = search.OptimalItinerary(trip, new ShortestPreference());

            Assert.NotNull(shortest);
            Assert.Equal("Direct flight", shortest.Label);
        }

        [Fact]
        public void should_find_cheapest_itinerary()
        {
            var trip = Trip.from(City.Paris).to(City.Tokyo);

            var cheapest = search.OptimalItinerary(trip, new CheapestPreference());

            Assert.NotNull(cheapest);
            Assert.Equal("With Dubai stopover", cheapest.Label);
        }

    }

    internal class CheapestPreference : IPreference
    {
        public CheapestPreference()
        {
        }

        public Func<Itinerary, object> getFilter()
        {
            return i => i.Cost;
        }
    }

    internal class ShortestPreference: IPreference
    {
        public ShortestPreference()
        {
        }

        public Func<Itinerary, object> getFilter()
        {
            return i => i.Duration;
        }
    }

    public  interface IPreference
    {
        Func<Itinerary, object> getFilter();
    }
}
