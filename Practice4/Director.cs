using System;

namespace Practice4
{

    public class Director
    {

        private List<Activity> _activities = new List<Activity>();

        ///<summary>
        /// Create 3 activity types and
        ///add them to the activity list
        ///1. cycling, 2. running, 3. swimming
        ///</summary>
        public void CreateActivities()
        {

            // Create the sysling activity
            double cycling1Speed = 12.45;
            double cycling1Duration = 43.92;
            DateTime cycling1Date = new DateTime(2022, 10, 24);
            Cycling cycling1 = new Cycling(cycling1Speed, cycling1Duration, cycling1Date, Constants.ACTIVITYTYPE.Cycling);
            _activities.Add(cycling1);

            //Create the Running activity
            double running1Distance = 3.07;
            double running1Duration = 29.23;
            DateTime running1Date = new DateTime(2022, 12, 12);
            Running running1 = new Running(running1Distance, running1Duration, running1Date, Constants.ACTIVITYTYPE.Running);
            _activities.Add(running1);

            // Create the swimming activity
            int swimming1TotalLaps = 25;
            double swimming1Duration = 28.36;
            DateTime swimming1Date = new DateTime(2022, 11, 26);
            Swimming swimming1 = new Swimming(swimming1TotalLaps, swimming1Duration, swimming1Date, Constants.ACTIVITYTYPE.Swimming);
            _activities.Add(swimming1);

        }

        ///<summary>
        ///Call the GetSummary() method
        ///for each activity in the list and 
        ///pass the object's own calculate distance, speed and pace 
        ///methods as input parameters
        ///for each activity.
        ///</summary>
    public void GetActivitySummaries()
        {
            foreach (Activity activity in _activities)
            {
                activity.GetSummary(activity.CalculateDistance(), activity.CalculateSpeed(), activity.CalculatePace());
            }
    }
}
}