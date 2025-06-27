namespace FlightStatusTracker.Model;

public static class Consts
{
    public const string AppTitle = "✈️  Flight Status Tracker (C#)\nType 'exit' to quit.";
    public const string PromptFlightNumber = "Enter flight number (e.g. LH123): ";
    public const string PromptFlightDate = "Enter flight date (yyyy-MM-dd): ";
    public const string FlightNotFound = "Flight not found or invalid data.";
    public const string ApiError = "Error fetching data from API.";
    public const string Goodbye = "Goodbye!";
    public const string Separator = "----------------------------------------------------";
    public const string TableHeader =
        "\nFlight     | Date         | Status     | Departure Airport   | Dep.Time           | Gate  | Arrival Airport     | Arr.Time           | Gate ";
    public const string Menu = "\nType '1' to search history, or 'exit' to quit, or press enter to continue: ";
    public const string PromptSearchHistory = "Search history by flight number: ";
    public const string NoHistory = "No flight history found.";
}