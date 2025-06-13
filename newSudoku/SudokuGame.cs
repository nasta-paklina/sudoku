using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newSudoku
{
    class SudokuGame
    {
        //игровое поле - двумерный массив 9x9, хранит числа от 0 до 9 (где 0 - пусто)
        public int[,] Board { get; private set; } = new int[9, 9]; // генератор случайных чисел для выбора чисел при генерации
        private Random random = new Random();

        // метод очистки игрового поля (заполнение нулями)
        public void ClearBoard()
        {
            for (int i = 0; i < 9; i++) //по строкам
                for (int j = 0; j < 9; j++) //по столбцам
                    Board[i, j] = 0; //установка нулевого значения 
        }

        // метод генерации полностью заполненного корректного игрового поля
        public bool Generate()
        {
            ClearBoard();
            // запускаем рекурсивный метод для подбора значений по клеткам, начиная с позиции (0, -1)
            return FindValueForNextCell(0, -1);
        }

        // рекурсивный метод, пытающийся подобрать корректное значение для следующей клетки
        private bool FindValueForNextCell(int i, int j)
        {
            // передвигаемся по клеткам слева направо, сверху вниз
            if (++j > 8) // если дошли до конца строки
            {
                j = 0; // переходим к первому столбцу следующей строки
                if (++i > 8) // если дошли до конца последней строки - поле заполнено успешно
                    return true;
            }

            // список возможных значений, которые можем попробовать в этой клетке
            var numsLeft = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            while (numsLeft.Count > 0)
            {
                // выбираем случайное число из списка
                int index = random.Next(numsLeft.Count);
                int value = numsLeft[index];
                numsLeft.RemoveAt(index); // убираем выбранное число из списка, чтобы не пробовать повторно

                // проверяем валидность установки value в клетку (i, j)
                if (IsValid(i, j, value))
                {
                    Board[i, j] = value; // устанавливаем число на поле

                    if (FindValueForNextCell(i, j)) // рекурсивно пытаемся заполнить следующую клетку
                        return true;
                }
            }

            // если подходящее значение не найдено - откатываем изменения и возвращаем false
            Board[i, j] = 0;
            return false;
        }

        // метод проверки, можно ли поставить значение val на позицию (x, y) по правилам судоку
        private bool IsValid(int x, int y, int val)
        {
            // проверка строки и столбца
            for (int k = 0; k < 9; k++)
            {
                if (Board[x, k] == val) return false;
                if (Board[k, y] == val) return false;
            }
            // проверка блока 3x3, которому принадлежит клетка (x, y)
            int startX = (x / 3) * 3;
            int startY = (y / 3) * 3;
            //Проходим по всем клеткам внутри текущего 3x3 блока.
            for (int i = startX; i < startX + 3; i++)
                for (int j = startY; j < startY + 3; j++)
                    if (Board[i, j] == val) //если число уже есть
                        return false;

            return true;
        }
    }
}