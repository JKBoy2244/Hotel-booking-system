using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


abstract class roomBooking {

  
  private String _roomType;
  private String _roomNumber;
  private String _checkInDate;
  private String _checkOutDate;
  private int _numberOfPeople;

  private const int maxAttempts = 3;

  protected List<string> roomTypes = new List<string>();
  protected List<string> roomNumbers = new List<string>();
  protected List<string> checkInDates = new List<string>();
  protected List<string> checkOutDates = new List<string>();
  protected List<int> NumbersOfPeople = new List<int>();

  
  public roomBooking(String roomType, String roomNumber, String checkInDate, String checkOutDate, int numberOfPeople) {

    this._roomType = roomType;
    this._roomNumber = roomNumber;
    this._checkInDate = checkInDate;
    this._checkOutDate = checkOutDate;
    this._numberOfPeople = numberOfPeople;

  }

  public String getRoomType() {

      return _roomType;
    }

  public String getRoomNumber() {

     return _roomNumber;
   }

  public String getRoomCheckInDate() {

    return _checkInDate;
  }

  public String getRoomCheckOutDate() {

    return _checkOutDate;
  }

  public int getNumberOfPeople() {

    return _numberOfPeople;
  }

  public void setRoomType(String roomType) {

    if (roomType == null || !roomType.Equals("Single_room") || !roomType.Equals("Double_room")) {

      throw new ArgumentException("Invalid choice. Try again please!");
    }

    this._roomType = roomType;
  }

  public void setRoomNumber(String roomNumber) {

     if ((!int.TryParse(roomNumber, out int number)) || roomNumber == null || ((number < 1) || number > 1000)) {

       throw new ArgumentException("Invalid choice. Try again please!");
     }

    this._roomNumber = roomNumber;
  }

 public void setRoomCheckInDate(String checkInDate) {

   if (!DateTime.TryParse(checkInDate, out DateTime parsedCheckInDate) || checkInDate == null || parsedCheckInDate < DateTime.Now || parsedCheckInDate > new DateTime(2027, 1, 1)) {

     throw new ArgumentException("Invalid choice. Try again please!");
   }

   this._checkInDate = checkInDate;
 }

  public void setRoomCheckOutDate(String checkOutDate) {

    if (!DateTime.TryParse(checkOutDate, out DateTime parsedCheckOutDate) || checkOutDate == null || parsedCheckOutDate < DateTime.Now || parsedCheckOutDate > new DateTime(2027, 2, 1)) {

       throw new ArgumentException("Invalid choice. Try again please!");
     }

    this._checkOutDate = checkOutDate;
 }

  public void setNumberOfPeople(String numberOfPeopleInput)  {

    if (!int.TryParse(numberOfPeopleInput, out int people) || numberOfPeopleInput == null || (people < 1 || people > 5)) {

      throw new ArgumentException("Invalid option, number of people must be between 1 and 5.");
    }

    this._numberOfPeople = people;
  }

  private static void RemainingAttempts(int attempts, int maxAttempts) {
    Console.WriteLine("You have " + (maxAttempts - attempts) + " attempts left!");
  }

  
  public void roomType() {

    int attempts = 0;
    String roomType = "";

    while (attempts < maxAttempts) {

      Console.WriteLine("Write either Single_room or Double_room in that exact format: ");
      roomType = Console.ReadLine();
      attempts++;

      if (roomType == null || (!roomType.Equals("Single_room") && !roomType.Equals("Double_room"))) {
        if (attempts == maxAttempts) {
          Console.WriteLine("3 attempts already used up! Sorry, but the process is restarting unfortunately!");
          return;
        }
        RemainingAttempts(attempts, maxAttempts);
        Console.WriteLine("Sorry, invalid room type!");
        continue;
      }

      roomTypes.Add(roomType);
      this._roomType = roomType;
      break;
    }
  }

  public void roomNumber()   {

    int attempts = 0;

    while (attempts < maxAttempts) {

      Console.WriteLine("Write your preference room number from 1 to 1000: ");
      String roomNumberInput = Console.ReadLine();
      attempts++;

      if (!int.TryParse(roomNumberInput, out int roomNumber) || roomNumberInput == null || (roomNumber < 1 || roomNumber > 1000)) {
          if (attempts == maxAttempts) {
            Console.WriteLine("3 attempts already used up! Sorry, but the process is restarting unfortunately!");
            return;
          }
          RemainingAttempts(attempts, maxAttempts);
          Console.WriteLine("Sorry, invalid room type!");
          continue;
        }

      roomNumbers.Add(roomNumberInput);
      this._roomNumber = roomNumberInput;
      break;
        
      }
    }

  public void checkInDate() {

    int attempts = 0;

    while (attempts < maxAttempts) {

        Console.WriteLine("Enter your check in date which can't be empty (You need to be at least 16 to create an account here: ");
        String dateInInput = Console.ReadLine();
        attempts++;

        if (!DateTime.TryParse(dateInInput, out DateTime parsedDateInInput) || dateInInput == null || parsedDateInInput < DateTime.Now || parsedDateInInput > new DateTime(2027, 1, 1)) {
          if (attempts == maxAttempts) {
          Console.WriteLine("3 attempts already used up! Sorry, but the process is restarting unfortunately!");
          return;
        }

        RemainingAttempts(attempts, maxAttempts);
        Console.WriteLine("Sorry, your age is empty!");
        continue;
        }  

       checkInDates.Add(dateInInput);
       this._checkInDate = dateInInput;
       break;
    }
  }

  public void checkOutDate() {

    int attempts = 0;
    DateTime.TryParse(this._checkInDate, out DateTime parsedCheckInDate);

    while (attempts < maxAttempts) {

        Console.WriteLine("Enter your check out date (must be after check-in date): ");
        String dateOutInput = Console.ReadLine();
        attempts++;

        if (!DateTime.TryParse(dateOutInput, out DateTime parsedDateOutInput) || dateOutInput == null || parsedDateOutInput < DateTime.Now || parsedDateOutInput > new DateTime(2027, 1, 1) || parsedDateOutInput < parsedCheckInDate) {
          if (attempts == maxAttempts) {
          Console.WriteLine("3 attempts already used up! Sorry, but the process is restarting unfortunately!");
          return;
        }

        RemainingAttempts(attempts, maxAttempts);
        Console.WriteLine("Sorry, your age is empty!");
        continue;
        }  

       checkOutDates.Add(dateOutInput);
       this._checkOutDate = dateOutInput;
       break;
    }
  }

  public void numberOfPeople() {

    int attempts = 0;

    while (attempts < maxAttempts) {

        Console.WriteLine("Enter your age which can't be empty (You need to be at least 16 to create an account here: ");
        String numberOfPeopleInput = Console.ReadLine();
        attempts++;

        if (!int.TryParse(numberOfPeopleInput, out int people) || (people < 1 || people > 5) || numberOfPeopleInput == null) {
          if (attempts == maxAttempts) {
          Console.WriteLine("3 attempts already used up! Sorry, but the process is restarting unfortunately!");
          return;
        }

        RemainingAttempts(attempts, maxAttempts);
        Console.WriteLine("Sorry, your age is empty!");
        continue;
        }  

       NumbersOfPeople.Add(people);
       this._numberOfPeople = people;
       break;
    }
  }

  abstract public void confirm();
}
