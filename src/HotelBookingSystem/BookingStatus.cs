using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


class BookingStatus {

  public void bookingInformation(string email) {
    
    List<string> emails = createAccount.getEmailAddresses();
    
    for (int i = 0; i < emails.Count; i++) {
      if (emails[i].Equals(email)) {
        Console.WriteLine("Room Type: " + roomBooking.getRoomTypes()[i]);
        Console.WriteLine("Room Number: " + roomBooking.getRoomNumbers()[i]);
        Console.WriteLine("Check-In Date: " + roomBooking.getCheckInDates()[i]);
        Console.WriteLine("Check-Out Date: " + roomBooking.getCheckOutDates()[i]);
        Console.WriteLine("Number of People: " + roomBooking.getNumbersOfPeople()[i]);
        return;
      }
    }
    Console.WriteLine("No booking found for this email.");
  }  
}
