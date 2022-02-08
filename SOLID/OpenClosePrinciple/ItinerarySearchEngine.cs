using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLID.OpenClosePrinciple
{

    public class ItinerarySearchEngine
    {

        public Itinerary OptimalItinerary(Trip trip, IPreference preference)
        {
            return ItinerariesFor(trip).OrderBy(preference.getFilter()).FirstOrDefault();
        }

        private static IEnumerable<Itinerary> ItinerariesFor(Trip trip)
        {
            //fake implementation
            Itinerary directFlight = Itinerary.Of(trip)
                .Labelled("Direct flight")
                .Lasting(TimeSpan.FromHours(12))
                .Connecting(0)
                .Costing(400);

            Itinerary withDubaiStopover = Itinerary.Of(trip)
                .Labelled("With Dubai stopover")
                .Lasting(TimeSpan.FromHours(16))
                .Connecting(1)
                .Costing(200);

            return new[] { directFlight, withDubaiStopover };
        }

    }
}
