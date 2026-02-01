namespace HotelBookingSystem;

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class confirmBooking : roomBooking {

  public confirmBooking(String roomType, String roomNumber, String checkInDate, String checkOutDate, int numberOfPeople) 
    : base(roomType, roomNumber, checkInDate, checkOutDate, numberOfPeople) { }


   public void display() {
     for (int i = 0; i < roomTypes.Count; i++) {

         Console.WriteLine($"{roomTypes[i]} {roomNumbers[i]} {checkInDates[i]} {checkOutDates[i]} {NumbersOfPeople[i]}");
     }
  }

  public override void confirm() {
    Console.WriteLine("Booking confirmed - Step 2 complete!");
  }
}
