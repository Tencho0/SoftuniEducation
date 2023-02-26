int elementsCount = int.Parse(Console.ReadLine());
int[] originalArray = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int index = Array.IndexOf(originalArray, originalArray.First(x => originalArray.Count(y => y == x) > 1));
int element = originalArray[index];
//int[] subArray1 = originalArray.Take(index).ToArray();
//int[] subArray2 = originalArray.Skip(index + 1).ToArray();

//int[] array1 = new int[subArray1.Length];
//int[] array2 = new int[subArray2.Length];

var arr1 = new List<int>();
var arr2 = new List<int>();
arr1.Add(element);
arr2.Add(element);

for (int i = 0; i < originalArray.Length; i++)
{
    if (originalArray[i] > element)
    {
        arr1.Add(originalArray[i]);
    }
    else if (originalArray[i] < element)
    {
        arr2.Add(originalArray[i]);
    }
}

// Print the results
Console.WriteLine("Original array: " + string.Join(",", originalArray));
Console.WriteLine("Array 1: " + string.Join(",", arr1));
Console.WriteLine("Array 2: " + string.Join(",", arr2));