namespace FlightStatusTracker.Model;

public class FlightModel
{
    public string FlightNumber { get; set; }
    public string Date { get; set; }
    public string Status { get; set; }
    public string DepartureAirport { get; set; }
    public string DepartureTime { get; set; }
    public string DepartureGate { get; set; }
    public string ArrivalAirport { get; set; }
    public string ArrivalTime { get; set; }
    public string ArrivalGate { get; set; }
}
