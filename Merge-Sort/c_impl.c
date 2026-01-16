#include <stdio.h>
#include <stdlib.h>
#include <sys/param.h>
#include <assert.h>
#include <threads.h>
#include "semapone.h"
#include <math.h>

#define THREADED
#define ARR_SIZE 100000000
#define THREAD_COUNT 8

typedef struct 
{
    int start;
    int end;
    int *arr;
    int thrd_id;
}info;

info* create_info(int *arr, int start, int end, int node)
{
    info *_info = malloc(sizeof(*_info));
    _info->arr = arr;
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

int run_thrds(void *args)
{
    info *_info = (info *)args;

    if(_info->start == _info->end)
        goto free;

    if(THREAD_COUNT <= _info->thrd_id)
    {
        merge_sort(_info->arr, _info->start, _info->end);
        goto free;
    }

    thrd_t thr1, thrd2;
    int mid = (_info->start + _info->end) / 2;
    thrd_create(&thr1, run_thrds, (void *)create_info(_info->arr, _info->start, mid, _info->thrd_id * 2));
    thrd_create(&thrd2, run_thrds, (void *)create_info(_info->arr, mid + 1, _info->end, _info->thrd_id * 2 + 1));
    thrd_join(thr1, NULL);
    thrd_join(thrd2, NULL);
    merge(_info->arr, _info->start, _info->end);
free:
    free(_info);
    return thrd_success;
}
void sort_multithreaded(int *arr, int size)
{
    run_thrds((void *)create_info(arr, 0, size - 1, 1));
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
real    0m3.865s
user    0m15.775s
sys     0m0.699s

*/
