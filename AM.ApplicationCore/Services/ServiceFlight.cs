using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services;

public class ServiceFlight:IServiceFlight
{
    //region
    #region Tp1+Tp2
    public List<Flight> Flights { get; set; }=new List<Flight>();

    public IList<DateTime> GetFlightDates(string destination)
    {
        //IList<DateTime> dates = new List<DateTime>();
        //for (int i = 0; i < Flights.Count; i++)
        //{
        //    if (Flights[i].Destination==destination)
        //        dates.Add(Flights[i].FlightDate);

        //}
        //foreach (Flight f in Flights)
        //{
        //    if (f.Destination==destination)
        //    {
        //        dates.Add(f.FlightDate);
        //    }
        //}
        //return dates;

        //linq
        /*var query = from flight in Flights
                    where flight.Destination == destination
                    select flight.FlightDate;
        return query.ToList();*/

        //Lambda
        return Flights.Where(f => f.Destination == destination).//if true go 2 select/select ,where from bib link
            Select(f=>f.FlightDate).ToList();    
    }
    public void GetFlights(string filterType, string filterValue)
    {
        switch (filterType)
        {
            case "Destination":
                foreach (Flight f in Flights)
                {
                    if (f.Destination.Equals(filterValue))
                        Console.WriteLine(f);
                }
                break;
            case "FlightDate":
                foreach (Flight f in Flights)
                {
                    if (f.FlightDate == DateTime.Parse(filterValue))
                        Console.WriteLine(f);
                }
                break;
            case "EffectiveArrival":
                foreach (Flight f in Flights)
                {
                    if (f.EffectiveArrival == DateTime.Parse(filterValue))
                        Console.WriteLine(f);
                }
                break;
        }
    }

    public void ShowFlightDetails(Plane plane)
    {
        //linq
        /* var query = from f in Flights
                     where f.Plane == plane
                     select new { f.FlightDate, f.Destination };*/
        //lambda
        var query = Flights.Where(f => f.Plane == plane).
            Select(f =>new { f.FlightDate, f.Destination });
        foreach (var item in query)
        {
            Console.WriteLine(" flight destination = "+item.Destination+" , and flight date = "+item.FlightDate);
        }
    }
    public int ProgrammedFlightNumber(DateTime startDate)
    {
      /*  var query = from f in Flights
                    where f.FlightDate > startDate && f.FlightDate<startDate.AddDays(7)
                    select f;
        return query.Count();*/
        //Lambda
        return Flights.Count(f => f.FlightDate > startDate && f.FlightDate < startDate.AddDays(7));

    }
    public double DurationAverage(string destination)
    {
        /*var query = from f in Flights
                    where f.Destination == destination
                    select f.EstimatedDuration;
        return query.Average(); */
        /*return (from f in Flights
               where f.Destination == destination   
               select f.EstimatedDuration).Average();*/
        return Flights.Where(f => f.Destination == destination)
              .Average(f => f.EstimatedDuration);
    }
    public IList<Flight> OrderedDurationFlights()
    {
        /* return(from f in Flights
                orderby f.EstimatedDuration descending
                select f).ToList();  */
        return Flights.OrderByDescending(f => f.EstimatedDuration)
               .ToList();
    }
    public IList<Passenger> SeniorTravellers(Flight flight)
    {
        /*    return (from p in flight.Passengers
                   orderby p.BirthDate ascending
                   select p).Take(3).ToList();*/
        return flight.Passengers.OrderBy(p => p.BirthDate)
                            .Take(3)
                            .ToList();
    }

    public void DestinationGroupedFlights()
    {
        /* var query = from f in Flights
                     group f by f.Destination;
         foreach (var f in query)
         {
             Console.WriteLine("Destination = "+f.Key);
             foreach (var item in f)
             {
                 Console.WriteLine("Décollage = "+item.FlightDate);
             }
         }*/
        var query = Flights.GroupBy(f => f.Destination);
        foreach (var group in query)
        {
            Console.WriteLine($"Destination = {group.Key}");
            foreach (var item in group)
            {
                Console.WriteLine($"Décollage = {item.FlightDate}");
            }
        }

    }
    #endregion
    #region delegate
    public Action<Plane> FlightDetailsDel;
    public Func<string, double> DurationAverageDel;
    #endregion    #endregion
}
