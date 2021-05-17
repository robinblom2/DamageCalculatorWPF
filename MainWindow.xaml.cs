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

namespace DamageCalculatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        SwordDamage swordDamage;                    // We only create a reference to an object. Not instantiating the object itself. 
        


        public MainWindow()                         // This is a constructor. It gets called directly after the random-object and the reference above have been created. 
        {
            InitializeComponent();
            swordDamage = new SwordDamage(random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7));       // We instantiate the swordDamage-object (pointing the reference to a new object). The added rolls gets passed as an argument to the other constructor in the SwordDamage-class. The "roll"-field gets the value of the "startingRoll". 

            DisplayDamage();
        }

        /// <summary>
        /// This method rolls the dices and sets a new value to the roll-field
        /// </summary>
        public void RollDice()
        {
            swordDamage.Roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);                   // The new 3d6-roll gets passed to the Roll-property, and then saved in the "roll"-field.  
            DisplayDamage();                                                                                // The method then calls on DisplayDamage() and it displays the value of "roll" and "damage" in the TextBlock of the app. 
        }

        /// <summary>
        /// This method gets the current backingfield values from the Properties, and sets TextBlock to display those values.
        /// </summary>
        private void DisplayDamage()
        {
            damage.Text = $"Rolled {swordDamage.Roll} for {swordDamage.Damage} HP";                         // This line sets the TextBlock-text to display the current values of the objects private fields "roll" and "damage", thru their public properties.
        }

        /// <summary>
        /// This method gets called everyime the user presses the "Roll for damage"-button in the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RollDice();                                                                                     // Everytime the user presses the button 3 new random numbers get added together, and the field "roll" gets updated thru it's property.   
        }


        /// <summary>
        /// This method gets called when the user checks the "Flaming"-box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flaming_Checked(object sender, RoutedEventArgs e)
        {
            swordDamage.Flaming = true;                                                                     // When the user checks the "Flaming"-box the value "true" gets passed to the Flaming-property, and the property sets the value of the private field "flaming" to "true". Since there is flame-damage, it will get added to the "damage"-field thru the CalculateDamage()-method.   
            DisplayDamage();                                                                                // After the CalculateDamage()-method have added the flaming-damage to the "damage"-field, the new value of "damage" gets displayed thru the DisplayDamage()-method.
        }

        /// <summary>
        /// This method gets called when the user un-checks the "Flaming"-box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flaming_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamage.Flaming = false;                                                                    // When the user un-checks the "Flaming"-box the value "false" gets passed to the Flaming-property, and the property sets the value of the private field "flaming" to "false". Since there is no flame-damage, it wont get added to the "damage"-field thru the CalculateDamage()-method.
            DisplayDamage();                                                                                // After the CalculateDamage()-method have calulated a new value of the "damage"-field (without flaming-damage), the new value of "damage" gets displayed thru the DisplayDamage()-method.
        }

        /// <summary>
        /// This method gets called when the user checks the "Magic"-box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void magic_Checked(object sender, RoutedEventArgs e)
        {
            swordDamage.Magic = true;                                                                       // When the user checks the "Magic"-box the value "true" gets passed to the Magic-property, and the property sets the value of the private field "magic" to "true". Since there is magic-damage it will get added to the "damage"-field thru the CalculateDamage()-method. 
            DisplayDamage();                                                                                // After the CalculateDamage()-method have added the magic-damage to the "damage"-field, the new value of "damage" gets displayed thru the DisplayDamage()-method. 
        }

        /// <summary>
        /// This method gets called when the user un-checks the "Magic"-box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void magic_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamage.Magic = false;                                                                      // When the user un-checks the "Magic"-box the value "false" gets passed to the Magic-property, and the property sets the value of the private field "magic" to "false". Since there is no magic-damage, it wont get added to the "damage"-field thru the CalculateDamage()-method.
            DisplayDamage();                                                                                // After the CalculateDamage()-method have calculated a new value of the "damage"-field (without magic-damage), the new value of "damage" gets displayed thru the DisplayDamage()-method. 
        }


    }
}
