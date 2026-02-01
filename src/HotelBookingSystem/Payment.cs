namespace HotelBookingSystem;

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Payment {

  public void calculateCost(DateTime parsedCheckInDate, DateTime parsedCheckOutDate, int numberOfPeople, String roomType)  {

    DateTime checkIn = parsedCheckInDate;
    DateTime checkOut = parsedCheckOutDate;
    double Cost = 0, DaysCost = 0, peoplesCost = 0;
    double roomTypeCost = 0;

    TimeSpan difference = checkOut - checkIn;
    int inclDays = difference.Days + 1;

    if (roomType.Equals("Single_room")) {
      roomTypeCost = 50.00;
    }

    if (roomType.Equals("Double_room")) {
      roomTypeCost = 80.00;
    }

    DaysCost = inclDays * 10.00;
    peoplesCost = numberOfPeople * 30.00;

    Cost = roomTypeCost + DaysCost + peoplesCost;
    Console.WriteLine("Total payment: £ " + Cost);

    Console.WriteLine("Pay status: Yes or No!");
    String payStatus = Console.ReadLine();

    if (payStatus == null || !payStatus.Equals("Yes")) {

      Console.WriteLine("Sorry, we can't proceed until you pay!");
    }
  }   
}
