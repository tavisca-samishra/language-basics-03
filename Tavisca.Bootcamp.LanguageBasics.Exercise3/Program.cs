using System;
using System.Collections.Generic;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 },
                new[] { 2, 8 },
                new[] { 5, 2 },
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" },
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 },
                new[] { 2, 8, 5, 1 },
                new[] { 5, 2, 4, 4 },
                new[] { "tFc", "tF", "Ftc" },
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 },
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 },
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 },
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" },
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            string result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            // Add your code here.
            int[] cal = new int[fat.Length];
            var res = new int[dietPlans.Length];
            for (int i = 0; i < fat.Length; i++)
                cal[i] = protein[i] * 5 + carbs[i] * 5 + fat[i] * 9;
            for (int i = 0; i < dietPlans.Length; i++)
            {
                List<int> temp = new List<int>();
                foreach (char j in dietPlans[i])
                {
                    if (temp.Count() == 0)
                    {
                        switch (j)
                        {
                            case 'p':
                                temp = fmin(protein);
                                break;
                            case 'c':
                                temp = fmin(carbs);
                                break;
                            case 'f':
                                temp = fmin(fat);
                                break;
                            case 't':
                                temp = fmin(cal);
                                break;
                            case 'P':
                                temp = fmax(protein);
                                break;
                            case 'C':
                                temp = fmax(carbs);
                                break;
                            case 'F':
                                temp = fmax(fat);
                                break;
                            case 'T':
                                temp = fmax(cal);
                                break;
                            default: break;
                        }
                    }
                    else
                    {
                        switch(j)
                        {
                            case 'p':
                                temp = smin(protein, temp);
                                break;
                            case 'c':
                                temp = smin(carbs, temp);
                                break;
                            case 'f':
                                temp = smin(fat, temp);
                                break;
                            case 't':
                                temp = smin(cal, temp);
                                break;
                            case 'P':
                                temp = smax(protein, temp);
                                break;
                            case 'C':
                                temp = smax(carbs, temp);
                                break;
                            case 'F':
                                temp = smax(fat, temp);
                                break;
                            case 'T':
                                temp = smax(cal, temp);
                                break;
                            default:break;
                        }
                    }
                    res[i] = temp[0];
                }
            }          
            return res;
        }

        private static List<int> smin(int[] nutr, List<int> temp)
        {
            List<int> ntemp = new List<int>();
            int min = 99999;
            foreach (int i in temp)
                if (nutr[i] < min)
                    min = nutr[i];
            foreach (int i in temp)
                if (nutr[i] == min)
                    ntemp.Add(i);
            return ntemp;
        }

        private static List<int> fmin(int[] nutr)
        {
            int min = 99999;
            List<int> temp = new List<int>();
            for(int i=0;i<nutr.Length;i++)
            {
                if (nutr[i] < min)
                    min = nutr[i];
            }
            for (int i = 0; i < nutr.Length; i++)
                if (min == nutr[i])
                    temp.Add(i);
            return temp;
        }
        private static List<int> smax(int[] nutr, List<int> temp)
        {
            List<int> ntemp = new List<int>();
            int max = -9999;
            foreach (int i in temp)
                if (nutr[i] > max)
                    max = nutr[i];
            foreach (int i in temp)
                if (nutr[i] == max)
                    ntemp.Add(i);
            return ntemp;
        }

        private static List<int> fmax(int[] nutr)
        {
            int max = -9999;
            List<int> temp = new List<int>();
            for (int i = 0; i < nutr.Length; i++)
            {
                if (nutr[i] > max)
                    max = nutr[i];
            }
            for (int i = 0; i < nutr.Length; i++)
                if (max == nutr[i])
                    temp.Add(i);
            return temp;
        }
    }
}
