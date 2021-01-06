using System;
using System.Collections.Generic;

namespace DIJKSTRA
{
    class Program
    {
        static void Main(string[] args)
        {
            const int max = 5;
            int[,] a = new int[,]
            {
                {1000, 1, 1000, 1000, 7 },
                {1000, 1000, 1, 4, 8 },
                {1000, 1000, 1000, 2, 4 },
                {1000, 1000, 1, 1000, 1000 },
                {1000, 1000, 1000, 4, 1000 }
            };
            int s, f;
            try
            {
                Console.Write("Diem bat dau: ");
                s = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("Diem ket thuc: ");
                f = Convert.ToInt32(Console.ReadLine()) - 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            int[] d = new int[max];
            int[] Truoc = new int[max];
            for (int v = 0; v < max; v++)
            {
                d[v] = a[s, v];
                Truoc[v] = s;
            }
            d[s] = 0;

            bool[] inT = new bool[max];
            for (int i = 0; i < max; i++)
            {
                inT[i] = true;
            }
            inT[s] = false;

            while(Empty(inT) == false) // dieu kien T ko rong
            {
                int u = -1;
                int minD = 1000;
                for (int i = 0; i < max; i++)
                {
                    if(inT[i] == true && minD > d[i])
                    {
                        minD = d[i];
                        u = i;
                    }
                }
                inT[u] = false;
                for (int v = 0; v < max; v++)
                {
                    if(inT[v] == true)
                    {
                        if(d[v] > d[u] + a[u, v])
                        {
                            d[v] = d[u] + a[u, v];
                            Truoc[v] = u;
                        }
                    }
                }
            }

            string result = "";
            int m = Truoc[f];
            result += (m + 1).ToString();
            while(m != s)
            {
                m = Truoc[m];
                result = (m + 1).ToString() + ", " + result;
            }
            result += ", " + (f + 1);
            Console.WriteLine("Khoang cac nho nhat la: " + d[f]);
            Console.WriteLine("Duong di la: " + result);
        }
        public static bool Empty(bool[] inT)
        {
            for (int i = 0; i < inT.Length; i++)
            {
                if(inT[i] == true)
                {
                    return false;
                }
            }
            return true;
        }
    }

}
