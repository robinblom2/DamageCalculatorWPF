using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DamageCalculatorWPF
{
    class SwordDamage
    {
        public const int BASE_DAMAGE = 3;           // Since these constants aren't going to be used by any other class, it makes sense to keep them private.  
        public const int FLAME_DAMAGE = 2;

        private int roll;                           // We set this field as private. We have a public property (get/set) that gets and sets the value of the field.  

        /// <summary>
        /// Sets or gets the 3d6 roll.
        /// </summary>
        public int Roll
        {
            get { return roll; }                    // Here's the Roll property with its private backing field. The get accessor returns the current value of the "roll"-field.
            set                                     // The set accessor updates the value of roll, and then calls the CalculateDamage()-method which keeps the Damage property updated automatically. 
            {
                roll = value;
                CalculateDamage();                  // Everytime the "roll"-field is set, the app will calculate the new value of the "damage"-field thru the CalculateDamage()-method to keep the value updated.
            }
        }

        private bool flaming;
        public bool Flaming
        {
            get { return flaming; }                 // The Flaming property works just like the Roll and Magic property. They all call CalculateDamage(), so setting any of them automatically updates the Damage property. 
            set
            {
                flaming = value;
                CalculateDamage();                  // Everytime the "flaming"-field is set, the app will calculate the new value of the "damage"-field thru the CalculateDamage()-method to keep the value updated.
            }

        }

        private bool magic;
        public bool Magic
        {
            get { return magic; }                   // The Magic property works just like the Roll and Flaming property. They all call CalculateDamage(), so setting any of them automatically updates the Damage property. 
            set
            {
                magic = value;
                CalculateDamage();                  // Everytime the "magic"-field is set, the app will calculate the new value of the "damage"-field thru the CalculateDamage()-method to keep the value updated.
            }
        }

        public int Damage { get; private set; }     // Auto-implemented property. The Damage property's private set accessor makes it read-only, so it can't be overwritten by another class. Gets and Sets the "hidded" backingfield.  

        /// <summary>
        /// This method calculates the final damage, with added magic- or flamedamage
        /// </summary>
        private void CalculateDamage()
        {                                               // This method calculates and sets the new value of the Damage-field. The damage varies depening on if it's magic or flaming.
            decimal magicMultiplier = 1M;               // The default magic multiplier. 

            if (Magic)                                  // If the damage is magic
            {
                magicMultiplier = 1.75M;                // Set the value of magic multiplier to 1.75 instead.
            }

            Damage = BASE_DAMAGE;                       // Add the base damage (3), this damage gets added to all rolls. 

            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;        // Multiply the added 3d6-rolls with the magic multiplier, and then add the base damage (3). Convert the result to an int (rounded) and store it in the Damage-field. 

            if (Flaming)                                // If the damage is flaming
            {
                Damage += FLAME_DAMAGE;                 // Then add flame damage (2) to the Damage-field. 
            }
        }

        /// <summary>
        /// The constructor calculates damage based on default Magic and Flaming values and a starting 3d6 roll. 
        /// </summary>
        /// <param name="startingRoll">Starting 3d6 roll</param>
        public SwordDamage(int startingRoll) 
        {                                               // The constructor sets the backing field for the Roll property when the program first starts, then calls CalculateDamage to make sure the Damage property is correct.  
            roll = startingRoll;
            CalculateDamage();
        }





    }
}
