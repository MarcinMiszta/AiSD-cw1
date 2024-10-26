using System;
using System.Security.Cryptography.X509Certificates;

namespace cw1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        string ToString(int[] tab)
        {
            string wynik = "";
            for (int i = 0; i < tab.Length; i++)
            {
                wynik += tab[i] + " ";
            }
            return wynik;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //sortowanie b¹belkowe
        private void button1_Click(object sender, EventArgs e)
        {
            int[] tab = { 8, 7, 1, 3, 5, 2, 4 };

            for (int i = 0; i < tab.Length - 1; i++)
            {
                for (int j = 0; j < tab.Length - 1; j++)
                {
                    int temp = tab[j];
                    if (tab[j] > tab[j + 1])
                    {
                        tab[j] = tab[j + 1];
                        tab[j + 1] = temp;
                    }
                }
            }

            string message = string.Join(",", tab);
            MessageBox.Show(message);

        }
        //przez wstawianie
        private void button2_Click(object sender, EventArgs e)
        {
            int[] tab = { 8, 7, 1, 3, 5, 2, 4 };
            for (int i = 1; i < tab.Length; i++)
            {
                int j = i - 1;
                int temp = tab[i];
                while (j >= 0 && tab[j] > temp)
                {
                    tab[j + 1] = tab[j];
                    j--;
                }
                tab[j + 1] = temp;
            }
            string message = string.Join(",", tab);
            MessageBox.Show(message);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] tab = { 8, 7, 1, 3, 5, 2, 4 };
            MergeSort(tab);
            static void MergeSort(int[] tab)
            {
                if (tab.Length <= 1)
                {
                    return;
                }
                int middle = tab.Length / 2;
                int[] side1 = new int[middle];
                int[] side2 = new int[tab.Length - middle];
                for (int i = 0; i < middle; i++)
                {
                    side1[i] = tab[i];
                }
                for (int i = middle; i < tab.Length; i++)
                {
                    side2[i - middle] = tab[i];
                }
                MergeSort(side1);
                MergeSort(side2);
                sort(tab, side1, side2);
            }
            static void sort(int[] tab, int[] side1, int[] side2)
            {
                int i = 0, j = 0, k = 0;

                while (i < side1.Length && j < side2.Length)
                {
                    if (side1[i] < side2[j])
                    {
                        tab[k++] = side1[i++];
                    }
                    else
                    {
                        tab[k++] = side2[j++];
                    }
                }

                while (i < side1.Length)
                {
                    tab[k++] = side1[i++];
                }

                while (j < side2.Length)
                {
                    tab[k++] = side2[j++];

                }
            }
            string message = string.Join(",", tab);
            MessageBox.Show(message);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            int[] tab = { 8, 7, 1, 3, 5, 2, 4 };
            QuickSort(tab, 0, tab.Length - 1);

            static void QuickSort(int[] tab, int leftIndex, int rightIndex)
            {
                if (rightIndex <= leftIndex) return;

                int i = leftIndex;
                int j = rightIndex;
                int pivot = tab[(leftIndex + rightIndex) / 2];

                while (i <= j)
                {
                    while (i <= rightIndex && tab[i] < pivot) i++;
                    while (j >= leftIndex && tab[j] > pivot) j--;

                    if (i <= j)
                    {
                        Swap(ref tab[i], ref tab[j]);
                        i++;
                        j--;
                    }
                }

                if (leftIndex < j)
                {
                    QuickSort(tab, leftIndex, j);
                }
                if (i < rightIndex)
                {
                    QuickSort(tab, i, rightIndex);
                }
            }

            static void Swap(ref int a, ref int b)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            string message = string.Join(",", tab);
            MessageBox.Show(message);
        }


        private void button5_Click(object sender, EventArgs e)
        {
            int[] tab = { 8, 7, 1, 3, 5, 2, 4 };
            int[] sortedTab = CountingSort(tab);


            static int[] CountingSort(int[] tab)
            {
                int min = tab.Min();
                int max = tab.Max();

                int[] count = new int[max - min + 1];

                foreach (int num in tab)
                {
                    count[num - min]++;
                }

                int[] sortedTab = new int[tab.Length];
                int index = 0;

                for (int i = 0; i < count.Length; i++)
                {
                    while (count[i] > 0)
                    {
                        sortedTab[index++] = i + min;
                        count[i]--;
                    }
                }

                return sortedTab;
            }
            string message = string.Join(",", sortedTab);
            MessageBox.Show(message);
        }
    }
}