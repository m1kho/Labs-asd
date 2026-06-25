using lvl3.Models;

namespace lvl3.Services
{
    public static class MergeSorter
    {
        public static void Sort(Student[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(Student[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                Sort(array, left, mid);
                Sort(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }

        private static void Merge(Student[] array, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            Student[] leftArray = new Student[n1];
            Student[] rightArray = new Student[n2];

            for (int i = 0; i < n1; i++)
            {
                leftArray[i] = array[left + i];
            }
            for (int j = 0; j < n2; j++)
            {
                rightArray[j] = array[mid + 1 + j];
            }

            int k = left;
            int iIdx = 0, jIdx = 0;

            while (iIdx < n1 && jIdx < n2)
            {
                if (leftArray[iIdx].StudentTicket <= rightArray[jIdx].StudentTicket)
                {
                    array[k] = leftArray[iIdx];
                    iIdx++;
                }
                else
                {
                    array[k] = rightArray[jIdx];
                    jIdx++;
                }
                k++;
            }

            while (iIdx < n1)
            {
                array[k] = leftArray[iIdx];
                iIdx++;
                k++;
            }

            while (jIdx < n2)
            {
                array[k] = rightArray[jIdx];
                jIdx++;
                k++;
            }
        }
    }
}
