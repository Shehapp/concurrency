using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreadSort
{
    public enum INIT_METHOD { ASCENDING, DESCINDING, RANDOM };
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form1.CheckForIllegalCrossThreadCalls = false;
        }
        double timeSeq, timeMT;

        int[] array = null;
        int N = 32000000;
        INIT_METHOD initMethod = INIT_METHOD.RANDOM;
        
        private bool IsSorted(int[] array)
        {
            bool isSorted = true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    isSorted = false;
                    break;
                }
            }
            return isSorted;
            
        }

        private int[] CreateAndInitializeArray(int N, INIT_METHOD initMethod)
        {
            int []arr = new int[N];
            switch (initMethod)
            {
                case INIT_METHOD.ASCENDING:
                    for (int i = 0; i < N; i++)
                    {
                        arr[i] = i;
                    }
                    break;
                case INIT_METHOD.DESCINDING:
                    for (int i = 0; i < N; i++)
                    {
                        arr[i] = N - i;
                    }
                    break;
                case INIT_METHOD.RANDOM:
                    Random rnd = new Random();
                    for (int i = 0; i < N; i++)
                    {
                        arr[i] = rnd.Next(N) ;
                    }
                    break;
                default:
                    break;
            }
            return arr;
        }

        private void rdAscending_CheckedChanged(object sender, EventArgs e)
        {
            initMethod = INIT_METHOD.ASCENDING;
        }

        private void rdDescending_CheckedChanged(object sender, EventArgs e)
        {
            initMethod = INIT_METHOD.DESCINDING;
        }

        private void rdRandom_CheckedChanged(object sender, EventArgs e)
        {
            initMethod = INIT_METHOD.RANDOM;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            switch (initMethod)
            {
                case INIT_METHOD.ASCENDING:
                    rdAscending.Select();
                    break;
                case INIT_METHOD.DESCINDING:
                    rdDescending.Select();
                    break;
                case INIT_METHOD.RANDOM:
                    rdRandom.Select();
                    break;
                default:
                    break;
            }
            txtArraySize.Text = N.ToString();
        }
        private void btnSeqRun_Click(object sender, EventArgs e)
        {
            N = int.Parse(txtArraySize.Text);
            array = CreateAndInitializeArray(N, initMethod);
            Stopwatch sw = Stopwatch.StartNew();
            MergeSort.Sort(array);
            sw.Stop();
            bool isSorted = IsSorted(array);
            if (isSorted)
            {
                txtSeqRes.Text = "CORRECT";
                txtSeqRes.ForeColor = Color.Green;
            }
            else
            {
                txtSeqRes.Text = "WRONG";
                txtSeqRes.ForeColor = Color.Red;
            }

            txtSeqTime.Text = sw.Elapsed.ToString();
            timeSeq = sw.Elapsed.TotalSeconds;
            if (txtMTTime.Text != "")
            {
                double speedup = timeSeq / timeMT;
                txtSpeedup.Text = speedup.ToString();
            }
        }
        private void btMTRun_Click(object sender, EventArgs e)
        {
            N = int.Parse(txtArraySize.Text);
            array = CreateAndInitializeArray(N, initMethod);
            Stopwatch sw = Stopwatch.StartNew();
            MergeSort.SortMT(array);
            sw.Stop();
            bool isSorted = IsSorted(array);
            if (isSorted)
            {
                txtMTRes.Text = "CORRECT";
                txtMTRes.ForeColor = Color.Green;
            }
            else
            {
                txtMTRes.Text = "WRONG";
                txtMTRes.ForeColor = Color.Red;
            }
            txtMTTime.Text = sw.Elapsed.ToString();
            timeMT = sw.Elapsed.TotalSeconds;
            if (txtSeqTime.Text != "")
            {
                double speedup = timeSeq / timeMT;
                txtSpeedup.Text = speedup.ToString();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            int N = 4;
            int[] A = new int[N];
            Random rnd = new Random() ;
            for (int i = 0; i < N; i++)
            {
                A[i] = rnd.Next();
            }
            int s = rnd.Next();
            int f = rnd.Next();
            int m = rnd.Next();
            int node_idx = rnd.Next();

            ArrayList parameters = (ArrayList) MergeSort.Params2Object(A, s, f, m, node_idx);
            
            int[] A2 = new int[N];
            int s2 = 0;
            int f2 = 0;
            int m2 = 0;
            int node_idx2 = 0;

            MergeSort.Object2Params(parameters, ref A2, ref s2, ref f2, ref m2, ref node_idx2);

            if (Check(A, s, f, m, node_idx, A2, s2, f2, m2, node_idx2))
            {
                txtTestRes.Text = "CORRECT";
                txtTestRes.ForeColor = Color.Green;
            }
            else
            {
                txtTestRes.Text = "WRONG";
                txtTestRes.ForeColor = Color.Red;
            }



        }

        private bool Check(int[] A, int s, int f, int m, int node_idx, int[] A2, int s2, int f2, int m2, int node_idx2)
        {
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != A2[i])
                    return false;
            }
            if (s != s2) return false;
            if (f != f2) return false;
            if (m != m2) return false;
            if (node_idx != node_idx2) return false;

            return true;
        }
    }
}
