using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Func
    {
        public static int A = 1500;
        public static int B = 1500;
        public static int stepen(int z)
        {
            int res = 1;
            for (int i = 1; i <= z; i++)
                res *= 2;
            return res;
        }
        public static int addmod2(int z1, int z2)
        {
            if ((z1 + z2) == 1) return 1;
            return 0;
        }
        public static int testinectivnost(int[,] a1, int k1, int n1)
        {
            int l = stepen(k1);
            int flag;
            for (int i = 0; i < (l - 1); i++)
            {
                for (int j = i + 1; j <= (l - 1); j++)
                {
                    flag = 0;
                    for (int k = 0; k <= (n1 - 1); k++) if (a1[i, k] != a1[j, k]) { flag = 1; break; }
                    if (flag == 0) return 0;
                }
            }
            return 1;
        }
        public static int systematic(int[,] a1, int k1, int n1)
        {
            int n = 0, k = 0;
            int[] temp = new int[A];
            int[] pod = new int[A];
            int sum = 0;
            int r = 0;
            int flag = 0;
            int j = 0;
            int tflag = 0;
            int sh = 1;
            int[] syscount = new int[A];

            for (int l = 1; l <= n; l++)
                temp[l] = 0;

            for (int i = 1; i <= stepen(n); i++)
            {
                sum = 0;
                for (int l = 1; l <= n; l++)
                {
                    sum += temp[l];
                }
                if (sum == k)
                {
                    for (int z = 0; z <= stepen(k) - 1; z++)
                    {
                        pod[z] = 0;
                        r = 0;
                        for (int l = 1; l <= n; l++)
                        {
                            if (temp[l] == 1) { pod[z] += a1[z, l - 1] * stepen(r); r++; }
                        }
                    }

                    flag = 1;
                    for (int l = 0; l <= stepen(k) - 1; l++)
                    {
                        tflag = 0;
                        for (int z = 0; z <= stepen(k) - 1; z++)
                            if (l == pod[z]) { tflag = 1; break; }

                        if (tflag == 0) { flag = 0; break; }
                    }

                    if (flag == 1)
                    {
                        for (int l = 1; l <= n; l++)
                            if (temp[l] == 1) syscount[sh++] = l - 1;
                    }
                }

                j = n;
                while ((j > 0) && (temp[j] == 1)) { temp[j] = 0; j--; }
                temp[j] = 1;
            }
            if (sh != 1) return 1;
            else return 0;

        }
        public static int linerian(int[,] a1, int k1, int n1)
        {
            int[] temp = new int[A];
            int flag = 1;
            int l = stepen(k1);
            for (int i = 0; i < (l - 1); i++)
                for (int j = i + 1; j <= (l - 1); j++)
                {
                    for (int k = 0; k <= (n1 - 1); k++) temp[k] = addmod2(a1[i, k], a1[j, k]);
                    for (int z = 0; z <= (l - 1); z++)
                    {
                        flag = 1;
                        for (int k = 0; k <= (n1 - 1); k++) if (a1[z, k] != temp[k]) { flag = 0; break; };
                        if (flag == 1) break;
                    }
                    if (flag == 0) return 0;
                }
            return 1;
        }
        public static int kvazilinerian(int[,] a1, int k1, int n1)
        {
            int l = stepen(k1);
            int[,] b1 = new int[A, B];
            for (int i = 0; i <= (l - 1); i++)
            {
                for (int j = 0; j <= (l - 1); j++)
                    for (int k = 0; k <= (n1 - 1); k++) b1[j, k] = addmod2(a1[i, k], a1[j, k]);
                if (linerian(b1, k1, n1) == 1) return 1;
            }
            return 0;
        }  
    }
}
