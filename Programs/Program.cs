Start();

void Start()
{
    while (true)
    {
        Console.ReadLine();
        Console.Clear();

        System.Console.WriteLine("54) Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.");
        System.Console.WriteLine("56) Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
        System.Console.WriteLine("58) Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.");
        System.Console.WriteLine("60) Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента. Массив размером 2 x 2 x 2");
        System.Console.WriteLine("62) Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.");
        System.Console.WriteLine("0) End");

        int numTask = SetNumber("task");

        switch (numTask)
        {
            case 0:  break;
            case 54: OrderingArray(); break;
            case 56: MaxSumOfElements(); break;
            case 58: ProductOfMatrices(); break;
            case 60: IndexMass(); break;
            case 62: SpiralMass(); break;

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

void OrderingArray() 
{
    int[,] array = new int[new Random().Next(3, 9), new Random().Next(3, 9)]; //создадим двухмерный рандомный массив

    //заполним массив случайными числами с помощью цикла
    for (int i = 0; i < array.GetLength(0); i++) 
    {
        for (int j = 0; j < array.GetLength(1); j++) 
        {
            array[i, j] = new Random().Next(10, 100);
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine(); 
    }
  
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1) - 1; j++) //(array.Length - 1) исскуственно отняли позицию, потому что дальше мы ее +
        {
            int minPosition = j; //обозначили переменную, с которой нам нужно делать изменения

            for (int c = j + 1; c < array.GetLength(1); c++) // начинаем цикл проверки не с начала, а от туда где остановились, поэтому (j+1)
            {
                if (array[i,c] > array[i,minPosition]) minPosition = c; //ищем мин элемент, если текущий элемент меньше мин, то эту позицию c нужно сохранить
            }

            int temporary = array[i,j];
            array[i,j] = array[i,minPosition]; //обмен двух переменных местами
            array[i,minPosition] = temporary; 
        }
    }
    Console.WriteLine(); 
    for (int i = 0; i < array.GetLength(0); i++) 
    {
        for (int j = 0; j < array.GetLength(1); j++) 
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine(); 
    }
    Console.WriteLine(); 
}

void MaxSumOfElements()
{
    int[,] array = new int[new Random().Next(3, 4), new Random().Next(4, 9)]; //создадим двухмерный рандомный массив

    for (int i = 0; i < array.GetLength(0); i++) 
    {
        for (int j = 0; j < array.GetLength(1); j++) 
        {
            array[i, j] = new Random().Next(1, 5);
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine(); 
    }
int indexMaxRow = 0;//номер максимальной строки
int rowSum = 0; //сумма всех элементов строки
int maxsum = 0; // максимальная сумма всех элементов одной из строки

    for (int i = 0; i < array.GetLength(0); i++) 
    {
        
        for (int j = 0; j < array.GetLength(1); j++) 
        {
            rowSum = rowSum + array[i, j];
        }
            if (rowSum >= maxsum) 
            {
                maxsum = rowSum;
                indexMaxRow = i;
            }
        rowSum = 0;
 
    }

     Console.WriteLine($"Строка с максимальной суммой элементов {indexMaxRow+1}");
}

void ProductOfMatrices()
{
    int[,] array1 = new int[new Random().Next(3, 4), new Random().Next(2, 3)]; //создадим двухмерный рандомный массив

    for (int i = 0; i < array1.GetLength(0); i++) 
    {
        for (int j = 0; j < array1.GetLength(1); j++) 
        {
            array1[i, j] = new Random().Next(1, 5);
            Console.Write(array1[i, j] + " ");
        }
        Console.WriteLine(); 
    }
    Console.WriteLine(); 

int[,] array2 = new int[new Random().Next(2, 3), new Random().Next(4, 5)]; //создадим двухмерный рандомный массив

    for (int i = 0; i < array2.GetLength(0); i++) 
    {
        for (int j = 0; j < array2.GetLength(1); j++) 
        {
            array2[i, j] = new Random().Next(1, 5);
            Console.Write(array2[i, j] + " ");
        }
        Console.WriteLine(); 
    }
Console.WriteLine(); 
//Произведение двух матриц АВ имеет смысл только в том случае, когда число столбцов матрицы А совпадает с числом строк матрицы В.
//В произведении матриц АВ число строк равно числу строк матрицы А, а число столбцов равно числу столбцов матрицы В.

if(array1.GetLength(1) == array2.GetLength(0))
{
    int[,] array3 = new int[array1.GetLength(0),array2.GetLength(1)];
    for (int i = 0; i < array3.GetLength(0); i++) 
    {
        for (int j = 0; j < array3.GetLength(1); j++) 
        {
            int sum = 0;
            for (int k = 0; k < array1.GetLength(1); k++)
            {
                sum += array1[i,k] * array2[k,j];
            }
            array3[i,j] = sum;
        }
    }
    Console.WriteLine("Произведение матриц равно:");
    for (int i = 0; i < array3.GetLength(0); i++) 
    {
        for (int j = 0; j < array3.GetLength(1); j++) 
        {
            Console.Write(array3[i, j] + " ");
        }
        Console.WriteLine(); 
    }
    Console.WriteLine(); 
}
else
{
    Console.WriteLine("Произведение матриц не возможно!");
}
}

void IndexMass()
{
    int[,,] array = new int[new Random().Next(2,2), new Random().Next(2,2), new Random().Next(2,2)]; //создадим трёхмерный рандомный массив 2x2x2

Random random = new Random();
 
for (int i = 0; i < array.GetLength(0); i++)
{
   for (int j = 0; j < array.GetLength(1); j++)
    {
        for (int k = 0; k < array.GetLength(2); k++)
        {
            array[i, j, k] = random.Next(10, 99);
            int t = array[i, j, k];
            int w = 0;
            if (w == t)
            {
                break;   
            }

            else
            {
                t = w;    
            }
        }
    }
}      
// Произведем поэтапный вывод массива, добавляя индексы каждого элемента.  

for (int i = 0; i < array.GetLength(0); i++)
{
   for (int j = 0; j < array.GetLength(1); j++)
       {
        for (int k = 0; k < array.GetLength(2); k++)
            {
            Console.Write(array[i, j, k] + " " + (i, j, k) +" ");
            }
        Console.WriteLine();
       }
}
Console.ReadLine();    
}

void SpiralMass()
{
    Console.WriteLine("Введите размер матрицы: ");
    int number = Convert.ToInt32(Console.ReadLine());

    int[,] array = new int[number, number]; //создадим двухмерный рандомный массив

    int n = number; //размерность массива
    int k = 1; //шаг в одну ячейку
    int x = 0;// текущее положение ячейки по строке в массиве
    int y = -1; //текущее положение ячейки по столбцам в массиве (не существующая левоя ячейка)
    int movementRow = 0; //движение по рядам (может принимать значение -1(идем вверх),0(находимся в том же ряду),1(спускаемся))
    int movementColumn = 1; //движение по столбцам (-1(влево),0,1(вправо))
   
    while(k <= n*n)
    {
        if(0 <= (x + movementRow) && (x + movementRow) < n && 0 <= (y + movementColumn) && (y + movementColumn) < n && array[x + movementRow, y + movementColumn] == 0)
        //проверяем шаг вперед: следующая ячейка не выходит за границы массива и она свободна
        {
            x = x + movementRow; //к х прибавляем движение по рядам
            y = y + movementColumn;// к у прибавляем движение по колонкам
            array[x, y] = k;
            k++;
        }

       else if  (movementColumn == 1) 
       //если вправо занято или выходим из предела массива мы должны произвести разворот и начать движение вниз
       {
            movementColumn = 0;
            movementRow = 1; 
       }

       else if (movementRow == 1)
       //если бы мы шли вниз и должны произвести разворот и начать идти влево
       {
            movementRow = 0;
            movementColumn = -1;
       }

       else if(movementColumn == -1) //если бы мы шли влево
       {
            movementColumn = 0;
            movementRow = -1; //должны начать подниматься вверх
       }
       
       else if (movementRow == -1) // мы поднимались вверх, должны начать идти вправо
        {
            movementRow = 0;
            movementColumn = 1;    
        }
    }

    Console.WriteLine("");
    Console.WriteLine($"Спиралевидная матрица размером {number} на {number}:");
    Console.WriteLine("");
    

     for (int i = 0; i < array.GetLength(0); i++) 
    {
        for (int j = 0; j < array.GetLength(1); j++) 
        {
            Console.Write(array[i, j] + "\t");
        }
        Console.WriteLine(); 
    }

    Console.WriteLine("");
}
