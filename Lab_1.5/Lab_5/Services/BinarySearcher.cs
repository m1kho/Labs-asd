using lvl1.Models;

namespace lvl1.Services
{
    public static class BinarySearcher
    {
        public static int Search(Student[] array, int key)
        {
            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int midKey = array[mid].RecordBookNumber;

                if (midKey == key)
                {
                    return mid;
                }
                else if (midKey < key)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }
    }
}
