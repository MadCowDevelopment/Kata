using System;
using System.Collections.Generic;

namespace Monopoly
{
    public static class ListExtension
    {
        public static void Shuffle<T>(this List<T> list)
        {
            var random = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < list.Count; i++)
            {
                var randomIndex = random.Next(0, list.Count - 1);
                list.Swap(randomIndex, i);
            }
        }

        public static void Swap<T>(this List<T> list, int index1, int index2)
        {
            if (index1 == index2)
            {
                return;
            }

            var temp = list[index2];
            list[index2] = list[index1];
            list[index1] = temp;
        }
    }
}
