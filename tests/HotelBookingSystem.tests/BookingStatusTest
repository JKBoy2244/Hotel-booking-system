using System;
using System.IO;
using Xunit;

// Change this namespace to match your actual project namespace
using HotelBookingSystem;

public class BookingStatusTests
{
    [Fact]
    public void bookingInformation_WhenEmailExists_PrintsBookingDetails()
    {
        // Arrange: ensure a clean slate
        var emails = createAccount.getEmailAddresses();
        var types  = roomBooking.getRoomTypes();
        var nums   = roomBooking.getRoomNumbers();
        var inDates  = roomBooking.getCheckInDates();
        var outDates = roomBooking.getCheckOutDates();
        var people = roomBooking.getNumbersOfPeople();

        emails.Clear();
        types.Clear();
        nums.Clear();
        inDates.Clear();
        outDates.Clear();
        people.Clear();

        // Add one booking at index 0
        emails.Add("a@test.com");
        types.Add("Single_room");
        nums.Add("101");
        inDates.Add("2026-01-10");
        outDates.Add("2026-01-12");
        people.Add(2);

        // Capture console output
        var sw = new StringWriter();
        var originalOut = Console.Out;
        Console.SetOut(sw);

        try
        {
            var status = new BookingStatus();

            // Act
            status.bookingInformation("a@test.com");

            // Assert
            string output = sw.ToString();

            Assert.Contains("Room Type: Single_room", output);
            Assert.Contains("Room Number: 101", output);
            Assert.Contains("Check-In Date: 2026-01-10", output);
            Assert.Contains("Check-Out Date: 2026-01-12", output);
            Assert.Contains("Number of People: 2", output);
        }
        finally
        {
            // Always restore Console.Out
            Console.SetOut(originalOut);
        }
    }

    [Fact]
    public void bookingInformation_WhenEmailDoesNotExist_PrintsNotFoundMessage()
    {
        // Arrange
        var emails = createAccount.getEmailAddresses();
        emails.Clear();
        emails.Add("someoneelse@test.com");

        var sw = new StringWriter();
        var originalOut = Console.Out;
        Console.SetOut(sw);

        try
        {
            var status = new BookingStatus();

            // Act
            status.bookingInformation("missing@test.com");

            // Assert
            string output = sw.ToString();
            Assert.Contains("No booking found for this email.", output);
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }
}
