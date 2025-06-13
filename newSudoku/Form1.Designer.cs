namespace newSudoku
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            newGameButton = new Button();
            checkButton = new Button();
            clearButton = new Button();
            beginnerLevel = new RadioButton();
            IntermediateLevel = new RadioButton();
            AdvancedLevel = new RadioButton();
            label1 = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(65, 51);
            panel1.Name = "panel1";
            panel1.Size = new Size(680, 739);
            panel1.TabIndex = 0;
            // 
            // newGameButton
            // 
            newGameButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newGameButton.Location = new Point(796, 674);
            newGameButton.Name = "newGameButton";
            newGameButton.Size = new Size(159, 100);
            newGameButton.TabIndex = 1;
            newGameButton.Text = "Новая игра";
            newGameButton.UseVisualStyleBackColor = true;
            newGameButton.Click += newGameButton_Click;
            // 
            // checkButton
            // 
            checkButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkButton.Location = new Point(796, 88);
            checkButton.Name = "checkButton";
            checkButton.Size = new Size(159, 100);
            checkButton.TabIndex = 2;
            checkButton.Text = "Проверить решения";
            checkButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            clearButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clearButton.Location = new Point(796, 215);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(159, 100);
            clearButton.TabIndex = 2;
            clearButton.Text = "Отчистить решения";
            clearButton.UseVisualStyleBackColor = true;
            // 
            // beginnerLevel
            // 
            beginnerLevel.AutoSize = true;
            beginnerLevel.Checked = true;
            beginnerLevel.Location = new Point(828, 522);
            beginnerLevel.Name = "beginnerLevel";
            beginnerLevel.Size = new Size(79, 24);
            beginnerLevel.TabIndex = 3;
            beginnerLevel.TabStop = true;
            beginnerLevel.Text = "Лёгкий";
            beginnerLevel.UseVisualStyleBackColor = true;
            // 
            // IntermediateLevel
            // 
            IntermediateLevel.AutoSize = true;
            IntermediateLevel.Location = new Point(828, 569);
            IntermediateLevel.Name = "IntermediateLevel";
            IntermediateLevel.Size = new Size(91, 24);
            IntermediateLevel.TabIndex = 3;
            IntermediateLevel.Text = "Средний";
            IntermediateLevel.UseVisualStyleBackColor = true;
            // 
            // AdvancedLevel
            // 
            AdvancedLevel.AutoSize = true;
            AdvancedLevel.Location = new Point(828, 616);
            AdvancedLevel.Name = "AdvancedLevel";
            AdvancedLevel.Size = new Size(96, 24);
            AdvancedLevel.TabIndex = 3;
            AdvancedLevel.Text = "Сложный";
            AdvancedLevel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(819, 461);
            label1.Name = "label1";
            label1.Size = new Size(111, 29);
            label1.TabIndex = 4;
            label1.Text = "Уровень";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 836);
            Controls.Add(label1);
            Controls.Add(AdvancedLevel);
            Controls.Add(IntermediateLevel);
            Controls.Add(beginnerLevel);
            Controls.Add(clearButton);
            Controls.Add(checkButton);
            Controls.Add(newGameButton);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Судоку классическое";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.RadioButton beginnerLevel;
        private System.Windows.Forms.RadioButton IntermediateLevel;
        private System.Windows.Forms.RadioButton AdvancedLevel;
        private System.Windows.Forms.Label label1;
    }
}