using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel
    {
        private const double DEF_ARMOR_THICKNESS = 300;

        public bool SonarMode { get; private set; }

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, DEF_ARMOR_THICKNESS)
        {
            SonarMode = false;
        }

        public void ToggleSonarMode()
        {
            SonarMode = !SonarMode;
            if (SonarMode)
            {
                MainWeaponCaliber += 40;
                Speed += 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed -= 5;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < DEF_ARMOR_THICKNESS)
                ArmorThickness = DEF_ARMOR_THICKNESS;
        }


        public override string ToString()
        {
            string sonarModeText = SonarMode ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Sonar mode: {sonarModeText}";
        }
    }
}
