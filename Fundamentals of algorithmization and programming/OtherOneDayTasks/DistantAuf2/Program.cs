using System;
using System.IO;

namespace DistantAuf2
{
    class Program
    {
        static void Main (string[] args)
        {
            DateTime d1, d2;
            static double[] WithIter(double[] m)
            {
                double a;
                for (int i = 0; i < m.Length; i++)
                {
                    for (int j = i + 1; j < m.Length; j++)
                    {
                        if (m[i] > m[j])
                        {
                            a = m[i];
                            m[i] = m[j];
                            m[j] = a;
                        }
                    }
                }
                return m;
            }
            static double[] WithRec(double[] m)
            {
                if (m.Length < 2) return m;
                else
                {
                    double pivot = m[0];
                    int left = 1; int right = m.Length - 1;
                    int forright = 0; int forleft = 0;
                    while (true)
                    {
                        for (int i = right; i >= 0; i--)
                        {
                            if (m[i] <= pivot)
                            {
                                forright = i;
                                break;
                            }
                        }
                        right = forright;
                        if (right <= left) break;
                        bool ok = true;
                        for (int i = left; i < m.Length; i++)
                        {
                            if (m[i] > pivot)
                            {
                                forleft = i;
                                ok = false;
                                break;
                            }
                        }
                        left = forleft;
                        if (right <= left || ok) break; 
                        double b = m[right];
                        m[right] = m[left];
                        m[left] = b;
                    }
                    double a = m[0];
                    m[0] = m[right];
                    m[right] = a;
                    double[] m1 = new double[right];
                    for (int i = 0; i < right; i++) m1[i] = m[i];
                    m1 = WithRec(m1);
                    double[] m2 = new double[m.Length - right - 1];
                    for (int i = 0; i < m2.Length; i++) m2[i] = m[i + right + 1];
                    m2 = WithRec(m2);
                    double[] z = new double[m1.Length + m2.Length + 1];
                    m1.CopyTo(z, 0);
                    z[m1.Length] = m[right];
                    m2.CopyTo(z, m1.Length + 1);
                    return z;
                }
            }
            double[] bM;
            string recinfo = "";
            string iterinfo = "";
            long diff;
            for (int i = 2; i < 101; i++)
            {
                bM = new double[i];
                for (int j = 0; j < bM.Length; j++)
                {
                    bM[j] = 100 - j;
                }
                d1 = DateTime.Now;
                bM = WithRec(bM);
                d2 = DateTime.Now;
                diff = (d2 - d1).Ticks;
                if (i > 2)
                {
                    Console.Write("Elements: " + i +", WithRec: " + diff + ", ");
                    recinfo += "" + diff + "\n";
                }
                d1 = DateTime.Now;
                bM = WithIter(bM);
                d2 = DateTime.Now;
                diff = (d2 - d1).Ticks;
                if (i > 2)
                {
                    Console.WriteLine("WithIter: " + diff + ", ");
                    iterinfo += "" + diff + "\n";
                }
            }
            using (StreamWriter stream = new StreamWriter(@"C:\WithRec.txt", false, System.Text.Encoding.Default))
            {
                stream.WriteLine(recinfo);
            }
            using (StreamWriter stream = new StreamWriter(@"C:\WithIter.txt", false, System.Text.Encoding.Default))
            {
                stream.WriteLine(iterinfo);
            }
        }
    }
}
