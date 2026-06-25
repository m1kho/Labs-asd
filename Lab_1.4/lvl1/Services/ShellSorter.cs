using lvl1.Models;

namespace lvl1.Services
{
    public static class ShellSorter
    {
        public static void Sort(Student[] array)
        {
            int n = array.Length;
            int h = 1;
            while (h < n / 3)
            {
                h = 3 * h + 1;
            }

            while (h >= 1)
            {
                for (int i = h; i < n; i++)
                {
                    for (int j = i; j >= h && array[j].StudentTicket < array[j - h].StudentTicket; j -= h)
                    {
                        var temp = array[j];
                        array[j] = array[j - h];
                        array[j - h] = temp;
                    }
                }
                h /= 3;
            }
        }
    }
}
