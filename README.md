#Hotel-Booking-System

This is a hotel booking system C# app which closely resembles to the real hotel booking apps used by users worldwide. The project app is used by users for selecting a particular room of the hotel for a particular days within the particular time limit as well as allowing room options too like single room or double room option etc. Before the real booking however, the user would need to sign up first so that after they sign up, they can log in to their account next time they access the app. This app is intended to be safe and protected generally when storing data so that nothing gets lost and every time the user finishes inputting valid pieces of data, the system confirms it each time just to make sure. 

#Main-Features

-CreateAccount: This is the first phase of the program where the user has to create an account first before making the booking by entering 6 pieces of information and he has to enter each information validly meeting all its requirements before proceeding to the booking 
                phase. For each information, there's a 3 attempt limit to enter the correct information and if for each information it bypasses the 3 attempt limit , it restarts from the very beginning with the exception of first name input which stays as it is (so for 
                example, if you bypass the 3 attempt limit for password or confirm password, you have to restart again from entering your valid first name again).

-roomBooking: This is the second phase of the program after completing the account creation phase. The 3 attempt limit applies exactly here too as of create account but if any part of information regardless of how done you are (even at the final part so final                          information) bypasses the 3 attempt limit, it would go back to the very beginning so in that case, it's room type. This phase asks for several stuff such as room type, room number and check dates as well as number of people staying in the room etc. Again, 
              requirements are similar and in order, the program asks for information. To move on to the next piece of information, you have to enter the current piece of information validly meeting all the requirements just like the createAccount feature.

-Payment: This is the third phase of the program after it finalises and checks that every single piece of information already entered is valid and accurate. The program compiles all the information together to determine the total cost of the user's booking taking into 
          account the amount of days, room type and the number of people too. 30 pounds per person and 10 pounds per day when booking the hotel as well as a single room being 80 pounds and double room being 50 pounds but that all depends on availability usually. The 
          program then displays and prompts the user to pay for the hotel booking and if the user can't pay, the system won't proceed with the booking.
