using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CA2
{

    public partial class MainWindow : Window
    {
        //create a list that will hold activity objects

        List<Activity> allActivities = new List<Activity>();
        List<Activity> selectedActivities = new List<Activity>();
        List<Activity> filteredActivities = new List<Activity>();
        decimal totalCost = 0;




        public MainWindow()
        {
            //this piece of code is for the font of the WPF APP
            InitializeComponent();
            this.FontFamily = new FontFamily("Comic Sans MS");

        }

        //These are the windows loaded activities that appear on the listbox
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //crate activities

            Activity l1 = new Activity()
            {
                Name = "Treking",
                Description = "Instructor led group trek through local mountains.",
                ActivityDate =  new DateTime(2019, 07, 04),
                TypeOfActivity = ActivityType.Land,
                Cost = 20m,
            };

            Activity l2 = new Activity()
            {
                Name = "Mountain Biking",
                Description = "Instructor led half day mountain biking.  All equipment provided.",
                ActivityDate = new DateTime(2019, 02, 21),
                TypeOfActivity = ActivityType.Land,
                Cost = 30m
            };

            Activity l3 = new Activity()
            {
                Name = "Abseiling",
                Description = "Experience the rush of adrenaline as you descend cliff faces from 10-500m.",
                ActivityDate = new DateTime(2019, 09, 03),
                TypeOfActivity = ActivityType.Land,
                Cost = 40m
            };

            Activity w1 = new Activity()
            {
                Name = "Kayaking",
                Description = "Half day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 12, 11),
                TypeOfActivity = ActivityType.Water,
                Cost = 40m
            };

            Activity w2 = new Activity()
            {
                Name = "Surfing",
                Description = "2 hour surf lesson on the wild atlantic way",
                ActivityDate = new DateTime(2019, 08, 09),
                TypeOfActivity = ActivityType.Water,
                Cost = 25m
            };

            Activity w3 = new Activity()
            {
                Name = "Sailing",
                Description = "Full day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Water,
                Cost = 50m
            };

            Activity a1 = new Activity()
            {
                Name = "Parachuting",
                Description = "Experience the thrill of free fall while you tandem jump from an airplane.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Air,
                Cost = 100m
            };

            Activity a2 = new Activity()
            {
                Name = "Hang Gliding",
                Description = "Soar on hot air currents and enjoy spectacular views of the coastal region.",
                ActivityDate = new DateTime(2019, 06, 12),
                TypeOfActivity = ActivityType.Air,
                Cost = 80m
            };

            Activity a3 = new Activity()
            {
                Name = "Helicopter Tour",
                Description = "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Air,
                Cost = 200m
            };

            //add to list
            allActivities.Add(l1);
            allActivities.Add(l2);
            allActivities.Add(l3);
            allActivities.Add(w1);
            allActivities.Add(w2);
            allActivities.Add(w3);
            allActivities.Add(a1);
            allActivities.Add(a2);
            allActivities.Add(a3);

            //display in the list
            allActivities.Sort();


            //total cost
            textblockTotalCost.Text = Activity.TotalCost.ToString();

            //allActivities.ForEach(Activity => Console.WriteLine(Activity.Name)); (experimenting code)

            lbxAllActivities.ItemsSource = allActivities;
            lbxSelectedActivities.ItemsSource = selectedActivities;



        }

        //this is used for the button to add to the second list on the screen (selected activities)
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            Activity selected = lbxAllActivities.SelectedItem as Activity; //get the selected item

            if (selected != null)

            {
                //moves activities to the other list
                allActivities.Remove(selected);
                selectedActivities.Add(selected);

                //adds the price to the total cost after every activity is added
                totalCost += selected.Cost;
                textblockTotalCost.Text = totalCost.ToString();

                //refreshes the screen
                RefreshScreen();
            }

            //This gives a message if you dont have selected an activity to add
            else
            {
                MessageBox.Show("Yous have to select an Activity to be displayed");
            }

                    

        }




        //this is the remove function (on click of the button) item removed from the listbox
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

            Activity selected = lbxSelectedActivities.SelectedItem as Activity; //get the selected item

            if (selected != null)

            {
                //moves activities to the other list
                allActivities.Add(selected);
                selectedActivities.Remove(selected);


                //This removes the activity price from the list when it removed
                totalCost -= selected.Cost;
                textblockTotalCost.Text = totalCost.ToString();

                //refreshes the screen
                RefreshScreen();
            }

            //This gives a message if you dont have selected an activity to remove
            else
            {
                MessageBox.Show("You have to select an Activity to remove from the listbox");
            }


        }


        private void RefreshScreen()
        {
            lbxAllActivities.ItemsSource = null;
            lbxSelectedActivities.ItemsSource = null;

            lbxAllActivities.ItemsSource = allActivities;
            lbxSelectedActivities.ItemsSource = selectedActivities;
        }

        //handles all radiobutton clicks everything is filtered
        private void radioAll_Click(object sender, RoutedEventArgs e)
        {
            filteredActivities.Clear();

            if (radioAll.IsChecked == true)
            {
                //show all activities
                RefreshScreen();
            }

            //Land Activities
            else if (radioLand.IsChecked == true)
            {
                //show all land activities
                foreach (Activity activity in allActivities)
                {
                    if (activity.TypeOfActivity == ActivityType.Land)
                    {
                        filteredActivities.Add(activity);
                        lbxAllActivities.ItemsSource = null;
                        lbxAllActivities.ItemsSource = filteredActivities;

                    }
                }
            }

            //Air Activities
            else if (radioAir.IsChecked == true)
            {
                //show all air activities
                foreach (Activity activity in allActivities)
                {
                    if (activity.TypeOfActivity == ActivityType.Air)
                    {
                        filteredActivities.Add(activity);
                        lbxAllActivities.ItemsSource = null;
                        lbxAllActivities.ItemsSource = filteredActivities;
                    }
                }
            }

            //Water Activities
            else if (radioWater.IsChecked == true)
            {
                //show all water activities
                foreach (Activity activity in allActivities)
                {
                    if (activity.TypeOfActivity == ActivityType.Water)
                    {
                        filteredActivities.Add(activity);
                        lbxAllActivities.ItemsSource = null;
                        lbxAllActivities.ItemsSource = filteredActivities;
                    }
                }
            }


        }

        //This is used to create the description  to be shown on the textblock
        private void lbxAllActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activity selected = lbxAllActivities.SelectedItem as Activity;

            if (selected != null)
            {

                //display tblk description

                textblockDescription.Text = selected.Description;

            }
        }


        //This is used to create the description  to be shown on the textblock but when the other listbox is selected
        private void lbxSelectedActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activity selected = lbxSelectedActivities.SelectedItem as Activity;

            if (selected != null)
            {

                //display tblk description

                textblockDescription.Text = selected.Description;

            }
            
        }
    }
}

