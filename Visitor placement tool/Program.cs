using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Visitor_placement_tool;
using Group = Visitor_placement_tool.Group;

public class Program
{
    public static void Main(string[] args)
    {
        // Er wordt input verwacht van de gebruiker
        int capacityEventAmount = GetCapacityEvent();
        DateTime eventDate = GetEventDate();
        DateTime registerDeadline = GetRegisterDeadLine(eventDate);
        int amountVisitors = GetAmountVistors();

        //Maak event aan op basis van input
        Event @event = new Event(eventDate, registerDeadline, capacityEventAmount);
        List<Group> groups = GroupGenerator.Creategroups(amountVisitors, eventDate);


        // voor elke groep in groepen => in elke bezoeker die is toegestaan in het evenement => voeg toe aan list
        @event.FilterAllowedVisitors(groups);

        // voor elke groep in groepen => in elke bezoeker die niet is toegestaan in het evenement => voeg toe aan list
        @event.FilterRejectedVisitors(groups);
               
        //first come first serve
        @event.RejectOverbookedVisitors(groups);

        //sorteer groeps in grootte
        @event.SortGroups(ref groups);

        // plaats van groepen in vakken
        
        @event.PlaceGroups(groups, @event);

        Console.WriteLine($"Totaal stoelen in het event: {@event.TotalSeats()}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Totaal toegestane bezoekers op het event: {@event.AllowedVisitors.Count}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Totaal geweigerde bezoekers op het event: {@event.RejectedVisitors.Count}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// Krijg de hoeveel bezoekers terug die in het event passen terug
    /// </summary>
    /// <returns></returns>
    private static int GetCapacityEvent()
    {
        Console.WriteLine("Hoeveel bezoekers passen er in het evenement?");
        var input = Console.ReadLine();
        int output;
        // als de input niet groter is dan nul of iets anders geef dan een melding

        if (int.TryParse(input, out output))
        {
            if (output > 0)
            {
                return output;
            }
        }
        Console.WriteLine("Vul een getal in groter dan 0");
        return GetCapacityEvent();
    }

    /// <summary>
    /// Krijg de datum terug van het event
    /// </summary>
    /// <returns></returns>
    private static DateTime GetEventDate()
    {
        Console.WriteLine("Wanneer vind de evenement plaats?");

        var input = Console.ReadLine();
        DateTime output;
        if (DateTime.TryParse(input, out output))
        {
            if (output > DateTime.Now)
            {
                return output;
            }
            Console.WriteLine("Deze datum is al overscheden");
        }
        Console.WriteLine("Voer een geldige datum in!");
        return GetEventDate();
    }

    /// <summary>
    /// krijg de deadline datum terug
    /// </summary>
    /// <param name="eventDate">Datum van het event</param>
    /// <returns></returns>
    private static DateTime GetRegisterDeadLine(DateTime eventDate)
    {
        Console.WriteLine("Hoeveel dagen van te voren moet de bezoeker reserveren?");

        var input = Console.ReadLine();
        int output;
        if (int.TryParse(input, out output))
        {
            if (output > 0)
            {
                return eventDate.AddDays(-output);
            }

            Console.WriteLine("Deze datum is al overscheden");

        }
        Console.WriteLine("Vul een getal in ");
        return GetRegisterDeadLine(eventDate);
    }
    /// <summary>
    /// Hoeveel bezoekers in totaal komen naar het event
    /// </summary>
    /// <returns></returns>
    private static int GetAmountVistors()
    {
        Console.WriteLine("Hoeveel bezoekers hebben zich aangemeld?");
        var input = Console.ReadLine();
        int output;
        // als de input niet groter is dan nul of iets anders geef dan een melding

        if (int.TryParse(input, out output))
        {
            if (output > 0)
            {
                return output;
            }
        }
        Console.WriteLine("Vul een getal in groter dan 0");
        return GetAmountVistors();
    }
}