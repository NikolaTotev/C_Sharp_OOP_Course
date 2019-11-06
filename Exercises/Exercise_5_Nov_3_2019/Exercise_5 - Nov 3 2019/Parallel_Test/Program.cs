using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using longBoi = System.Int64;

struct truckInfo
{
    public long offset;
    public longBoi numberOfDrinksToMove;
}

class Solution
{
    private static longBoi numberOfTrucks;

    static void Main(String[] args)
    {
        longBoi numberOfTrucks;

        numberOfTrucks = Convert.ToInt64(Console.ReadLine());
        List<truckInfo> info = new List<truckInfo>();
        //truckInfo* helper = new truckInfo[numberOfTrucks];

        longBoi offset = 0;
        longBoi numberOfDrinks;

        for (longBoi i = 0; i < numberOfTrucks; ++i)
        {
            string[] tokens = Console.ReadLine().Split();
            longBoi[] numbers = Array.ConvertAll(tokens, longBoi.Parse);
            offset = numbers[0];
            numberOfDrinks = numbers[1];
            truckInfo currentTruck = new truckInfo();
            currentTruck.offset = offset;
            currentTruck.numberOfDrinksToMove = numberOfDrinks;
            info.Add(currentTruck);
        }



        var newInfo = from trucks in info orderby trucks.offset select trucks;


        foreach (var truck in newInfo)
        {
        }

        longBoi tempMin = 0;
        longBoi currentMin = 0;
        longBoi currentOffset = 0;
        bool notFirstIt = false;

        Parallel.ForEach(newInfo, (fixedTruck, outerLoopSate) =>
        {
            Parallel.ForEach(newInfo, (truck, innerLoopSate) =>
            {
                if (fixedTruck.offset != truck.offset && fixedTruck.numberOfDrinksToMove != truck.numberOfDrinksToMove)
                {
                    currentOffset = Math.Abs(truck.offset - fixedTruck.offset);
                    tempMin += currentOffset * truck.numberOfDrinksToMove;
                    if (tempMin > currentMin && !notFirstIt)
                    {
                        innerLoopSate.Break();
                    }
                }
            });
            if (notFirstIt)
            {
                currentMin = tempMin;
                notFirstIt = true;
            }
            else
            {
                if (tempMin < currentMin)
                {
                    currentMin = tempMin;
                }
            }

            tempMin = 0;
        });

        Console.Write(currentMin);
    }
}
/*
 * #include <iostream>
typedef long long longBoi;
using namespace std;
struct truckInfo
{
    longBoi offset;
    longBoi numberOfDrinksToMove;
};

void merge(truckInfo* arr, truckInfo* helper, longBoi start, longBoi mid, longBoi end)
{

    longBoi left1 = start;
    longBoi left2 = mid;
    longBoi i = start;

    for (; left1 < mid && left2 < end; ++i)

    {
        if (arr[left1].offset <= arr[left2].offset)
        {
            helper[i] = arr[left1++];
        }
        else
        {
            helper[i] = arr[left2++];
        }
    }

    while (left1 < mid)
    {
        helper[i++] = arr[left1++];
    }

    while (left2 < end)
    {
        helper[i++] = arr[left2++];
    }

    for (int j = start; j < end; ++j)
    {
        arr[j] = helper[j];
    }

}

void merge_sort(truckInfo* arr, truckInfo* helper, longBoi leftLim, longBoi rightLim)
{
    if (leftLim + 1 < rightLim)
    {

        longBoi middle = (leftLim + rightLim) / 2;
        merge_sort(arr, helper, leftLim, middle);
        merge_sort(arr, helper, middle, rightLim);
        merge(arr, helper, leftLim, middle, rightLim);
    }

}
int main()
{
    longBoi numberOfTrucks;
    cin >> numberOfTrucks;

    truckInfo* info = new truckInfo[numberOfTrucks];
    truckInfo* helper = new truckInfo[numberOfTrucks];

    longBoi offset = 0;
    longBoi numberOfDrinks;

    for (longBoi i = 0; i < numberOfTrucks; ++i)
    {
        cin >> offset;
        cin >> numberOfDrinks;
        info[i].offset = offset;
        info[i].numberOfDrinksToMove = numberOfDrinks;
    }

    merge_sort(info, helper, 0, numberOfTrucks);


    longBoi tempMin = 0;
    longBoi currentMin = 0;
    longBoi currentOffset = 0;

    for (longBoi i = 0; i < numberOfTrucks; ++i)
    {

        for (longBoi j = 0; j < numberOfTrucks; ++j)
        {
            if (i != j)
            {

                currentOffset = abs(info[j].offset - info[i].offset);


                tempMin += currentOffset * info[j].numberOfDrinksToMove;


                if (tempMin > currentMin && i != 0)
                {
                    break;
                }
            }
        }

        if (i == 0)
        {
            currentMin = tempMin;
        }
        else
        {
            if (tempMin < currentMin)
            {
                currentMin = tempMin;
            }
        }
        tempMin = 0;
    }
    cout << currentMin;

}

 */
