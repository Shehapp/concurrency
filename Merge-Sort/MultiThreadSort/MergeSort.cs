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
        static Semaphore []sortSemaphres;
        static Semaphore[] mergeSemaphres;
        
        #endregion

        #region Threads
        //TODO: Define any required thread objects here
        
        static Thread[] sortThreads;
        static Thread[] mergeThreads;
        
        #endregion

        //helper to solve it M sort and M-1 merge   M = 2^k
        public static void breakItDown(int[] array, int curNode, int curDepth, int depthLimit, int start, int end)
        {
            Console.Out.Write(curNode);

            if (curDepth != depthLimit)
            {
                mergeThreads[curNode] = new Thread(MergeMT);
                mergeSemaphres[curNode] = new Semaphore(0);
                mergeThreads[curNode].Start(Params2Object(array, start, end, (start + end) >> 1, curNode));
            }
            else if (curDepth == depthLimit)
            {
                int sortNode = curNode - (int)Math.Pow(2, depthLimit - 1);
                sortThreads[sortNode] = new Thread(MSortMT);
                sortSemaphres[sortNode] = new Semaphore(0);
                // sortThreads[sortNode].Start(Params2Object(array, start, end, (start + end) >> 1, sortNode));
            }

            if (depthLimit == curDepth) return;
            breakItDown(array, curNode * 2 + 1, curDepth + 1, depthLimit, start, (start + end) / 2);
            breakItDown(array, curNode * 2 + 2, curDepth + 1, depthLimit, (start + end) / 2 + 1, end);
        }


        #region Sort Function

        public static void SortMT(int[] array)
        {
            int s = 1;
            int e = array.Length;
            int m = (s + e) / 2;
            int node_idx = 0;

            NumMergeSortThreads = 2; //TASK 2
            // NumMergeSortThreads = 4;              //TASK 3

            sortThreads = new Thread[NumMergeSortThreads];
            sortSemaphres = new Semaphore[NumMergeSortThreads];

            mergeThreads = new Thread[NumMergeSortThreads-1];
            mergeSemaphres = new Semaphore[NumMergeSortThreads-1];

            // log2 x
            int MNumMergeSortThreads = (int)Math.Ceiling(Math.Log(NumMergeSortThreads, 2));
            breakItDown(array, 0, 0, MNumMergeSortThreads, s, e );
            mergeSemaphres[0].Wait();
            
            return;

            #region [TASK 2]

            if (NumMergeSortThreads == 2) //TASK 2
            {
                /*TODO: 
                 * 1) Initialize any required semaphore
                 * 2) Create & Start TWO Merge Sort concurrent threads & ONE Merge thread
                 * 3) Use semaphores to handle any dependency or critical section
                 */

                
                sortSemaphres = new Semaphore[2];
                sortThreads = new Thread[2];
                int ss = 1, ee = e / 2;
                for (int i = 0; i < 2; i++)
                {
                    sortSemaphres[i] = new Semaphore(0);

                    sortThreads[i] = new Thread(MSortMT);
                    if (i == 1) sortThreads[i].Start(Params2Object(array, ss, e, i, node_idx));
                    else sortThreads[i].Start(Params2Object(array, ss, ee, i, node_idx));
                    ss += e / 2;
                    ee += e / 2;
                }

                mergeSemaphres = new Semaphore[1];
                mergeThreads = new Thread[1];

                //root
                mergeSemaphres[0] = new Semaphore(0);
                mergeThreads[0] = new Thread(MergeMT);
                mergeThreads[0].Start(Params2Object(array, s, e, 0, node_idx));
                mergeSemaphres[0].Wait();
                
            }

            #endregion

            #region [TASK 3]

            else if (NumMergeSortThreads == 4) //TASK 3
            {
                /*TODO: 
                 * 1) Initialize any required semaphore
                 * 2) Create & Start FOUR Merge Sort concurrent threads & THREE Merge thread
                 * 3) Use semaphores to handle any dependency or critical section
                 */
                sortSemaphres = new Semaphore[4];
                sortThreads = new Thread[4];
                int ss = 1, ee = e / 4;
                for (int i = 0; i < 4; i++)
                {
                    sortSemaphres[i] = new Semaphore(0);

                    sortThreads[i] = new Thread(MSortMT);
                    if (i == 3) sortThreads[i].Start(Params2Object(array, ss, e, i, node_idx));
                    else sortThreads[i].Start(Params2Object(array, ss, ee, i, node_idx));

                    ss += e / 4;
                    ee += e / 4;
                }

                mergeSemaphres = new Semaphore[3];
                mergeThreads = new Thread[3];

                ss = 1;
                ee = e / 2;
                for (int i = 1; i < 3; i++)
                {
                    mergeSemaphres[i] = new Semaphore(0);
                    mergeThreads[i] = new Thread(MergeMT);
                    mergeThreads[i].Start(Params2Object(array, ss, ee, i, node_idx));
                    ss += e / 2;
                    ee += e / 2;
                }

                //root
                mergeSemaphres[0] = new Semaphore(0);
                mergeThreads[0] = new Thread(MergeMT);
                mergeThreads[0].Start(Params2Object(array, s, e, 0, node_idx));
                mergeSemaphres[0].Wait();
            }

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
            sortSemaphres[node_idx].Signal(); // id of cur thread
            
            return;
            #region [TASK 2]

            if (NumMergeSortThreads == 2) //TASK 2
            {
                //TODO: Use semaphores to handle any dependency or critical section
                sortSemaphres[node_idx].Signal(); // id of cur thread
            }

            #endregion

            #region [TASK 3]

            else if (NumMergeSortThreads == 4) //TASK 3
            {
                //TODO: Use semaphores to handle any dependency or critical section
                sortSemaphres[m].Signal(); // id of cur thread
            }

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
            
            int y = node_idx * 2 + 1;
            if (y > NumMergeSortThreads - 2)
            {
                
                int poo = (int)Math.Pow(2, (int)Math.Ceiling(Math.Log(NumMergeSortThreads, 2)));
                sortSemaphres[node_idx * 2 + 2 - poo].Wait();
                sortSemaphres[node_idx * 2 + 1 - poo].Wait();
                Merge(A, s, m, e);
                mergeSemaphres[node_idx].Signal();
            }
            else
            {
                mergeSemaphres[node_idx * 2 + 1].Wait();
                mergeSemaphres[node_idx * 2 + 2 ].Wait();
                Merge(A, s, m, e);
                mergeSemaphres[node_idx].Signal();
            }

            return;
            #region [TASK 2]

            if (NumMergeSortThreads == 2) //TASK 2
            {
                //TODO: Use semaphores to handle any dependency or critical section
                sortSemaphres[0].Wait();
                sortSemaphres[1].Wait();
                Merge(A, s, (s+e)/2, e);
                mergeSemaphres[m].Signal();
            }

            #endregion

            #region [TASK 3]

            else if (NumMergeSortThreads == 4) //TASK 3
            {
                //TODO: Use semaphores to handle any dependency or critical section
                if (m == 0)
                {
                    mergeSemaphres[1].Wait();
                    mergeSemaphres[2].Wait();
                    Merge(A, s, (s + e) / 2, e);
                    mergeSemaphres[m].Signal();
                }
                else
                {
                    sortSemaphres[m*2-2].Wait();
                    sortSemaphres[m*2-1].Wait();
                    Merge(A, s, (s + e) / 2, e);
                    mergeSemaphres[m].Signal();
                }


            }

            #endregion
        }

        #endregion

        #endregion

    }
}
