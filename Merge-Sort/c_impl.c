#include <stdio.h>
#include <stdlib.h>
#include <sys/param.h>
#include <assert.h>
#include <threads.h>
#include "semapone.h"
#include <math.h>

#define THREADED
#define ARR_SIZE 100000000
#define THREAD_COUNT 1

typedef struct 
{
    int start;
    int end;
    int *arr;
    int thrd_id;
    struct semapone **semapone_arr;
}info;

info* create_info(int *arr, int start, int end, int node, struct semapone **semapone_arr)
{
    info *_info = malloc(sizeof(*_info));
    _info->arr = arr;
    _info->semapone_arr = semapone_arr;
    _info->start = start;
    _info->end = end;
    _info->thrd_id = node;
    return _info;
}


void merge(int *arr, int start, int end)
{
    int mid = (end + start) / 2;
    int left_size = mid - start + 1;
    
    int *left_copy = malloc(sizeof(int) * left_size);
    
    for (int i = 0; i < left_size; i++)
        left_copy[i] = arr[start + i];
    
    int i = 0;          
    int j = mid + 1;    
    int k = start;      
    
    while (i < left_size && j <= end)
    {
        if (left_copy[i] <= arr[j])
            arr[k++] = left_copy[i++];
        else
            arr[k++] = arr[j++];
    }
    
    while (i < left_size)
        arr[k++] = left_copy[i++];
    
    free(left_copy);
}

void merge_sort(int *arr, int start, int end)
{
    if(start == end)return;
    int mid = (end + start) / 2;
    merge_sort(arr, start, mid);
    merge_sort(arr, mid + 1, end);
    merge(arr, start, end);
}

void sort(int *arr, int size)
{
    merge_sort(arr, 0, size - 1);
}

int merge_multithreaded(void *args)
{
    info *_info = (info *)args;
    semapone_wait(_info->semapone_arr[_info->thrd_id * 2]);
    semapone_wait(_info->semapone_arr[_info->thrd_id * 2 + 1]);
    merge(_info->arr, _info->start, _info->end);
    semapone_signal(_info->semapone_arr[_info->thrd_id]);
    free(_info);
    return thrd_success;
}

int merge_sort_multithreaded(void *args)
{
    info *_info = (info *)args;
    merge_sort(_info->arr, _info->start, _info->end);
    semapone_signal(_info->semapone_arr[_info->thrd_id]);
    free(_info);
    return thrd_success;
}
void run_thrds(int *arr, int start, int end, int node, struct semapone **semapone_arr)
{
    thrd_t thrd;
    if(THREAD_COUNT <= node)
    {
        thrd_create(&thrd, merge_sort_multithreaded, (void *)create_info(arr, start, end, node, semapone_arr));
        return;
    }
    thrd_create(&thrd, merge_multithreaded, (void *)create_info(arr, start, end, node, semapone_arr));
    int mid = (start + end) / 2;
    run_thrds(arr, start, mid, node * 2, semapone_arr);
    run_thrds(arr, mid + 1, end, node * 2 + 1, semapone_arr);
}
void sort_multithreaded(int *arr, int size)
{
    struct semapone *semapone_arr[THREAD_COUNT * 2];
    for(int i = 0; i < THREAD_COUNT * 2; i++)
        semapone_arr[i] = semapone_create(0);

    run_thrds(arr, 0, size - 1, 1, semapone_arr);

    semapone_wait(semapone_arr[1]);

    for(int i = 0; i < THREAD_COUNT * 2; i++)
        semapone_destroy(semapone_arr[i]);
}

int main(void)
{
    int *arr = malloc(sizeof(int) * ARR_SIZE);
    for(int i = 0; i < ARR_SIZE; i++)
        *(arr + i) = 1 + rand() % ARR_SIZE;

#ifdef THREADED
    sort_multithreaded(arr, ARR_SIZE);
#else
    sort(arr, ARR_SIZE);
#endif
    for(int i = 0; i < ARR_SIZE - 1; i++)
        assert(*(arr + i) <= *(arr + i + 1));

    free(arr);
    return 0;
}
#define _SEMAPONE_IMPL
#include "semapone.h"

/*
one thread
real    0m13.478s
user    0m25.144s
sys     0m0.472s

8 threads 
real    0m5.105s
user    0m41.159s
sys     0m0.942s

*/
