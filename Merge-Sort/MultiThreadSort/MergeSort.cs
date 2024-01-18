using System;
using System.Collections;
using System.Text;
using System.Threading;


namespace MultiThreadSort
{
    public class MergeSort
    {
        #region Helper Functions [TASK 1]

        public static object Params2Object(int[] A, int s, int e, int m, int node_idx)
        {
            #region [TASK 1.1]

            //TODO: Encapsulate the given params into a single ArrayList object, then return it
            ArrayList objects = new ArrayList();
            objects.Add(A);
            objects.Add(s);
            objects.Add(e);
            objects.Add(m);
            objects.Add(node_idx);
            return objects;

            #endregion
        }

        public static void Object2Params(object parameters, ref int[] A, ref int s, ref int e, ref int m,
            ref int node_idx)
        {

            #region [TASK 1.2]

            ArrayList objects = (ArrayList)parameters;
            A = (int[])objects[0];
            s = (int)objects[1];
            e = (int)objects[2];
            m = (int)objects[3];
            node_idx = (int)objects[4];

            #endregion
        }

        #endregion

        //DO NOT CHANGE THIS CODE

        #region Sequential Sort

        public static void Sort(int[] array)
        {
            MSort(array, 1, array.Length);
        }

        private static void MSort(int[] A, int s, int e)
        {
            if (s >= e)
            {
                return;
            }

            int m = (s + e) / 2;

            MSort(A, s, m);

            MSort(A, m + 1, e);

            Merge(A, s, m, e);
        }

        private static void Merge(int[] A, int s, int m, int e)
        {
            int leftCapacity = m - s + 1;

            int rightCapacity = e - m;

            int leftIndex = 0;

            int rightIndex = 0;

            int[] Left = new int[leftCapacity];

            int[] Right = new int[rightCapacity];

            for (int i = 0; i < Left.Length; i++)
            {
                Left[i] = A[s + i - 1];
            }

            for (int j = 0; j < Right.Length; j++)
            {
                Right[j] = A[m + j];
            }

            for (int k = s; k <= e; k++)
            {
                if (leftIndex < leftCapacity && rightIndex < rightCapacity)
                {
                    if (Left[leftIndex] < Right[rightIndex])
                    {
                        A[k - 1] = Left[leftIndex++];
                    }
                    else
                    {
                        A[k - 1] = Right[rightIndex++];
                    }
                }
                else if (leftIndex < leftCapacity)
                {
                    A[k - 1] = Left[leftIndex++];
                }
                else
                {
                    A[k - 1] = Right[rightIndex++];
                }
            }
        }

        #endregion

        //TODO: Change this function to be MULTITHREADED
        //HINT: Remember to handle any dependency and/or critical section issues

        #region Multithreaded Sort [REMAINING TASKS]

        static int NumMergeSortThreads;

        #region Semaphores

        //TODO: Define any required semaphore here
        static Semaphore[] sortSemaphres;
        static Semaphore[] mergeSemaphres;

        #endregion

        #region Threads

        //TODO: Define any required thread objects here

        static Thread[] sortThreads;
        static Thread[] mergeThreads;

        #endregion

        //helper to solve it M sort and M-1 merge   M = 2^k
        static void BreakItDown(int[] array, int curNode, int curDepth, int depthLimit, int start, int end)
        {
            if (curDepth != depthLimit)
            {
                mergeThreads[curNode] = new Thread(MergeMT);
                mergeThreads[curNode].Start(Params2Object(array, start, end, (start + end) >> 1, curNode));
            }
            else
            {
                int sortNode = curNode - (NumMergeSortThreads - 1);
                sortThreads[sortNode] = new Thread(MSortMT);
                sortThreads[sortNode].Start(Params2Object(array, start, end, (start + end) >> 1, sortNode));
                return;
            }

            BreakItDown(array, curNode * 2 + 1, curDepth + 1, depthLimit, start, (start + end) / 2);
            BreakItDown(array, curNode * 2 + 2, curDepth + 1, depthLimit, (start + end) / 2 + 1, end);
        }

        // init semaphores before start
        static void InitSemaphores()
        {
            for (int i = 0; i < NumMergeSortThreads; i++)
            {
                sortSemaphres[i] = new Semaphore(0);
            }

            for (int i = 0; i < NumMergeSortThreads - 1; i++)
            {
                mergeSemaphres[i] = new Semaphore(0);
            }
        }

        // ex: if n=5 return 8
        static int NearestMultipleOf2(int n)
        {
            int i = 1;
            while (i *2=< n)
            {
                i *= 2;
            }

            return i;
        }

        #region Sort Function

        public static void SortMT(int[] array, int M)
        {
            int s = 1;
            int e = array.Length;
            int node_idx = 0;


            #region BONUS: Solve at any number of threads

            // can be any number multiple of 2
            NumMergeSortThreads = Math.Min(NearestMultipleOf2(M), NearestMultipleOf2(e));


            // means sequential
            if (NumMergeSortThreads == 1)
            {
                Sort(array);
                return;
            }

            sortThreads = new Thread[NumMergeSortThreads];
            sortSemaphres = new Semaphore[NumMergeSortThreads];

            mergeThreads = new Thread[NumMergeSortThreads - 1];
            mergeSemaphres = new Semaphore[NumMergeSortThreads - 1];

            //Initialize Semaphores
            InitSemaphores();

            //Start the sorting
            BreakItDown(array, 0, 0, (int)Math.Ceiling(Math.Log(NumMergeSortThreads, 2)), s, e);

            //Waiting for the last merge to finish (i.e. 0th merge thread)
            mergeSemaphres[0].Wait();

            #endregion


        }

        private static void MSortMT(object parameters)
        {
            #region Extract params from the given object

            int[] A = null;
            int s = 0;
            int e = 0;
            int m = 0;
            int node_idx = 0;
            Object2Params(parameters, ref A, ref s, ref e, ref m, ref node_idx);

            #endregion

            MSort(A, s, e);

            #region BONUS

            // signal to merge
            sortSemaphres[node_idx].Signal(); // id of cur thread

            #endregion


        }

        private static void MergeMT(object parameters)
        {
            #region Extract params from the given object

            int[] A = null;
            int s = 0;
            int e = 0;
            int m = 0;
            int node_idx = 0;
            Object2Params(parameters, ref A, ref s, ref e, ref m, ref node_idx);

            #endregion

            #region BONUS

            int y = node_idx * 2 + 1;

            // if cur node is in the last level -1 so we wait for sort threads not merge
            if (y > NumMergeSortThreads - 2)
            {
                sortSemaphres[(node_idx * 2 + 2) - (NumMergeSortThreads - 1)].Wait();
                sortSemaphres[(node_idx * 2 + 1) - (NumMergeSortThreads - 1)].Wait();
                Merge(A, s, m, e);
                mergeSemaphres[node_idx].Signal();
            }
            else
            {
                mergeSemaphres[node_idx * 2 + 1].Wait();
                mergeSemaphres[node_idx * 2 + 2].Wait();
                Merge(A, s, m, e);
                mergeSemaphres[node_idx].Signal();
            }

            #endregion

        }

        #endregion

        #endregion

    }
}
