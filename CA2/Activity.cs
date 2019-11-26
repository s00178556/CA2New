using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CA2
{

    public enum ActivityType { Air, Water, Land}
    public class Activity: IComparable<Activity>
    {

        //properties
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }

        public ActivityType TypeOfActivity { get; set; }



        //ctors
        public Activity(string name, DateTime activityDate, decimal cost, string description, ActivityType typeOfActivity)
        {
            Name = name;
            ActivityDate = activityDate;
            Cost = cost;
            Description = description;
            TypeOfActivity = typeOfActivity;
            
        }

        public Activity()
        {

        }

        //this method shows the name and the activity date on the listbox when loaded
        public override string ToString()
        {
            return $"{Name} , { ActivityDate}";
        }

        //IComparable to sort the Date like asked in Q2 (sorted by month)
        public int CompareTo(Activity other)
        {
            return ActivityDate.CompareTo(other.ActivityDate);
        }
    }
}
