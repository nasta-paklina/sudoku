using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newSudoku
{
    class SudokuCell : Button //класс с наследованием от button
    {
        public int Value { get; set; } //св-во для хранения числа судоку
        public bool IsLocked { get; set; } //заблокиравана или нет ячейка (неизм.)
        //координаты этой ячейки
        public int X { get; set; } 
        public int Y { get; set; }

        public void Clear()
        {
            this.Text = string.Empty; // Очищает текст кнопки (удаляет отображаемое число)
            this.IsLocked = false; // Снимает блокировку, позволяя изменять значение ячейки
        }
    }
}