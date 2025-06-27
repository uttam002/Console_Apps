namespace FlightStatusTracker.Model;

public class AviationStackFlight
{
    public string FlightDate { get; set; }
    public string FlightStatus { get; set; }
    public FlightInfo Flight { get; set; }
    public AirportInfo Departure { get; set; }
    public AirportInfo Arrival { get; set; }
}
