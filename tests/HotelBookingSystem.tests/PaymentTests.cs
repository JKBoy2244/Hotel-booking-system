using System;
using Xunit;
using HotelBookingSystem;

public class PaymentTests
{
    [Fact]
    public void CalculateCost_SingleRoom_2Nights_1Person_ReturnsExpected()
    {
        // Arrange
        var payment = new Payment();
        var checkIn = new DateTime(2026, 1, 10);
        var checkOut = new DateTime(2026, 1, 12);

        // Act
        var total = payment.CalculateCost(checkIn, checkOut, 1, "Single_room");

        // Assert
        Assert.Equal(100m, total); // 2 nights * 50
    }

    [Fact]
    public void CalculateCost_DoubleRoom_3Nights_2People_ReturnsExpected()
    {
        var payment = new Payment();
        var checkIn = new DateTime(2026, 1, 10);
        var checkOut = new DateTime(2026, 1, 13);

        var total = payment.CalculateCost(checkIn, checkOut, 2, "Double_room");

        Assert.Equal(480m, total); // 3 nights * 80 * 2
    }

    [Fact]
    public void CalculateCost_CheckOutBeforeCheckIn_Throws()
    {
        var payment = new Payment();
        var checkIn = new DateTime(2026, 1, 10);
        var checkOut = new DateTime(2026, 1, 9);

        Assert.Throws<ArgumentException>(() =>
            payment.CalculateCost(checkIn, checkOut, 1, "Single_room"));
    }

    [Theory]
    [InlineData("Single_room")]
    [InlineData("Double_room")]
    public void CalculateCost_ZeroNights_Throws(string roomType)
    {
        var payment = new Payment();
        var date = new DateTime(2026, 1, 10);

        Assert.Throws<ArgumentException>(() =>
            payment.CalculateCost(date, date, 1, roomType));
    }
}
