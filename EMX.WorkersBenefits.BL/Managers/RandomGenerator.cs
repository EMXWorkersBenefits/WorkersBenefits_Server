using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMX.WorkersBenefits.BL.Managers
{
    public static class RandomGenerator
    {
        private static Random _rnd = new Random();

        public static int GetNext(int min, int excMax)
        {
            return _rnd.Next(min, excMax);
        }

        public static List<int> GetNextMulti(int count, int min, int excMax)
        {
            var multi = new List<int>();
            for (int i = 0; i < count; i++)
            {
                multi.Add(GetNext(min, excMax));
            }
            return multi;
        }

        public static string GetNextCode(int digitsCount)
        {
            return string.Join("", GetNextMulti(6, 1, 10));
        }

    }
}
