namespace newSudoku
{
    public partial class Form1 : Form
    {
        private SudokuGame game;
        private SudokuUI ui;

        public Form1()
        {
            InitializeComponent();

            game = new SudokuGame(); // создаем новую игру (логику)
            ui = new SudokuUI(panel1, game); //св€зываем с панелью и игрой

            StartNewGame();

            //обработчики событий кнопок
            checkButton.Click += checkButton_Click;
            clearButton.Click += clearButton_Click;
        }

        private void StartNewGame()
        {
            int hintsCount = 0; // количество подсказок зависит от уровн€ сложности

            if (beginnerLevel.Checked)
                hintsCount = 45;
            else if (IntermediateLevel.Checked)
                hintsCount = 30;
            else if (AdvancedLevel.Checked)
                hintsCount = 20;

            ui.StartNewGame(hintsCount); //запуск с нужным кол-вом подсказок
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            bool allFilled = true; // флаг: все клетки заполнены?
            bool allCorrect = true; //все ответы верны?

            // провер€ем все клетки
            foreach (var cell in ui.GetCells())
            {
                if (!cell.IsLocked && string.IsNullOrEmpty(cell.Text))
                {
                    allFilled = false; // незаполненные клетки
                    break;
                }
            }
            foreach (var cell in ui.GetCells())
            {
                if (!cell.IsLocked && string.IsNullOrEmpty(cell.Text))
                {
                    allFilled = false; // незаполненные клетки
                }
                else if (!cell.IsLocked && cell.Text != cell.Value.ToString())
                {
                    allCorrect = false;
                    cell.ForeColor = Color.Red; // помечаем неверные ответы
                }
                else if (cell.IsLocked)
                {
                    cell.ForeColor = Color.Black; // подсказки остаютс€ черными
                }
                else
                {
                    cell.ForeColor = SystemColors.ControlDarkDark;// верные ответы
                }
            }

            if (!allFilled)
                {
                    MessageBox.Show("Ќе все клетки заполнены!", "¬нимание",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!allCorrect)
                {
                    MessageBox.Show("≈сть ошибки в решении!", "ќшибка",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var result = MessageBox.Show("ѕоздравл€ем! –ешение верное!\nѕродолжить игру?", "ѕобеда",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        // "Ќова€ игра"

                    }
                    else
                    {
                        // "«авершить игру"
                        Application.Exit();
                    }
                }
            }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // очищаем только незаблокированные клетки (не подсказки)
            foreach (var cell in ui.GetCells())
            {
                if (!cell.IsLocked)
                {
                    cell.Clear();
                    cell.ForeColor = SystemColors.ControlDarkDark;
                }
            }
        }
    }
}