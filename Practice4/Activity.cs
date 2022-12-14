using System;
using System.Globalization;
 
namespace Practice4
{

/* 
For each activity, they want to track the date and length of the activity in minutes.
In addition, the base class should contain virtual methods for getting the distance, speed, pace. 
These methods should be overridden in the derived classes.

Finally, you should provide a GetSummary method to produce a string with all the summary information.
Remember that the summary method can make use of the other methods to produce its result. 
This method should be available for all classes, so it should be defined in the base class 
(you can override it in the derived classes if needed, but it may not need to be...).
 */

public class Activity
{

    private DateTime _activityDate;
    private double _activityLengthInMinutes;
    private Constants.ACTIVITYTYPE _activityType;


    ///<summary>
    ///Constructor for the base activity class.
    ///<param name="inputActivityLengthInMinutes"> The length of the activity in minutes</param>
    ///<param name="inputActivityDate"> The date of the activity</param>
    ///<param name="inputActivityType"> The type of activity</param>
    ///</summary>
    public Activity(DateTime inputActivityDate, double inputActivityLengthInMinutes, Constants.ACTIVITYTYPE inputActivityType)
    {

        _activityDate = inputActivityDate;
        _activityLengthInMinutes = inputActivityLengthInMinutes;
        _activityType = inputActivityType;
    }

    ///<summary>
    ///Return the activity
    ///date
    ///</summary>
    public string GetActivityDate()
    {
        return _activityDate.ToString($"{Constants.NumericDayOfTheWeek} {Constants.ShortNameOfTheMonth} {Constants.Year4Digit}",
        CultureInfo.CreateSpecificCulture(Constants.USSpecificCulture));
    }

    ///<summary>
    ///Set the activity
    ///date
    ///<param name="inputActivityDate"> The input activity date.</param>
    ///</summary>
    public void SetActivityDate(DateTime inputActivityDate)
    {
        _activityDate = inputActivityDate;
    }

    ///<summary>
    ///Return the activity
    ///length in minutes
    ///</summary>
    public double GetActivityLengthInMinutes()
    {
        return _activityLengthInMinutes;
    }

    ///<summary>
    ///Set the activity
    ///length in minutes
    ///<param name="inputActivityLengthInMinutes"> The activity in minutes.</param>
    ///</summary>
    public void SetActivityLengthInMinutes(double inputActivityLengthInMinutes)
    {
        _activityLengthInMinutes = inputActivityLengthInMinutes;

    }

    ///<summary>
    ///Return the activity
    ///type
    ///</summary>
    public string GetActivityType()
    {
        switch (_activityType)
        {
            case Constants.ACTIVITYTYPE.Cycling:
                return Constants.CyclingActivity;
            case Constants.ACTIVITYTYPE.Running:
                return Constants.RunningActivity;
            case Constants.ACTIVITYTYPE.Swimming:
                return Constants.SwimmingActivity;
            default:
                return Constants.UnknownActivity;
        }
    }

    ///<summary>
    ///Set the activity
    ///type
    ///<param name="inputActivityType"> The activity type as enum ACTIVITYTYPE.</param>
    ///</summary>
    public void SetActivityType(Constants.ACTIVITYTYPE inputActivityType)
    {
        _activityType = inputActivityType;
    }

    ///<summary>
    ///Calculate the speed
    ///in miles per hour
    ///</summary>
    public virtual double CalculateSpeed()
    {
        return (Constants.MinutesPerHour);
    }

    ///<summary>
    /// Calculate the distance
    ///in miles
    ///</summary>
    public virtual double CalculateDistance()
    {
        return (Constants.OlympicSwimmingPoolLengthInMeters * Constants.MeterToKilometerConversion * Constants.KilometerToMileConversion);

    }

    ///<summary>
    /// Calculate the pace
    ///in minutes per mile
    ///</summary>
    public virtual string CalculatePace()
    {
        return Constants.MinutesPerHour.ToString();
    }

    ///<summary>
    ///Returns a summary
    ///of the activity
    ///statistics
    ///Example: 03 Nov 2022 Running (30 min)- Distance 3.0 miles, Speed 6.0 mph, Pace: 10.0 min per mile
    ///</summary>
    public virtual void GetSummary(double distance, double speed, string pace)
    {
        Console.WriteLine($"Activity Summary: {Constants._newLine}{Constants._dividingLine}");
        Console.WriteLine($"{Constants._newLine}");
        Console.WriteLine($"{GetActivityDate()} {GetActivityType()} ({RoundUp2Places(GetActivityLengthInMinutes())} min)-Distance: {RoundUp2Places(distance)} miles, Speed: {RoundUp2Places(speed)} mph, Pace: {pace} min per mile {Constants._newLine}");

    }

    ///<summary>
    ///REmplys the math objects rounding on an input
    ///double value up to 2 decimal places using the midpoint
    ///rounding mode "Away from Zero" which rounds up or down based
    ///on the double value. For this program, there will be no negative values
    ///for distance, speed, or pace.
    ///<param name="inputDoubleValue"> A double value to be rounded to the nearest 2</param>
    ///</summary>
    public double RoundUp2Places(double inputDoubleValue)
    {
        return Math.Round(inputDoubleValue, 2, MidpointRounding.AwayFromZero);
    }



}
 

}