
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Core
{
    using Contracts;
    using Gym.Models.Athletes;
    using Gym.Models.Athletes.Contracts;
    using Gym.Models.Equipment;
    using Gym.Models.Equipment.Contracts;
    using Gym.Models.Gyms;
    using Microsoft.VisualBasic;
    using Models.Gyms.Contracts;
    using Repositories;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;
    using System.Xml.Linq;
    using Utilities.Messages;

    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym targetGym = gyms.Find(x => x.Name == gymName);
            IAthlete athleteToAdd;
            switch (athleteType)
            {
                case "Boxer":
                    athleteToAdd = new Boxer(athleteName, motivation, numberOfMedals);
                    if (targetGym.GetType().Name != "BoxingGym")
                        return OutputMessages.InappropriateGym;
                    break;

                case "Weightlifter":
                    athleteToAdd = new Weightlifter(athleteName, motivation, numberOfMedals);
                    if (targetGym.GetType().Name != "WeightliftingGym")
                        return OutputMessages.InappropriateGym;
                    break;

                default: throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            targetGym.AddAthlete(athleteToAdd);
            return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipmentToAdd;
            switch (equipmentType)
            {
                case "BoxingGloves": equipmentToAdd = new BoxingGloves(); break;
                case "Kettlebell": equipmentToAdd = new Kettlebell(); break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            equipment.Add(equipmentToAdd);
            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gymToAdd;
            switch (gymType)
            {
                case "BoxingGym": gymToAdd = new BoxingGym(gymName); break;
                case "WeightliftingGym": gymToAdd = new WeightliftingGym(gymName); break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            gyms.Add(gymToAdd);
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.Find(x => x.Name == gymName);
            return String.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipmentToInsert = equipment.Models.FirstOrDefault(x => x.GetType().Name == equipmentType);
            if (equipmentToInsert == null)
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            IGym targetGym = gyms.Find(x => x.Name == gymName);
            if (targetGym != null)
            {
                targetGym.AddEquipment(equipmentToInsert);
                equipment.Remove(equipmentToInsert);
            }
            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        => String.Join(Environment.NewLine, gyms.Select(x => x.GymInfo()));
        

        public string TrainAthletes(string gymName)
        {
            IGym targetGym = gyms.Find(x => x.Name == gymName);
            targetGym.Exercise();
            return String.Format(OutputMessages.AthleteExercise, targetGym.Athletes.Count);
        }
    }
}
