using System;

namespace T04.PizzaCalories
{

    public class Dough
    {
        private const int BASE_CALORIES = 2;
        private const int MIN_GRAMS = 1;
        private const int MAX_GRAMS = 200;

        private FlourType flour;
        private BakingTechnique technique;
        private int grams;

        public Dough(string flour, string technique, int grams)
        {
            Flour = flour;
            Technique = technique;
            Grams = grams;
        }

        public string Flour
        {
            get => flour.ToString();
            private set
            {
                FlourType flour = GetFlour(value);
                if (flour == FlourType.INVALID)
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flour = flour;
            }
        }

        public string Technique
        {
            get => technique.ToString();
            private set
            {
                BakingTechnique technique = GetBakingTechnique(value);
                if (technique == BakingTechnique.INVALID)
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.technique = technique;
            }
        }

        public int Grams
        {
            get => grams;
            private set
            {
                if (value < MIN_GRAMS || value > MAX_GRAMS)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                grams = value;
            }
        }

        public double Calories =>
            grams *
            BASE_CALORIES *
            GetFlourModifier(flour) *
            GetTechniqueModifier(technique);

        private double GetTechniqueModifier(BakingTechnique technique)
        {
            return technique switch
            {
                BakingTechnique.CRISPY => 0.9,
                BakingTechnique.CHEWY => 1.1,
                BakingTechnique.HOMEMADE => 1.0,
                _ => 0
            };
        }

        private double GetFlourModifier(FlourType flour)
        {
            return flour switch
            {
                FlourType.WHITE => 1.5,
                FlourType.WHOLEGRAIN => 1.0,
                _ => 0
            };
        }

        private FlourType GetFlour(string type)
        {
            return type.ToLower() switch
            {
                "white" => FlourType.WHITE,
                "wholegrain" => FlourType.WHOLEGRAIN,
                _ => FlourType.INVALID
            };
        }

        private BakingTechnique GetBakingTechnique(string type)
        {
            return type.ToLower() switch
            {
                "crispy" => BakingTechnique.CRISPY,
                "chewy" => BakingTechnique.CHEWY,
                "homemade" => BakingTechnique.HOMEMADE,
                _ => BakingTechnique.INVALID
            };
        }
    }
}











////using System;
////using System.Collections.Generic;
////using System.Text;

////namespace T04.PizzaCalories
////{
////    public class Dough
////    {
////        private string flourType;
////        private string bakingTechnique;
////        private int weight;

////        public Dough(string flourType, string bakingTechnique, int weight)
////        {
////            FlourType = flourType;
////            BakingTechnique = bakingTechnique;
////            Weight = weight;
////        }
////        public double Calories => 2
////         * weight
////         * Helper.Modifiers[FlourType.ToLower()]
////         * Helper.Modifiers[BakingTechnique.ToLower()];
////        public string FlourType
////        {
////            get { return flourType; }
////            private set
////            {
////                if (!Helper.Modifiers.ContainsKey(value.ToLower()))
////                {
////                    throw new ArgumentException("Invalid type of dough.");
////                }
////                flourType = value;
////            }
////        }
////        public string BakingTechnique
////        {
////            get { return bakingTechnique; }
////            private set
////            {
////                if (!Helper.Modifiers.ContainsKey(value.ToLower()))
////                {
////                    throw new ArgumentException("Invalid type of dough.");
////                }
////                bakingTechnique = value;
////            }
////        }
////        public int Weight
////        {
////            get { return weight; }
////            set
////            {
////                if (value < 1 || value > 200)
////                {
////                    throw new ArgumentException($"Dough weight should be in the range [1..200].");
////                }
////                weight = value;
////            }
////        }
////    }
////}


//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace T04.PizzaCalories
//{
//    public class Dough
//    {
//        private string flourType;
//        private string bakingTechnique;
//        private int weight;
//        public Dough(string flourType, string bakingTechnique, int weight)
//        {
//            this.FlourType = flourType;
//            this.BakingTechnique = bakingTechnique;
//            this.Weight = weight;
//        }
//        public string FlourType
//        {
//            get
//            {
//                return flourType;
//            }
//            private set
//            {
//                if (Helper.Modifiers.ContainsKey(value.ToLower()))
//                {
//                    this.flourType = value;
//                }
//                else
//                {
//                    throw new ArgumentException("Invalid type of dough.");
//                }
//            }
//        }
//        public string BakingTechnique
//        {
//            get { return bakingTechnique; }
//            private set
//            {
//                if (Helper.Modifiers.ContainsKey(value.ToLower()))
//                {
//                    this.bakingTechnique = value;
//                }
//                else
//                {
//                    throw new ArgumentException("Invalid type of dough.");
//                }
//            }
//        }
//        public int Weight
//        {
//            get
//            {
//                return weight;
//            }
//            set
//            {
//                if (value >= 1 && value <= 200)
//                {
//                    weight = value;
//                }
//                else
//                {
//                    throw new ArgumentException("Dough weight should be in the range [1..200].");
//                }
//            }
//        }

//        public double Calories => 2
//            * weight
//            * Helper.Modifiers[FlourType.ToLower()]
//            * Helper.Modifiers[BakingTechnique.ToLower()];

//    }
//}
