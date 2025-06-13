using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newSudoku
{
    class SudokuUI
    {
        private SudokuCell[,] cells = new SudokuCell[9, 9]; //массив для хранения клеток
        private Panel panel;
        private SudokuGame game;
        private Random random = new Random();

        public SudokuUI(Panel panel, SudokuGame game)
        {
            this.panel = panel;
            this.game = game;
            CreateCells();


        }

        private void CreateCells()
        {
            panel.Controls.Clear();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cells[i, j] = new SudokuCell //создаём новую клетку
                    {
                        Font = new Font(SystemFonts.DefaultFont.FontFamily, 20), //шрифт
                        Size = new Size(60, 60), //размер клетки
                        ForeColor = SystemColors.ControlDark, 
                        Location = new Point(i * 60, j * 60), //позиция клетки на панели
                        BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? SystemColors.Control : Color.LightGray, // цвет фона для выделения блоков 3x3
                        FlatStyle = FlatStyle.Flat,
                        IsLocked = false,
                        X = i,
                        Y = j
                    };
                    cells[i, j].FlatAppearance.BorderColor = Color.Black; //граница клетки

                    cells[i, j].KeyPress += Cell_KeyPress; // подписываемся на событие нажатия клавиши для ввода числа

                    panel.Controls.Add(cells[i, j]);
                }
            }
        }

        private void Cell_KeyPress(object sender, KeyPressEventArgs e)
        {
            var cell = sender as SudokuCell;

            if (cell.IsLocked) // если клетка заблокирована, ввод запрещен
                return;

            if (int.TryParse(e.KeyChar.ToString(), out int value)) //если нажатая - цифра
            {
                if (value == 0)
                    cell.Clear();
                else
                    cell.Text = value.ToString(); //занесение числа в клетку

                cell.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        public void StartNewGame(int hintsCount)
        {
            game.Generate();

            //заполнение клеток значениями из логики
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    cells[i, j].Value = game.Board[i, j];
                    cells[i, j].Clear();
                }

            ShowRandomHints(hintsCount); //отображаем случайные подсказки
        }

        private void ShowRandomHints(int hintsCount)
        {
            int shownHints = 0;
            while (shownHints < hintsCount)
            {
                //случайные индексы
                int rX = random.Next(9);
                int rY = random.Next(9);

                if (!cells[rX, rY].IsLocked && cells[rX, rY].Value != 0) // если клетка не заблокирована и значение не 0
                {
                    cells[rX, rY].Text = cells[rX, rY].Value.ToString(); // Отображаем значение на клетке
                    cells[rX, rY].ForeColor = Color.Black;
                    cells[rX, rY].IsLocked = true; // блокируем клетку (нельзя менять)
                    shownHints++;
                }
            }
        }
      
        public IEnumerable<SudokuCell> GetCells()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    yield return cells[i, j]; //возвращаем текущую клетку
                }
            }
        }
    }
}