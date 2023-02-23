using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces;

public interface IServiceFlight
{
    public IList<DateTime> GetFlightDates(string destination);
    public void GetFlights(string filterType, string filterValue);
    public void ShowFlightDetails(Plane plane);

}
