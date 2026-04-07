namespace LAB1_TFK
{
    partial class GUI
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            создатьToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьКакToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            правкаToolStripMenuItem = new ToolStripMenuItem();
            отменитьToolStripMenuItem = new ToolStripMenuItem();
            повторитьToolStripMenuItem = new ToolStripMenuItem();
            вырезатьToolStripMenuItem = new ToolStripMenuItem();
            копироватьToolStripMenuItem = new ToolStripMenuItem();
            вставитьToolStripMenuItem = new ToolStripMenuItem();
            удалитьToolStripMenuItem = new ToolStripMenuItem();
            выделитьВсеToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            постановкаЗадачиToolStripMenuItem1 = new ToolStripMenuItem();
            грамматикаToolStripMenuItem1 = new ToolStripMenuItem();
            классификацияГрамматикиToolStripMenuItem = new ToolStripMenuItem();
            методАнализаToolStripMenuItem = new ToolStripMenuItem();
            тестовыйПримерToolStripMenuItem = new ToolStripMenuItem();
            списокЛитературыToolStripMenuItem = new ToolStripMenuItem();
            исходныйКодПрограммыToolStripMenuItem = new ToolStripMenuItem();
            пускToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem1 = new ToolStripMenuItem();
            справкаToolStripMenuItem2 = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            ToolStripButtonCreate = new ToolStripButton();
            toolStripButtonOpen = new ToolStripButton();
            toolStripButtonSave = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButtonBack = new ToolStripButton();
            toolStripButtonForward = new ToolStripButton();
            toolStripButtonCopy = new ToolStripButton();
            toolStripButtonCut = new ToolStripButton();
            toolStripButtonPast = new ToolStripButton();
            toolStripButtonRun = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButtonQuestion = new ToolStripButton();
            toolStripButtonInformation = new ToolStripButton();
            dataGridViewLexer = new DataGridView();
            splitContainer1 = new SplitContainer();
            richTextBoxCompil = new RichTextBox();
            tabControl1 = new TabControl();
            Parser = new TabPage();
            dataGridViewParser = new DataGridView();
            Lexer = new TabPage();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLexer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
            Parser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewParser).BeginInit();
            Lexer.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, правкаToolStripMenuItem, toolStripMenuItem1, пускToolStripMenuItem, справкаToolStripMenuItem1 });
            menuStrip1.Location = new Point(5, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(790, 31);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { создатьToolStripMenuItem, открытьToolStripMenuItem, сохранитьToolStripMenuItem, сохранитьКакToolStripMenuItem, выходToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(64, 27);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьToolStripMenuItem
            // 
            создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            создатьToolStripMenuItem.Size = new Size(208, 28);
            создатьToolStripMenuItem.Text = "Создать";
            создатьToolStripMenuItem.Click += создатьToolStripMenuItem_Click;
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(208, 28);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(208, 28);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // сохранитьКакToolStripMenuItem
            // 
            сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            сохранитьКакToolStripMenuItem.Size = new Size(208, 28);
            сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            сохранитьКакToolStripMenuItem.Click += сохранитьКакToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(208, 28);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click_1;
            // 
            // правкаToolStripMenuItem
            // 
            правкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { отменитьToolStripMenuItem, повторитьToolStripMenuItem, вырезатьToolStripMenuItem, копироватьToolStripMenuItem, вставитьToolStripMenuItem, удалитьToolStripMenuItem, выделитьВсеToolStripMenuItem });
            правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            правкаToolStripMenuItem.Size = new Size(81, 27);
            правкаToolStripMenuItem.Text = "Правка";
            // 
            // отменитьToolStripMenuItem
            // 
            отменитьToolStripMenuItem.Name = "отменитьToolStripMenuItem";
            отменитьToolStripMenuItem.Size = new Size(200, 28);
            отменитьToolStripMenuItem.Text = "Отменить";
            отменитьToolStripMenuItem.Click += отменитьToolStripMenuItem_Click;
            // 
            // повторитьToolStripMenuItem
            // 
            повторитьToolStripMenuItem.Name = "повторитьToolStripMenuItem";
            повторитьToolStripMenuItem.Size = new Size(200, 28);
            повторитьToolStripMenuItem.Text = "Повторить";
            повторитьToolStripMenuItem.Click += повторитьToolStripMenuItem_Click;
            // 
            // вырезатьToolStripMenuItem
            // 
            вырезатьToolStripMenuItem.Name = "вырезатьToolStripMenuItem";
            вырезатьToolStripMenuItem.Size = new Size(200, 28);
            вырезатьToolStripMenuItem.Text = "Вырезать";
            вырезатьToolStripMenuItem.Click += вырезатьToolStripMenuItem_Click;
            // 
            // копироватьToolStripMenuItem
            // 
            копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            копироватьToolStripMenuItem.Size = new Size(200, 28);
            копироватьToolStripMenuItem.Text = "Копировать";
            копироватьToolStripMenuItem.Click += копироватьToolStripMenuItem_Click;
            // 
            // вставитьToolStripMenuItem
            // 
            вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            вставитьToolStripMenuItem.Size = new Size(200, 28);
            вставитьToolStripMenuItem.Text = "Вставить";
            вставитьToolStripMenuItem.Click += вставитьToolStripMenuItem_Click;
            // 
            // удалитьToolStripMenuItem
            // 
            удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            удалитьToolStripMenuItem.Size = new Size(200, 28);
            удалитьToolStripMenuItem.Text = "Удалить";
            удалитьToolStripMenuItem.Click += удалитьToolStripMenuItem_Click;
            // 
            // выделитьВсеToolStripMenuItem
            // 
            выделитьВсеToolStripMenuItem.Name = "выделитьВсеToolStripMenuItem";
            выделитьВсеToolStripMenuItem.Size = new Size(200, 28);
            выделитьВсеToolStripMenuItem.Text = "Выделить все";
            выделитьВсеToolStripMenuItem.Click += выделитьВсеToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { постановкаЗадачиToolStripMenuItem1, грамматикаToolStripMenuItem1, классификацияГрамматикиToolStripMenuItem, методАнализаToolStripMenuItem, тестовыйПримерToolStripMenuItem, списокЛитературыToolStripMenuItem, исходныйКодПрограммыToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(65, 27);
            toolStripMenuItem1.Text = "Текст";
            // 
            // постановкаЗадачиToolStripMenuItem1
            // 
            постановкаЗадачиToolStripMenuItem1.Name = "постановкаЗадачиToolStripMenuItem1";
            постановкаЗадачиToolStripMenuItem1.Size = new Size(315, 28);
            постановкаЗадачиToolStripMenuItem1.Text = "Постановка задачи";
            // 
            // грамматикаToolStripMenuItem1
            // 
            грамматикаToolStripMenuItem1.Name = "грамматикаToolStripMenuItem1";
            грамматикаToolStripMenuItem1.Size = new Size(315, 28);
            грамматикаToolStripMenuItem1.Text = "Грамматика";
            // 
            // классификацияГрамматикиToolStripMenuItem
            // 
            классификацияГрамматикиToolStripMenuItem.Name = "классификацияГрамматикиToolStripMenuItem";
            классификацияГрамматикиToolStripMenuItem.Size = new Size(315, 28);
            классификацияГрамматикиToolStripMenuItem.Text = "Классификация грамматики";
            // 
            // методАнализаToolStripMenuItem
            // 
            методАнализаToolStripMenuItem.Name = "методАнализаToolStripMenuItem";
            методАнализаToolStripMenuItem.Size = new Size(315, 28);
            методАнализаToolStripMenuItem.Text = "Метод анализа";
            // 
            // тестовыйПримерToolStripMenuItem
            // 
            тестовыйПримерToolStripMenuItem.Name = "тестовыйПримерToolStripMenuItem";
            тестовыйПримерToolStripMenuItem.Size = new Size(315, 28);
            тестовыйПримерToolStripMenuItem.Text = "Тестовый пример";
            // 
            // списокЛитературыToolStripMenuItem
            // 
            списокЛитературыToolStripMenuItem.Name = "списокЛитературыToolStripMenuItem";
            списокЛитературыToolStripMenuItem.Size = new Size(315, 28);
            списокЛитературыToolStripMenuItem.Text = "Список литературы";
            // 
            // исходныйКодПрограммыToolStripMenuItem
            // 
            исходныйКодПрограммыToolStripMenuItem.Name = "исходныйКодПрограммыToolStripMenuItem";
            исходныйКодПрограммыToolStripMenuItem.Size = new Size(315, 28);
            исходныйКодПрограммыToolStripMenuItem.Text = "Исходный код программы";
            // 
            // пускToolStripMenuItem
            // 
            пускToolStripMenuItem.Name = "пускToolStripMenuItem";
            пускToolStripMenuItem.Size = new Size(60, 27);
            пускToolStripMenuItem.Text = "Пуск";
            пускToolStripMenuItem.Click += пускToolStripMenuItem_Click;
            // 
            // справкаToolStripMenuItem1
            // 
            справкаToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { справкаToolStripMenuItem2, оПрограммеToolStripMenuItem });
            справкаToolStripMenuItem1.Name = "справкаToolStripMenuItem1";
            справкаToolStripMenuItem1.Size = new Size(90, 27);
            справкаToolStripMenuItem1.Text = "Справка";
            // 
            // справкаToolStripMenuItem2
            // 
            справкаToolStripMenuItem2.Name = "справкаToolStripMenuItem2";
            справкаToolStripMenuItem2.Size = new Size(212, 28);
            справкаToolStripMenuItem2.Text = "Вызов справки";
            справкаToolStripMenuItem2.Click += справкаToolStripMenuItem2_Click;
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(212, 28);
            оПрограммеToolStripMenuItem.Text = "О программе";
            оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(22, 22);
            toolStrip1.Items.AddRange(new ToolStripItem[] { ToolStripButtonCreate, toolStripButtonOpen, toolStripButtonSave, toolStripSeparator1, toolStripButtonBack, toolStripButtonForward, toolStripButtonCopy, toolStripButtonCut, toolStripButtonPast, toolStripButtonRun, toolStripSeparator2, toolStripButtonQuestion, toolStripButtonInformation });
            toolStrip1.Location = new Point(5, 31);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(790, 29);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // ToolStripButtonCreate
            // 
            ToolStripButtonCreate.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ToolStripButtonCreate.Image = TextRed_lab1.Properties.Resources.icons8_создать_файл_50;
            ToolStripButtonCreate.ImageTransparentColor = Color.Magenta;
            ToolStripButtonCreate.Name = "ToolStripButtonCreate";
            ToolStripButtonCreate.Size = new Size(29, 26);
            ToolStripButtonCreate.Text = "Создать";
            ToolStripButtonCreate.Click += ToolStripButtonCreate_Click;
            // 
            // toolStripButtonOpen
            // 
            toolStripButtonOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonOpen.Image = TextRed_lab1.Properties.Resources.icons8_папка_50;
            toolStripButtonOpen.ImageTransparentColor = Color.Magenta;
            toolStripButtonOpen.Name = "toolStripButtonOpen";
            toolStripButtonOpen.Size = new Size(29, 26);
            toolStripButtonOpen.Text = "Открыть";
            toolStripButtonOpen.Click += toolStripButtonOpen_Click;
            // 
            // toolStripButtonSave
            // 
            toolStripButtonSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonSave.Image = TextRed_lab1.Properties.Resources.icons8_сохранить_50;
            toolStripButtonSave.ImageTransparentColor = Color.Magenta;
            toolStripButtonSave.Name = "toolStripButtonSave";
            toolStripButtonSave.Size = new Size(29, 26);
            toolStripButtonSave.Text = "Сохранить";
            toolStripButtonSave.Click += toolStripButtonSave_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 29);
            // 
            // toolStripButtonBack
            // 
            toolStripButtonBack.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonBack.Image = TextRed_lab1.Properties.Resources.icons8_стрелка_назад_50;
            toolStripButtonBack.ImageTransparentColor = Color.Magenta;
            toolStripButtonBack.Name = "toolStripButtonBack";
            toolStripButtonBack.Size = new Size(29, 26);
            toolStripButtonBack.Text = "Отмена изменений";
            toolStripButtonBack.Click += toolStripButtonBack_Click;
            // 
            // toolStripButtonForward
            // 
            toolStripButtonForward.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonForward.Image = TextRed_lab1.Properties.Resources.icons8_forward_arrow_50;
            toolStripButtonForward.ImageTransparentColor = Color.Magenta;
            toolStripButtonForward.Name = "toolStripButtonForward";
            toolStripButtonForward.Size = new Size(29, 26);
            toolStripButtonForward.Text = "Повтор последнего изменения";
            toolStripButtonForward.Click += toolStripButtonForward_Click;
            // 
            // toolStripButtonCopy
            // 
            toolStripButtonCopy.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonCopy.Image = TextRed_lab1.Properties.Resources.icons8_скопировать_50;
            toolStripButtonCopy.ImageTransparentColor = Color.Magenta;
            toolStripButtonCopy.Name = "toolStripButtonCopy";
            toolStripButtonCopy.Size = new Size(29, 26);
            toolStripButtonCopy.Text = "Копировать текст";
            toolStripButtonCopy.Click += toolStripButtonCopy_Click;
            // 
            // toolStripButtonCut
            // 
            toolStripButtonCut.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonCut.Image = TextRed_lab1.Properties.Resources.icons8_вырезать_50;
            toolStripButtonCut.ImageTransparentColor = Color.Magenta;
            toolStripButtonCut.Name = "toolStripButtonCut";
            toolStripButtonCut.Size = new Size(29, 26);
            toolStripButtonCut.Text = "Вырезать";
            toolStripButtonCut.Click += toolStripButtonCut_Click;
            // 
            // toolStripButtonPast
            // 
            toolStripButtonPast.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonPast.Image = (Image)resources.GetObject("toolStripButtonPast.Image");
            toolStripButtonPast.ImageTransparentColor = Color.Magenta;
            toolStripButtonPast.Name = "toolStripButtonPast";
            toolStripButtonPast.Size = new Size(29, 26);
            toolStripButtonPast.Text = "Вставить";
            toolStripButtonPast.Click += toolStripButtonPast_Click;
            // 
            // toolStripButtonRun
            // 
            toolStripButtonRun.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonRun.Image = TextRed_lab1.Properties.Resources.icons8_начало_501;
            toolStripButtonRun.ImageTransparentColor = Color.Magenta;
            toolStripButtonRun.Name = "toolStripButtonRun";
            toolStripButtonRun.Size = new Size(29, 26);
            toolStripButtonRun.Text = "Запуск";
            toolStripButtonRun.Click += toolStripButtonRun_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 29);
            // 
            // toolStripButtonQuestion
            // 
            toolStripButtonQuestion.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonQuestion.Image = TextRed_lab1.Properties.Resources.icons8_вопросительный_знак_50;
            toolStripButtonQuestion.ImageTransparentColor = Color.Magenta;
            toolStripButtonQuestion.Name = "toolStripButtonQuestion";
            toolStripButtonQuestion.Size = new Size(29, 26);
            toolStripButtonQuestion.Text = "Справка";
            toolStripButtonQuestion.Click += toolStripButtonQuestion_Click;
            // 
            // toolStripButtonInformation
            // 
            toolStripButtonInformation.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonInformation.Image = TextRed_lab1.Properties.Resources.icons8_знак_информации_в_квадрате_50;
            toolStripButtonInformation.ImageTransparentColor = Color.Magenta;
            toolStripButtonInformation.Name = "toolStripButtonInformation";
            toolStripButtonInformation.Size = new Size(29, 26);
            toolStripButtonInformation.Text = "Информация о программе";
            toolStripButtonInformation.Click += toolStripButtonInformation_Click;
            // 
            // dataGridViewLexer
            // 
            dataGridViewLexer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLexer.BackgroundColor = SystemColors.Window;
            dataGridViewLexer.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewLexer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLexer.Dock = DockStyle.Fill;
            dataGridViewLexer.Location = new Point(3, 3);
            dataGridViewLexer.Margin = new Padding(3, 4, 3, 4);
            dataGridViewLexer.Name = "dataGridViewLexer";
            dataGridViewLexer.RowHeadersWidth = 51;
            dataGridViewLexer.RowTemplate.Height = 24;
            dataGridViewLexer.Size = new Size(776, 314);
            dataGridViewLexer.TabIndex = 3;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(5, 60);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(richTextBoxCompil);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Size = new Size(790, 550);
            splitContainer1.SplitterDistance = 192;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 4;
            // 
            // richTextBoxCompil
            // 
            richTextBoxCompil.BackColor = SystemColors.Window;
            richTextBoxCompil.Dock = DockStyle.Fill;
            richTextBoxCompil.Location = new Point(0, 0);
            richTextBoxCompil.Margin = new Padding(3, 4, 3, 4);
            richTextBoxCompil.Name = "richTextBoxCompil";
            richTextBoxCompil.Size = new Size(790, 192);
            richTextBoxCompil.TabIndex = 3;
            richTextBoxCompil.Text = "";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Parser);
            tabControl1.Controls.Add(Lexer);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(790, 353);
            tabControl1.TabIndex = 4;
            // 
            // Parser
            // 
            Parser.Controls.Add(dataGridViewParser);
            Parser.Location = new Point(4, 29);
            Parser.Name = "Parser";
            Parser.Padding = new Padding(3);
            Parser.Size = new Size(782, 320);
            Parser.TabIndex = 0;
            Parser.Text = "Парсер";
            Parser.UseVisualStyleBackColor = true;
            // 
            // dataGridViewParser
            // 
            dataGridViewParser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewParser.BackgroundColor = SystemColors.Window;
            dataGridViewParser.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewParser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewParser.Dock = DockStyle.Fill;
            dataGridViewParser.Location = new Point(3, 3);
            dataGridViewParser.Margin = new Padding(3, 4, 3, 4);
            dataGridViewParser.Name = "dataGridViewParser";
            dataGridViewParser.RowHeadersWidth = 51;
            dataGridViewParser.RowTemplate.Height = 29;
            dataGridViewParser.Size = new Size(776, 314);
            dataGridViewParser.TabIndex = 0;
            // 
            // Lexer
            // 
            Lexer.Controls.Add(dataGridViewLexer);
            Lexer.Location = new Point(4, 29);
            Lexer.Name = "Lexer";
            Lexer.Padding = new Padding(3);
            Lexer.Size = new Size(782, 320);
            Lexer.TabIndex = 1;
            Lexer.Text = "Лексер";
            Lexer.UseVisualStyleBackColor = true;
            // 
            // GUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(800, 616);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "GUI";
            Padding = new Padding(5, 0, 5, 6);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Компилятор";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLexer).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            Parser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewParser).EndInit();
            Lexer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem правкаToolStripMenuItem;
        private ToolStripMenuItem создатьToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem отменитьToolStripMenuItem;
        private ToolStripMenuItem повторитьToolStripMenuItem;
        private ToolStripMenuItem вырезатьToolStripMenuItem;
        private ToolStripMenuItem копироватьToolStripMenuItem;
        private ToolStripMenuItem вставитьToolStripMenuItem;
        private ToolStripMenuItem удалитьToolStripMenuItem;
        private ToolStripMenuItem выделитьВсеToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem постановкаЗадачиToolStripMenuItem1;
        private ToolStripMenuItem грамматикаToolStripMenuItem1;
        private ToolStripMenuItem классификацияГрамматикиToolStripMenuItem;
        private ToolStripMenuItem методАнализаToolStripMenuItem;
        private ToolStripMenuItem тестовыйПримерToolStripMenuItem;
        private ToolStripMenuItem списокЛитературыToolStripMenuItem;
        private ToolStripMenuItem исходныйКодПрограммыToolStripMenuItem;
        private ToolStripMenuItem пускToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton ToolStripButtonCreate;
        private ToolStripButton toolStripButtonOpen;
        private ToolStripButton toolStripButtonSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButtonBack;
        private ToolStripButton toolStripButtonForward;
        private ToolStripButton toolStripButtonCopy;
        private ToolStripButton toolStripButtonCut;
        private ToolStripButton toolStripButtonPast;
        private DataGridView dataGridViewLexer;
        private ToolStripButton toolStripButtonRun;
        private ToolStripButton toolStripButtonQuestion;
        private ToolStripButton toolStripButtonInformation;
        private SplitContainer splitContainer1;
        private ToolStripMenuItem справкаToolStripMenuItem1;
        private ToolStripMenuItem справкаToolStripMenuItem2;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private RichTextBox richTextBoxCompil;
        private ToolStripSeparator toolStripSeparator2;
        private TabControl tabControl1;
        private TabPage Parser;
        private TabPage Lexer;
        private DataGridView dataGridViewParser;
    }
}