
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    using Models.Contracts;
    using System.Linq;
    using System.Xml.Linq;
    using Utilities.Messages;

    public abstract class Vessel : IVessel
    {
        private string name;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private ICaptain captain;
        private List<string> targets;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            targets = new List<string>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                name = value;
            }
        }

        public ICaptain Captain
        {
            get { return captain; }
            set
            {
                if (value == null)
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                captain = value;
            }
        }


        public double ArmorThickness
        {
            get { return armorThickness; }
            set
            {
                if (value < 0)
                    armorThickness = 0;
                else
                    armorThickness = value;
            }
        }

        public double MainWeaponCaliber
        {
            get => mainWeaponCaliber;
            protected set => mainWeaponCaliber = value;
        }

        public double Speed
        {
            get => speed;
            protected set => speed = value;
        }

        public ICollection<string> Targets => targets.AsReadOnly();

        public void Attack(IVessel target)
        {
            if (target == null)
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            target.ArmorThickness -= this.mainWeaponCaliber;
            this.targets.Add(target.Name);
        }

        public virtual void RepairVessel()
        { }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string targetsString = Targets.Any() ? string.Join(", ", targets) : "None";

            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
            sb.Append($" *Targets: " + targetsString);
            return sb.ToString().TrimEnd();
        }
    }
}
