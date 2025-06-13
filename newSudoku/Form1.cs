namespace newSudoku
{
    public partial class Form1 : Form
    {
        private SudokuGame game;
        private SudokuUI ui;

        public Form1()
        {
            InitializeComponent();

            game = new SudokuGame(); // ������� ����� ���� (������)
            ui = new SudokuUI(panel1, game); //��������� � ������� � �����

            StartNewGame();

            //����������� ������� ������
            checkButton.Click += checkButton_Click;
            clearButton.Click += clearButton_Click;
        }

        private void StartNewGame()
        {
            int hintsCount = 0; // ���������� ��������� ������� �� ������ ���������

            if (beginnerLevel.Checked)
                hintsCount = 45;
            else if (IntermediateLevel.Checked)
                hintsCount = 30;
            else if (AdvancedLevel.Checked)
                hintsCount = 20;

            ui.StartNewGame(hintsCount); //������ � ������ ���-��� ���������
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            bool allFilled = true; // ����: ��� ������ ���������?
            bool allCorrect = true; //��� ������ �����?

            // ��������� ��� ������
            foreach (var cell in ui.GetCells())
            {
                if (!cell.IsLocked && string.IsNullOrEmpty(cell.Text))
                {
                    allFilled = false; // ������������� ������
                    break;
                }
            }
            foreach (var cell in ui.GetCells())
            {
                if (!cell.IsLocked && string.IsNullOrEmpty(cell.Text))
                {
                    allFilled = false; // ������������� ������
                }
                else if (!cell.IsLocked && cell.Text != cell.Value.ToString())
                {
                    allCorrect = false;
                    cell.ForeColor = Color.Red; // �������� �������� ������
                }
                else if (cell.IsLocked)
                {
                    cell.ForeColor = Color.Black; // ��������� �������� �������
                }
                else
                {
                    cell.ForeColor = SystemColors.ControlDarkDark;// ������ ������
                }
            }

            if (!allFilled)
                {
                    MessageBox.Show("�� ��� ������ ���������!", "��������",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!allCorrect)
                {
                    MessageBox.Show("���� ������ � �������!", "������",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var result = MessageBox.Show("�����������! ������� ������!\n���������� ����?", "������",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        // "����� ����"

                    }
                    else
                    {
                        // "��������� ����"
                        Application.Exit();
                    }
                }
            }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // ������� ������ ����������������� ������ (�� ���������)
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