Start();

void Start()
{
    while (true)
    {
        Console.ReadLine();
        Console.Clear();

        System.Console.WriteLine("53) Задача 53: Задайте двумерный массив. Напишите программу, которая поменяет местами первую и последнюю строку массива.");
        System.Console.WriteLine("55) Задача 55: Задайте двумерный массив. Напишите программу, которая заменяет строки на столбцы. В случае, если это невозможно, программа должна вывести сообщение для пользователя.");
        System.Console.WriteLine("57) Задача 57: Составить частотный словарь элементов двумерного массива. Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.");
        System.Console.WriteLine("0) End");

        int numTask = SetNumber("task");

        switch (numTask)
        {
            case 0:  break;
            case 53: GetArray(); break;
            case 55: FlipArray(); break;
            case 57: FrequencyDictionary(); break;

            default: System.Console.WriteLine("error"); break;
        }
    }
}

int SetNumber(string numberName)
{
    Console.Write($"Выберите номер задачи {numberName}: ");
    int num = Convert.ToInt32(Console.ReadLine());
    return num;
}

void GetArray() 
{
    int[,] array = new int[new Random().Next(3, 4), new Random().Next(3, 4)]; //создадим двухмерный рандомный массив

    //заполним массив случайными числами с помощью цикла
    for (int i = 0; i < array.GetLength(0); i++) // array.GetLength(0) - обращение ко всей строчке (длина строки)
    {
        for (int j = 0; j < array.GetLength(1); j++) // array.GetLength(1) - обращение ко всему столбцу (длина столбца)
        {
            array[i, j] = new Random().Next(10, 100);
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine(); //пустая строка для разделения столбцов
    }

    Console.WriteLine();//пустая строка для разделения матриц
    Console.WriteLine();

    for (int i = 0; i < array.GetLength(1); i++) //проходим циклом по столбцам
    {
        var temp = array[array.GetLength(1) - 1, i]; //введем переменную и сохраним туда значения последней строки
        array[array.GetLength(1) - 1, i] = array[0, i]; //присвоим значения первой строки последней
        array[0, i] = temp; //присвоим первой строке значение из переменной
    }
     PrintArray(array);
}

void PrintArray(int[,] array)//создадим метод вывода на печать массива
{
    for (int i = 0; i < array.GetLength(0); i++) 
    {
        for (int j = 0; j < array.GetLength(1); j++) 
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine(); 
    }
}

void FlipArray()
{
    int[,] array = new int[new Random().Next(3, 7), new Random().Next(3, 7)]; 

    for (int i = 0; i < array.GetLength(0); i++) 
    {
        for (int j = 0; j < array.GetLength(1); j++) 
        {
            array[i, j] = new Random().Next(10, 100);
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine(); 
    }

    Console.WriteLine();
    Console.WriteLine();

    int lght = array.GetLength(0);//создали переменную, равную длинне массива

    int[,] mass = new int[lght,lght]; //создали новый массив размерностью равной новой переменной

    if(array.GetLength(0) == array.GetLength(1))
    {
        for (int i = 0; i < array.GetLength(0); i++) 
        {
            for (int j = 0; j < array.GetLength(1); j++) 
            {
                mass[i, j] = array[j, i];// присваиваем ноому массиву значение элементов старого, только перевернутого(по условию задачи)

                Console.Write(mass[i, j] + " ");
            }
            Console.WriteLine(); 
        }
    }
    else Console.WriteLine("Данный массив не переворачивается!");
}

void FrequencyDictionary() //частотный словарь
{
    int[,] array = new int[new Random().Next(3, 7), new Random().Next(3, 7)]; 

    for (int i = 0; i < array.GetLength(0); i++) 
    {
        for (int j = 0; j < array.GetLength(1); j++) 
        {
            array[i, j] = new Random().Next(10, 100);
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine(); 
    }

    Console.WriteLine();
    Console.WriteLine();

int m = array.GetLength(0); //создали переменную, равную длине строки 
int n = array.GetLength(1);//создали переменную, равную длине столбца 

int trg = 0;//создаем доп.переменную
int[,] dick = new int[m*n, 2]; // создаем массив, равный количеству строк (m*n), и 2 столбца
int count = 0;//создали переменную - счетчик

for (int i = 0; i < array.GetLength(0); i++) 
{
    for (int j = 0; j < array.GetLength(1); j++) 
    {
        trg = 0;
        for(int r = 0; r < count; r++)
        {
            if(dick[r,0] == array[i,j])
            {
                dick[r,1]++;
                trg = 1;
                break;
            }
        }

        if(trg == 0)
        {
            dick[count,0] = array[i,j];
            dick[count,1]++;
            count ++;
        }
    }
}

for(int i = 0; i < count; i++)
{
    for(int j = 0; j < dick.GetLength(1); j++)
    {
        Console.Write(dick[i, j] + " ");
    }
    Console.WriteLine();
}
}

