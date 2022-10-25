using System;
using System.Collections.Generic;
using System.Linq;


namespace _04._Pizza_Calories
{
    public class Topping
    {
        // Fields - constants        
        private const double MOD_MEAT = 1.2;
        private const double MOD_VEGGIES = 0.8;
        private const double MOD_CHEESE = 1.1;
        private const double MOD_SAUCE = 0.9;

        // Fields - variables
        private string type;
        private double grams;

        // Properties   
        private double Grams
        {
            set
            {
                if (value < 1 || value > 50)
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                this.grams = value;
            }
        }

        private string Type
        {
            set
            {
                if (!new List<string> { "meat", "veggies", "cheese", "sauce" }.Contains(value.ToLower()))
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                type = value;
            }
        }

        public double CaloriesPerGram
        {
            get
            {
                double caloriesPerGram = 2;
                if (this.type.ToLower() == "meat") caloriesPerGram *= MOD_MEAT;
                else if (this.type.ToLower() == "veggies") caloriesPerGram *= MOD_VEGGIES;
                else if (this.type.ToLower() == "cheese") caloriesPerGram *= MOD_CHEESE;
                else if (this.type.ToLower() == "sauce") caloriesPerGram *= MOD_SAUCE;
                return caloriesPerGram;
            }
        }

        // Constructors
        public Topping(string type, double grams)
        {
            this.Type = type;
            this.Grams = grams;
        }

        // Methods
        public double GetCalories()
        => this.CaloriesPerGram * this.grams;
    }
}