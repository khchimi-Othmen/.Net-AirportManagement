// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, World!");
#region TP 1
// avec constructeur vide
Plane plane = new Plane();
plane.Capacity = 200;
plane.PlaneType = PlaneType.Airbus;
plane.ManufactureDate = DateTime.Now;
//cwl +2 tab
Console.WriteLine("Plane 1 information = "+plane.ToString());
//avec un constructeur paramétré
Plane plane2 = new Plane(150,DateTime.Now,1,PlaneType.Airbus);
Console.WriteLine("Plane 2 Information = "+plane2.ToString());
//avec initialiseur d'objet
Plane plane3 = new Plane {
    Capacity = 200,
    PlaneType = PlaneType.Airbus,
    ManufactureDate = new DateTime(2023,12,30),

};
Console.WriteLine("Plane 3 Information = " + plane2.ToString());
Passenger passenger = new Passenger()
{
    FirstName="Ameni",
    LastName="Belhadj",
    BirthDate=new DateTime(2020,10,10),
    TelNumber="+21620123456",
    EmailAddress="ameni@esprit.tn",
    PassportNumber="123456789"
};
Staff staff = new Staff()
{
    FirstName = "Mariem",
    LastName = "Ellech",
    BirthDate = new DateTime(2020, 10, 10),
    TelNumber = "+21620123456",
    EmailAddress = "mariem@esprit.tn",
    PassportNumber = "4444449",
    EmploymentDate=new DateTime(2020,12,12),
    Function="Capitaine",
    Salary=360000
};
//cw + 2tab
Console.WriteLine(" first passenger is :"+passenger.PassengerType());
Console.WriteLine(" second passenger is : "+staff.PassengerType());
#endregion
#region TP 2
ServiceFlight serviceFlight = new ServiceFlight();
serviceFlight.Flights = TestData.listFlights;

// Test des méthodes de ServiceFlight
Console.WriteLine("Flights for a given plane:");
serviceFlight.ShowFlightDetails(plane);

Console.WriteLine("Number of flights programmed for a given week:");
Console.WriteLine(serviceFlight.ProgrammedFlightNumber(new DateTime(2023, 2, 1)));

Console.WriteLine("Average duration for a given destination:");
Console.WriteLine(serviceFlight.DurationAverage("Tunis"));

Console.WriteLine("Flights ordered by duration:");
foreach (var flight in serviceFlight.OrderedDurationFlights())
{
    Console.WriteLine("Flight duration: " + flight.EstimatedDuration);
}



Console.WriteLine("Grouped flights by destination:");
serviceFlight.DestinationGroupedFlights();
#endregion
