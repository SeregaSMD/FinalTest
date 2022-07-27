int CountStringsLessNum(string[] inputArray, int symbolsNum)
{
    int count = 0;
    for (int i = 0; i < inputArray.Length; i++)
    {
        if (inputArray[i].Length <= symbolsNum) count++;
    }
    return count;
}

string[] FilterStringArray(string[] inputArray, int symbolsNum)
{
    int stringsNum = CountStringsLessNum(inputArray, symbolsNum);
    string[] outputArray = new string[stringsNum];
    int counter = 0;

    for (int i = 0; i < inputArray.Length; i++)
    {
        if (inputArray[i].Length <= symbolsNum)
        {
            outputArray[counter] = inputArray[i];
            counter++;
        }
    }
    return outputArray;
}

int symbolsNum = 3;
string[] inputArray = { "af", "acdc", "abc", "ggfd", "dd", "fd" };

string[] outputArray = FilterStringArray(inputArray, symbolsNum);

foreach (string str in outputArray)
{
    Console.WriteLine(str);
}