using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel
    {
        private const double DEF_ARMOR_THICKNESS = 200;

        public bool SubmergeMode { get; private set; }

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, DEF_ARMOR_THICKNESS)
        {
            SubmergeMode = false;
        }

        public void ToggleSubmergeMode()
        {
            SubmergeMode = !SubmergeMode;
            if (SubmergeMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < DEF_ARMOR_THICKNESS)
                ArmorThickness = DEF_ARMOR_THICKNESS;
        }

        public override string ToString()
        {
            string submergeModeText = SubmergeMode ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Submerge mode: {submergeModeText}";
        }
    }
}
