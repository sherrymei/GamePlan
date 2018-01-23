using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GamePlan
{
    /// <summary>
    /// The NPC asks the user some questions for the user to respond.
    /// Depending on the response, the user gets points for warrior, bowman, mage, or rouge.
    /// In the end, the one with the most points is the class the user will be.
    /// </summary>

    public sealed partial class Survey : Page
    {
        //Initialize points
        int warriorPt = 0, bowmanPt = 0, magePt = 0, rougePt = 0;
        int sumPt = 0;

        //Initialize messages
        //heroMessages[x,y] = class x with message y
        //x = 0: NPC, 1: Warrior, 2: Bowman, 3: Mage, 4: Rouge
        string[,] heroMessages = new string[1, 5]
        {
            {
                "a",
                "b",
                "c",
                "d",
                "e"
            }
        };

        private int updateSumPt()
        {
            return sumPt = warriorPt + bowmanPt + magePt + rougePt;
        }

        public Survey()
        {
            this.InitializeComponent();
        }

        private void buttonMenuClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage));
        }

        private void buttonWarriorClick(object sender, RoutedEventArgs e)
        {
            warriorPt++;
            sumPt = updateSumPt();
            endSurvey();
        }

        private void buttonBowmanClick(object sender, RoutedEventArgs e)
        {
            bowmanPt++;
            sumPt = updateSumPt();
            endSurvey();
        }

        private void buttonMageClick(object sender, RoutedEventArgs e)
        {
            magePt++;
            sumPt = updateSumPt();
            endSurvey();
        }

        private void buttonRougeClick(object sender, RoutedEventArgs e)
        {
            rougePt++;
            sumPt = updateSumPt();
            endSurvey();
        }

        private string maxHeroMessage()
        {
            //Find the max of points
            int max = Math.Max(warriorPt, bowmanPt);
            max = Math.Max(max, magePt);
            max = Math.Max(max, rougePt);

            //Initialize an array of candidates
            string[] heroList = new string[4];
            int index = 0;
            if (max == warriorPt)
            {
                heroList[index] = "Warrior";
                index++;
            }
            if (max == bowmanPt)
            {
                heroList[index] = "Bowman";
                index++;
            }
            if (max == magePt)
            {
                heroList[index] = "Mage";
                index++;
            }
            if (max == rougePt)
            {
                heroList[index] = "Rouge";
                index++;
            }

            //Randomize selecting hero
            Random random = new Random();
            int randomNumber = random.Next(0, index);
            string message = heroList[randomNumber];
            return message;
        }

        private void endSurvey()
        {
            if (sumPt > 0)
            {
                string warriorMessage = "Warrior: " + Convert.ToString(warriorPt) + "\n";
                string bowmanMessage = "Bowman: " + Convert.ToString(bowmanPt) + "\n";
                string mageMessage = "Mage: " + Convert.ToString(magePt) + "\n";
                string rougeMessage = "Rouge: " + Convert.ToString(rougePt) + "\n";
                string heroSelectedMessage = "Favorite Class: " + maxHeroMessage();
                textboxNPC.Text = "Here are your results:\n" + warriorMessage + bowmanMessage + mageMessage + rougeMessage
                    + heroSelectedMessage;
            }
        }
    }
}
