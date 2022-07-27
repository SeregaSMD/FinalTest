string[] EnterArray()
{
    if (File.Exists("data.txt"))
    {
        Console.WriteLine("Found data.txt, reading.");
        string [] inputArray = File.ReadAllLines("data.txt");
        return inputArray;
    }
    else
    {    
    Console.WriteLine("Can not find data.txt, please enter initial data with console or press ctrl+C and place data.txt in the project directory.");
    int arraySize = EnterArraySize();
    int counter = 0;
    string[] inputArray = new string[arraySize];
    while (counter < arraySize)
    {
        Console.Write($"Please enter {counter+1} of {arraySize} element in array: ");
        inputArray[counter] = Console.ReadLine();
        counter++;
    }
    Console.WriteLine("Do you want to save the entered data to data.txt? Type \"yes\" if so, otherwise type anything else.");
    string decision = (Console.ReadLine().Trim('"', ' ')).ToLower();        
    if (decision=="yes") File.WriteAllLines("data.txt",inputArray);
    return inputArray;
    }
}

int EnterArraySize()
{
    bool isNumerical = false;
    while (!isNumerical)
    {
        Console.Write("Enter the total number of elements in array: ");
        string str = Console.ReadLine();
        isNumerical = int.TryParse(str, out int result);
        if (!isNumerical)
        {
            Console.WriteLine("The entered value can not be converted to integer value, please enter a valid number.");
        }
        else
        {
            int arraySize = int.Parse(str);
            return arraySize;
        }
    }
    return -100500;
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

int CountStringsLessNum(string[] inputArray, int symbolsNum)
{
    int count = 0;
    for (int i = 0; i < inputArray.Length; i++)
    {
        if (inputArray[i].Length <= symbolsNum) count++;
    }
    return count;
}

void PrintArray(string [] arr, int symbolsNum)
{
    Console.Write($"Here are all the srings from data.txt with size less or equal to {symbolsNum} characters: ");
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i]);
        if (i < arr.Length - 1) Console.Write(", ");
        else Console.Write(".");
    }
}

int symbolsNum = 3;
string[] inputArray = EnterArray();
string[] outputArray = FilterStringArray(inputArray, symbolsNum);
PrintArray (outputArray, symbolsNum);
File.WriteAllLines("result.txt", outputArray);