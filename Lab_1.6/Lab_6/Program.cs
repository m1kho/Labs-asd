using System;
using System.Diagnostics;
using System.Text;

namespace lvl1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            int[] testSizes = { 100, 10000, 1000000 };
            const int RUNS = 3;

            Console.WriteLine("=== ДОСЛІДЖЕННЯ МЕТОДІВ ЗЛИЦТЯ (Рівень 1) ===");
            Console.WriteLine($"Усереднено за {RUNS} запусків.");

            foreach (int size in testSizes)
            {
                Console.WriteLine("\n" + new string('=', 65));
                Console.WriteLine($"Розмір масиву: {size}");
                Console.WriteLine(new string('-', 65));
                Console.WriteLine("{0,-20} | {1,-20} | {2,-20}", "Тип масиву", "Bottom-Up (мс)", "Top-Down (мс)");
                Console.WriteLine(new string('-', 65));

                int[] randomData = DataGenerator.CreateRandomArray(size);
                double randomBU = MeasureAverageTimeMs(randomData, true, RUNS);
                double randomTD = MeasureAverageTimeMs(randomData, false, RUNS);
                Console.WriteLine("{0,-20} | {1,-20:F4} | {2,-20:F4}", "Випадковий", randomBU, randomTD);

                int[] sortedData = DataGenerator.CreateSortedArray(size);
                double sortedBU = MeasureAverageTimeMs(sortedData, true, RUNS);
                double sortedTD = MeasureAverageTimeMs(sortedData, false, RUNS);
                Console.WriteLine("{0,-20} | {1,-20:F4} | {2,-20:F4}", "Відсортований", sortedBU, sortedTD);

                int[] reverseData = DataGenerator.CreateReverseSortedArray(size);
                double reverseBU = MeasureAverageTimeMs(reverseData, true, RUNS);
                double reverseTD = MeasureAverageTimeMs(reverseData, false, RUNS);
                Console.WriteLine("{0,-20} | {1,-20:F4} | {2,-20:F4}", "Зворотний", reverseBU, reverseTD);
            }
        }

        static double MeasureAverageTimeMs(int[] sourceData, bool isBottomUp, int runs)
        {
            double totalTimeMs = 0;
            var sw = new Stopwatch();

            for (int i = 0; i < runs; i++)
            {
                int[] data = (int[])sourceData.Clone();
                sw.Restart();
                if (isBottomUp)
                {
                    Sorter.BottomUpMergeSort(data);
                }
                else
                {
                    Sorter.TopDownMergeSort(data);
                }
                sw.Stop();
                totalTimeMs += sw.Elapsed.TotalMilliseconds;
            }

            return totalTimeMs / runs;
        }
    }
}