using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;

namespace LAB1_TFK
{
    public partial class GUI : Form
    {
        private string currentFilePath = null;
        private bool isTextChanged = false;
        int errorPosition = -1;
        public GUI()
        {
            InitializeComponent();
            richTextBoxCompil.TextChanged += richTextBoxCompil_TextChanged;
            this.FormClosing += GUI_FormClosing;
            dataGridViewLexer.CellClick += dataGridView1_CellClick;
            dataGridViewParser.CellClick += dataGridViewParser_CellClick;
        }
        private void richTextBoxCompil_TextChanged(object sender, EventArgs e)
        {
            isTextChanged = true;
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Visible && !string.IsNullOrWhiteSpace(richTextBoxCompil.Text))
            {
                DialogResult result = MessageBox.Show(
                    "Сохранить изменения перед созданием нового файла?",
                    "Создание нового файла",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    сохранитьToolStripMenuItem_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            richTextBoxCompil.Clear();
            dataGridViewLexer.Rows.Clear();
            dataGridViewLexer.Columns.Clear();

            currentFilePath = null;

            isTextChanged = false;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.Title = "Открыть текстовый файл";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Читаем весь текст из выбранного файла
                    string fileContent = File.ReadAllText(openFileDialog.FileName);

                    splitContainer1.Visible = true;

                    // Вставляем текст в текстовое поле
                    richTextBoxCompil.Text = fileContent;

                    dataGridViewLexer.Rows.Clear();
                    dataGridViewLexer.Columns.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при открытии файла: " + ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Если новый файл, вызываем "Сохранить как"
            if (string.IsNullOrEmpty(currentFilePath))
            {
                сохранитьКакToolStripMenuItem_Click(sender, e);
            }
            else
            {
                try
                {
                    File.WriteAllText(currentFilePath, richTextBoxCompil.Text);
                    isTextChanged = false;

                    MessageBox.Show("Файл успешно сохранен!", "Сохранение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении файла: " + ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.splitContainer1.Visible)
            {
                MessageBox.Show("Нет активного документа для сохранения.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(saveFileDialog.FileName, richTextBoxCompil.Text);
                        currentFilePath = saveFileDialog.FileName;
                        isTextChanged = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при сохранении файла: " + ex.Message, "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (isTextChanged)
            {
                DialogResult result = MessageBox.Show(
                    "Сохранить изменения перед выходом?",
                    "Выход из программы",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    сохранитьToolStripMenuItem_Click(sender, e);

                    if (!isTextChanged)
                    {
                        Application.Exit();
                    }
                }
                else if (result == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBoxCompil.CanUndo)
            {
                richTextBoxCompil.Undo();
            }
        }

        private void повторитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBoxCompil.CanRedo)
            {
                richTextBoxCompil.Redo();
            }
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxCompil.Cut();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxCompil.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxCompil.Paste();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Удаляем выделенный текст
            int selectionStart = richTextBoxCompil.SelectionStart;
            int selectionLength = richTextBoxCompil.SelectionLength;

            if (selectionLength > 0)
            {
                richTextBoxCompil.Text = richTextBoxCompil.Text.Remove(selectionStart, selectionLength);
                richTextBoxCompil.SelectionStart = selectionStart;
            }
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxCompil.SelectAll();
        }

        private void справкаToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string helpText = "СПРАВКА ПО ПРОГРАММЕ\n\n";
            helpText += "МЕНЮ «ФАЙЛ»:\n";
            helpText += "• Создать - создает новый пустой файл\n";
            helpText += "• Открыть - открывает существующий текстовый файл\n";
            helpText += "• Сохранить - сохраняет текущий файл\n";
            helpText += "• Сохранить как - сохраняет файл под новым именем\n";
            helpText += "• Выход - выход из программы с подтверждением сохранения\n\n";

            helpText += "МЕНЮ «ПРАВКА»:\n";
            helpText += "• Отменить - отменяет последнее действие\n";
            helpText += "• Повторить - повторяет отмененное действие\n";
            helpText += "• Вырезать - вырезает выделенный текст в буфер обмена\n";
            helpText += "• Копировать - копирует выделенный текст в буфер обмена\n";
            helpText += "• Вставить - вставляет текст из буфера обмена\n";
            helpText += "• Удалить - удаляет выделенный текст\n";
            helpText += "• Выделить все - выделяет весь текст в редакторе\n\n";

            helpText += "МЕНЮ «СПРАВКА»:\n";
            helpText += "• Вызов справки - описание функций\n";
            helpText += "• О программе - информация о программе";

            MessageBox.Show(helpText, "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string aboutText = "О ПРОГРАММЕ\n\n";
            aboutText += "Название: Текстовый редактор\n\n";
            aboutText += "Описание:\n";
            aboutText += "Интегрированная среда разработки (IDE) для компиляции и выполнения программ на языке программирования. \n";
            aboutText += "Приложение объединяет текстовый редактор исходного кода и исполнительную систему компилятора.\n\n";
            aboutText += "Автор: Комиссарова Юлия АП-326\n";
            aboutText += "Дисциплина: Теория формальных языков и компиляторов\n";
            aboutText += "Год: 2026\n\n";

            MessageBox.Show(aboutText, "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ToolStripButtonCreate_Click(object sender, EventArgs e)
        {
            создатьToolStripMenuItem_Click(sender, e);
        }
        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            открытьToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            сохранитьToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonBack_Click(object sender, EventArgs e)
        {
            отменитьToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonForward_Click(object sender, EventArgs e)
        {
            повторитьToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            копироватьToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonCut_Click(object sender, EventArgs e)
        {
            вырезатьToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonPast_Click(object sender, EventArgs e)
        {
            вставитьToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonRun_Click(object sender, EventArgs e)
        {
            пускToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonQuestion_Click(object sender, EventArgs e)
        {
            справкаToolStripMenuItem2_Click(sender, e);
        }

        private void toolStripButtonInformation_Click(object sender, EventArgs e)
        {
            оПрограммеToolStripMenuItem_Click(sender, e);
        }
        private void GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isTextChanged)
            {
                DialogResult result = MessageBox.Show(
                    "Сохранить изменения перед выходом?",
                    "Выход из программы",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    сохранитьToolStripMenuItem_Click(sender, e);

                    // Если после сохранения текст всё ещё изменён (сохранение не удалось или отменено)
                    if (isTextChanged)
                    {
                        e.Cancel = true;
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
        private void пускToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = richTextBoxCompil.Text;

            //Лексический анализатор
            dataGridViewLexer.Rows.Clear();
            dataGridViewLexer.Columns.Clear();

            dataGridViewLexer.Columns.Add("Code", "Код");
            dataGridViewLexer.Columns.Add("Type", "Тип");
            dataGridViewLexer.Columns.Add("Lexeme", "Лексема");
            dataGridViewLexer.Columns.Add("Position", "Позиция");

            Scanner scanner = new Scanner();
            List<Token> tokens = scanner.Analyze(text);

            foreach (Token token in tokens)
            {
                string codeText;

                if (token.Code == -1)
                {
                    codeText = "ERROR";
                }
                else
                {
                    codeText = token.Code.ToString();
                }

                string position = "строка " + token.Line + ": " + token.Start + "-" + token.End;

                int rowIndex = dataGridViewLexer.Rows.Add(
                    codeText,
                    token.Type,
                    token.Lexeme,
                    position
                );

                dataGridViewLexer.Rows[rowIndex].Tag = token;
            }
            //Синтаксический анализатор
            dataGridViewParser.Rows.Clear();
            dataGridViewParser.Columns.Clear();

            // Добавляем колонки для ошибок
            dataGridViewParser.Columns.Add("InvalidFragment", "Неверный фрагмент");
            dataGridViewParser.Columns.Add("Location", "Местоположение");
            dataGridViewParser.Columns.Add("Description", "Описание ошибки");

            // Запускаем парсер
            SyntaxParser parser = new SyntaxParser();
            List<ParseError> errors = parser.Parse(tokens);

            if (errors.Count == 0)
            {
                // Выводим сообщение об успешном анализе
                dataGridViewParser.Rows.Add("—", "—", "Синтаксических ошибок не обнаружено.");
                dataGridViewParser.Columns[0].Width = 80;
                dataGridViewParser.Columns[1].Width = 110;
                dataGridViewParser.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                // Заполняем таблицу ошибок
                foreach (ParseError error in errors)
                {
                    string location = $"строка {error.Line}, позиция {error.Column}";
                    int rowIndex = dataGridViewParser.Rows.Add(error.InvalidFragment, location, error.Description);
                    dataGridViewParser.Rows[rowIndex].Tag = error;
                }

                // Обновляем заголовок вкладки парсера с количеством ошибок
                if (tabControl1.TabPages.ContainsKey("Parser"))
                {
                    tabControl1.TabPages["Parser"].Text = $"Парсер (ошибок: {errors.Count})";
                }
            }
        }
        //ЛЕКСЕР
        public class Token
        {
            public int Code { get; set; }
            public string Type { get; set; }
            public string Lexeme { get; set; }
            public int Line { get; set; }
            public int Start { get; set; }
            public int End { get; set; }
        }
        public class Scanner
        {
            public List<Token> Analyze(string text)
            {
                List<Token> tokens = new List<Token>();

                int i = 0;
                int line = 1;
                int column = 1;

                while (i < text.Length)
                {
                    char c = text[i];

                    // пробел
                    if (c == ' ')
                    {
                        tokens.Add(new Token
                        {
                            Code = 2,
                            Type = "Пробел",
                            Lexeme = " ",
                            Line = line,
                            Start = column,
                            End = column
                        });

                        i++;
                        column++;
                        continue;
                    }

                    // Перенос строки
                    if (c == '\n')
                    {
                        line++;
                        column = 1;
                        i++;
                        continue;
                    }

                    //идентификатор
                    if (char.IsLetter(c))
                    {
                        int start = column;
                        string lexeme = "";
                        bool hasError = false;

                        while (i < text.Length)
                        {
                            char current = text[i];
                            // стоп-символы
                            if (current == ' ' || current == '\n' ||
                                current == '=' || current == '{' || current == '}' ||
                                current == ':' || current == ',' || current == ';')
                            {
                                break;
                            }

                            // допустимые символы
                            if (char.IsLetterOrDigit(current))
                            {
                                lexeme += current;
                            }
                            else
                            {
                                // любой другой символ - ошибка
                                hasError = true;
                                lexeme += current;
                            }

                            i++;
                            column++;
                        }

                        if (hasError)
                        {
                            tokens.Add(new Token
                            {
                                Code = -1,
                                Type = "Недопустимый идентификатор",
                                Lexeme = lexeme,
                                Line = line,
                                Start = start,
                                End = column - 1
                            });
                        }
                        else
                        {
                            tokens.Add(new Token
                            {
                                Code = 1,
                                Type = "Идентификатор",
                                Lexeme = lexeme,
                                Line = line,
                                Start = start,
                                End = column - 1
                            });
                        }

                        continue;
                    }

                    // число
                    if (char.IsDigit(c))
                    {
                        int start = column;
                        string lexeme = "";
                        bool isFloat = false;

                        while (i < text.Length)
                        {
                            if (char.IsDigit(text[i]))
                            {
                                lexeme += text[i];
                                i++;
                                column++;
                            }
                            else if (text[i] == '.')
                            {
                                if (isFloat)
                                {
                                    break;
                                }

                                isFloat = true;
                                lexeme += text[i];
                                i++;
                                column++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        int numberCode;
                        string type;

                        if (isFloat)
                        {
                            numberCode = 6;
                            type = "Вещественное число";
                        }
                        else
                        {
                            numberCode = 5;
                            type = "Целое число";
                        }

                        tokens.Add(new Token
                        {
                            Code = numberCode,
                            Type = type,
                            Lexeme = lexeme,
                            Line = line,
                            Start = start,
                            End = column - 1
                        });

                        continue;
                    }

                    // строка
                    if (c == '\'' || c == '\"')
                    {
                        int start = column;
                        char quote = c;
                        string lexeme = "";

                        lexeme += c;
                        i++;
                        column++;

                        while (i < text.Length && text[i] != quote)
                        {
                            if (text[i] == '\n')
                            {
                                break;
                            }

                            lexeme += text[i];
                            i++;
                            column++;
                        }

                        if (i >= text.Length || text[i] != quote)
                        {
                            tokens.Add(new Token
                            {
                                Code = -1,
                                Type = "Незакрытая строка",
                                Lexeme = lexeme,
                                Line = line,
                                Start = start,
                                End = column - 1
                            });

                            continue;
                        }

                        lexeme += text[i];
                        i++;
                        column++;

                        int stringCode;

                        if (quote == '\'')
                        {
                            stringCode = 7;
                        }
                        else
                        {
                            stringCode = 8;
                        }

                        tokens.Add(new Token
                        {
                            Code = stringCode,
                            Type = "Строка",
                            Lexeme = lexeme,
                            Line = line,
                            Start = start,
                            End = column - 1
                        });

                        continue;
                    }

                    // операторы и разделители
                    int code = -1;
                    string typeOp = "";

                    if (c == '=')
                    {
                        code = 3;
                        typeOp = "Оператор присваивания";
                    }
                    else if (c == '{')
                    {
                        code = 4;
                        typeOp = "Открывающая скобка";
                    }
                    else if (c == '}')
                    {
                        code = 11;
                        typeOp = "Закрывающая скобка";
                    }
                    else if (c == ':')
                    {
                        code = 9;
                        typeOp = "Двоеточие";
                    }
                    else if (c == ',')
                    {
                        code = 10;
                        typeOp = "Запятая";
                    }
                    else if (c == ';')
                    {
                        code = 12;
                        typeOp = "Конец оператора";
                    }

                    if (code != -1)
                    {
                        tokens.Add(new Token
                        {
                            Code = code,
                            Type = typeOp,
                            Lexeme = c.ToString(),
                            Line = line,
                            Start = column,
                            End = column
                        });

                        i++;
                        column++;
                        continue;
                    }

                    // ошибка
                    int errorStart = column;
                    string errorLexeme = "";

                    while (i < text.Length)
                    {
                        char current = text[i];

                        if (char.IsLetter(current) ||
                            char.IsDigit(current) ||
                            current == ' ' ||
                            current == '\n' ||
                            current == '\'' ||
                            current == '\"' ||
                            current == '=' ||
                            current == '{' ||
                            current == '}' ||
                            current == ':' ||
                            current == ',' ||
                            current == ';')
                        {
                            break;
                        }

                        errorLexeme += current;
                        i++;
                        column++;
                    }

                    tokens.Add(new Token
                    {
                        Code = -1,
                        Type = "Недопустимая последовательность",
                        Lexeme = errorLexeme,
                        Line = line,
                        Start = errorStart,
                        End = column - 1
                    });
                }

                return tokens;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridViewLexer.Rows[e.RowIndex];

            Token token = row.Tag as Token;

            if (token == null) return;

            // переход к символу
            int charIndex = richTextBoxCompil.GetFirstCharIndexFromLine(token.Line - 1) + token.Start - 1;

            if (charIndex >= 0)
            {
                richTextBoxCompil.Focus();
                richTextBoxCompil.SelectionStart = charIndex;
                richTextBoxCompil.SelectionLength = token.End - token.Start + 1;
                richTextBoxCompil.ScrollToCaret();
            }
        }
        //ПАРСЕР
        public class ParseError
        {
            public string InvalidFragment { get; set; }
            public int Line { get; set; }
            public int Column { get; set; }
            public string Description { get; set; }
        }

        public class SyntaxParser
        {
            private List<Token> tokens;
            private int pos;
            private List<ParseError> errors;

            public List<ParseError> Parse(List<Token> tokenList)
            {
                tokens = tokenList;
                pos = 0;
                errors = new List<ParseError>();

                SkipSpaces();

                bool success = ParseProgram();

                if (pos < tokens.Count && success)
                {
                    Token leftover = tokens[pos];
                    AddError(leftover, "Лишние символы после завершения программы");
                }

                return errors;
            }

            // Пропуск пробелов (код 2)
            private void SkipSpaces()
            {
                while (pos < tokens.Count && tokens[pos].Code == 2)
                    pos++;
            }

            // Добавление записи об ошибке
            private void AddError(Token token, string description)
            {
                errors.Add(new ParseError
                {
                    InvalidFragment = token.Lexeme,
                    Line = token.Line,
                    Column = token.Start,
                    Description = description
                });
            }

            // Проверка текущего токена на соответствие ожидаемому коду
            private bool Check(int expectedCode)
            {
                SkipSpaces();
                if (pos >= tokens.Count) return false;
                return tokens[pos].Code == expectedCode;
            }

            // Получение текущего токена 
            private Token CurrentToken()
            {
                SkipSpaces();
                if (pos < tokens.Count)
                {
                    return tokens[pos];
                }
                return null;
            }

            // Переход к следующему токену 
            private void Advance()
            {
                if (pos < tokens.Count)
                    pos++;
                SkipSpaces();
            }

            // Синхронизация: пропуск токенов до встречи одного из заданных кодов
            private void Synchronize(HashSet<int> syncCodes)
            {
                while (pos < tokens.Count)
                {
                    if (syncCodes.Contains(tokens[pos].Code))
                        break;
                    pos++;
                }
                SkipSpaces();
            }

            // <START> -> <DICTIONARY> ';' { <DICTIONARY> ';' }
            private bool ParseProgram()
            {
                bool anySuccess = false;
                while (pos < tokens.Count)
                {
                    SkipSpaces();
                    if (pos >= tokens.Count) break;

                    bool assignmentOk = ParseAssignment();

                    if (assignmentOk)
                    {
                        // Ожидаем точку с запятой после объявления
                        if (!Check(12))
                        {
                            Token t = CurrentToken();
                            if (t == null) t = tokens[tokens.Count - 1];
                            AddError(t, "Ожидалась точка с запятой ';'");
                            Synchronize(new HashSet<int> { 1 });
                            continue;
                        }
                        Advance();
                        anySuccess = true;
                    }
                    else
                    {
                        Synchronize(new HashSet<int> { 1 });
                    }
                }
                return anySuccess;
            }

            // <DICTIONARY> -> <IDENTIFIER> '=' <DICT>
            private bool ParseAssignment()
            {
                // Идентификатор
                if (!Check(1))
                {
                    Token t = CurrentToken();
                    if (t == null) t = tokens[tokens.Count - 1];
                    AddError(t, "Ожидался идентификатор (имя переменной)");
                    return false;
                }
                Advance();

                // '='
                if (!Check(3))
                {
                    Token t = CurrentToken();
                    if (t == null) t = tokens[tokens.Count - 1];
                    AddError(t, "Ожидался знак равенства '='");
                    return false;
                }
                Advance();

                // Словарь
                if (!ParseDict())
                    return false;

                return true;
            }

            // <DICT> -> '{' <PAIRS> '}' | '{' '}'
            private bool ParseDict()
            {
                if (!Check(4))
                {
                    Token t = CurrentToken();
                    if (t == null) t = tokens[tokens.Count - 1];
                    AddError(t, "Ожидалась открывающая фигурная скобка '{'");
                    return false;
                }
                Advance();

                // Пустой словарь
                if (Check(11))
                {
                    Advance();
                    return true;
                }
                bool pairListOk = ParsePairList();

                // Ожидаем '}'
                if (!Check(11))
                {
                    Token t = CurrentToken();
                    if (t == null) t = tokens[tokens.Count - 1];
                    AddError(t, "Ожидалась закрывающая фигурная скобка '}'");
                    return false;
                }
                Advance();

                return pairListOk;
            }

            // <PAIRS> -> <PAIR> <PAIRS_TAIL>
            // <PAIRS_TAIL> -> ',' <PAIR> <PAIRS_TAIL> | ε
            private bool ParsePairList()
            {
                while (true)
                {
                    int savedPos = pos;
                    bool pairOk = ParsePair();

                    if (!pairOk)
                    {
                        if (pos == savedPos && pos < tokens.Count)
                        {
                            Token t = CurrentToken();
                            if (t != null)
                            {
                                AddError(t, "Неверный фрагмент, пропущено");
                                Advance();
                            }
                        }
                        continue;
                    }

                    if (Check(10)) // запятая
                    {
                        Advance();
                        if (Check(11))
                        {
                            AddError(CurrentToken(), "Лишняя запятая перед закрывающей скобкой");
                            break;
                        }
                    }
                    else if (Check(11)) // закрывающая скобка
                    {
                        break;
                    }
                    else
                    {
                        Token t = CurrentToken();
                        if (t == null) t = tokens[tokens.Count - 1];
                        AddError(t, "Ожидалась запятая или закрывающая скобка");

                        // Пропускаем до ближайшей запятой или '}'
                        Synchronize(new HashSet<int> { 10, 11 });
                        if (Check(10))
                        {
                            Advance(); // переходим за запятой
                            continue;
                        }
                        else if (Check(11))
                        {
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                return true;
            }

            // <PAIR> -> <KEY> ':' <VALUE>
            private bool ParsePair()
            {
                // Ключ (целое, вещественное или строка)
                if (!Check(5) && !Check(6) && !Check(7) && !Check(8))
                {
                    Token t = CurrentToken();
                    if (t == null) t = tokens[tokens.Count - 1];
                    AddError(t, "Ожидалось целое число, вещественное число или строка в качестве ключа");
                    return false;
                }
                Advance();

                // ':'
                if (!Check(9))
                {
                    Token t = CurrentToken();
                    if (t == null) t = tokens[tokens.Count - 1];
                    AddError(t, "Ожидалось двоеточие ':' после ключа");
                    return false;
                }
                Advance();

                // Значение (целое, вещественное или строка)
                if (!Check(5) && !Check(6) && !Check(7) && !Check(8))
                {
                    Token t = CurrentToken();
                    if (t == null) t = tokens[tokens.Count - 1];
                    AddError(t, "Ожидалось значение (целое, вещественное или строка)");
                    return false;
                }
                Advance();

                return true;
            }
        }
        private void dataGridViewParser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridViewParser.Rows[e.RowIndex];
            if (row.Tag is ParseError error)
            {
                // Переход к позиции ошибки
                int line = error.Line;
                int column = error.Column;
                int charIndex = richTextBoxCompil.GetFirstCharIndexFromLine(line - 1) + column - 1;
                if (charIndex >= 0)
                {
                    richTextBoxCompil.Focus();
                    richTextBoxCompil.SelectionStart = charIndex;
                    richTextBoxCompil.SelectionLength = error.InvalidFragment.Length;
                    richTextBoxCompil.ScrollToCaret();
                }
            }
        }
    }
}
