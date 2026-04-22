﻿using System;
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
using System.Text.RegularExpressions;
using System.Text.RegularExpressions;
using System.Drawing;

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
            dataGridViewRegular.CellClick += dataGridViewRegular_CellClick;
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

            dataGridViewParser.Columns.Add("InvalidFragment", "Неверный фрагмент");
            dataGridViewParser.Columns.Add("Location", "Местоположение");
            dataGridViewParser.Columns.Add("Description", "Описание ошибки");

            // Запускаем парсер
            TokenValidator validator = new TokenValidator();
            List<ParseError> errors = new List<ParseError>();

            errors.AddRange(validator.Validate(tokens));

            SyntaxParser parser = new SyntaxParser();
            errors.AddRange(parser.Parse(tokens));

            errors = errors
                .GroupBy(e => new { e.Line, e.Column, e.Description })
                .Select(g => g.First())
                .ToList();

            if (tabControl1.TabPages.ContainsKey("Parser"))
            {
                tabControl1.TabPages["Parser"].Text = $"Парсер (ошибок: {errors.Count})";
            }

            if (errors.Count == 0)
            {
                dataGridViewParser.Rows.Add("—", "—", "Синтаксических ошибок не обнаружено.");
                dataGridViewParser.Columns[0].Width = 80;
                dataGridViewParser.Columns[1].Width = 110;
                dataGridViewParser.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                foreach (ParseError error in errors)
                {
                    string location = $"строка {error.Line}, позиция {error.Column}";
                    int rowIndex = dataGridViewParser.Rows.Add(error.InvalidFragment, location, error.Description);
                    dataGridViewParser.Rows[rowIndex].Tag = error;
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
            private static bool IsSyntaxDelimiter(char c)
            {
                return c == ':' || c == ',' || c == '}' || c == '{' || c == ';' || c == '=';
            }

            private static bool HasClosingQuoteBeforeLineEnd(string text, int startIndex, char quote)
            {
                for (int j = startIndex; j < text.Length; j++)
                {
                    if (text[j] == '\n')
                        return false;

                    if (text[j] == quote)
                        return true;
                }

                return false;
            }

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

                    // идентификатор (если встречен недопустимый символ внутри,
                    // вся последовательность до разделителя считается невалидным идентификатором)
                    if (char.IsLetter(c))
                    {
                        int start = column;
                        string lexeme = "";
                        bool hasInvalidChar = false;

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

                            lexeme += current;

                            // допустимые символы
                            if (!char.IsLetterOrDigit(current))
                                hasInvalidChar = true;

                            i++;
                            column++;
                        }
                        if (hasInvalidChar)
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
                        int dotCount = 0;

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
                                dotCount++;
                                lexeme += text[i];
                                i++;
                                column++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        // Валидны:
                        // - целое: 123
                        // - вещественное: 1.23
                        // Невалидны: 1.2.3, 1., 12..34
                        bool isInvalidNumber = dotCount > 1 || (dotCount == 1 && lexeme.EndsWith("."));

                        if (isInvalidNumber)
                        {
                            tokens.Add(new Token
                            {
                                Code = -1,
                                Type = "Недопустимое число",
                                Lexeme = lexeme,
                                Line = line,
                                Start = start,
                                End = column - 1
                            });
                        }
                        else if (dotCount == 1)
                        {
                            tokens.Add(new Token
                            {
                                Code = 6,
                                Type = "Вещественное число",
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
                                Code = 5,
                                Type = "Целое число",
                                Lexeme = lexeme,
                                Line = line,
                                Start = start,
                                End = column - 1
                            });
                        }

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

                            // Восстановление после незакрытой строки:
                            // если дальше в этой строке нет закрывающей кавычки,
                            // оставляем разделитель (':', ',', '}' и т.п.) для парсера.
                            if (IsSyntaxDelimiter(text[i]) &&
                                !HasClosingQuoteBeforeLineEnd(text, i, quote))
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
        public class TokenValidator
        {
            public List<ParseError> Validate(List<Token> tokens)
            {
                List<ParseError> errors = new List<ParseError>();

                List<Token> significantTokens = new List<Token>();

                foreach (Token token in tokens)
                {
                    if (token.Code != 2)
                        significantTokens.Add(token);
                }

                for (int i = 0; i < significantTokens.Count - 1; i++)
                {
                    var current = significantTokens[i];
                    var next = significantTokens[i + 1];

                    // Повторяющиеся символы
                    if (current.Code == next.Code && IsRepeatableSymbol(current.Code))
                    {
                        if (current.Code == 10) // ,
                            AddError(errors, next, "Повторяющаяся запятая");

                        if (current.Code == 12) // ;
                            AddError(errors, next, "Повторяющаяся ';'");

                        if (current.Code == 3) // =
                            AddError(errors, next, "Повторяющийся '='");

                        if (current.Code == 9) // :
                            AddError(errors, next, "Повторяющееся ':'");

                        if (current.Code == 4) // {
                            AddError(errors, next, "Лишняя '{'");

                        if (current.Code == 11) // }
                            AddError(errors, next, "Лишняя '}'");
                    }

                    //  Запрещеные комбинации
                    if (current.Code == 10 && next.Code == 11)
                        AddError(errors, current, "Лишняя запятая перед '}'");

                    if (current.Code == 3 && next.Code == 11) // =}
                        AddError(errors, next, "После '=' ожидалось выражение");

                    if (current.Code == 9 && next.Code == 10) // :,
                        AddError(errors, next, "После ':' нет значения");

                    if (current.Code == 4 && next.Code == 10) // {,
                        AddError(errors, next, "После '{' не может идти ','");
                }

                return errors;
            }

            private bool IsRepeatableSymbol(int code)
            {
                return code == 3 || code == 4 || code == 9 || code == 10 || code == 11 || code == 12;
            }

            private bool IsDictionaryInvalidSymbol(int code)
            {
                return code == 3 || code == 4 || code == 9 || code == 12;
            }

            private void AddError(List<ParseError> errors, Token token, string message)
            {
                errors.Add(new ParseError
                {
                    InvalidFragment = token.Lexeme,
                    Line = token.Line,
                    Column = token.Start,
                    Description = message
                });
            }
        }
        public class SyntaxParser
        {
            private List<Token> tokens;
            private int current = 0;
            private List<ParseError> errors = new List<ParseError>();

            public List<ParseError> Parse(List<Token> tokens)
            {
                this.tokens = tokens;
                current = 0;
                errors.Clear();

                if (tokens == null || tokens.Count == 0)
                {
                    errors.Add(new ParseError
                    {
                        InvalidFragment = "",
                        Line = 1,
                        Column = 1,
                        Description = "Ожидалось объявление словаря"
                    });

                    return errors;
                }

                Start();

                return errors;
            }

            private Token CurrentToken
            {
                get
                {
                    SkipIgnored();
                    if (current < tokens.Count)
                    {
                        return tokens[current];
                    }

                    Token lastToken = tokens.Last();

                    return new Token
                    {
                        Code = 0,
                        Type = "Конец ввода",
                        Lexeme = "",
                        Line = lastToken.Line,
                        Start = lastToken.End + 1,
                        End = lastToken.End + 1
                    };
                }
            }

            private bool IsEnd()
            {
                return CurrentToken.Code == 0;
            }

            private bool IsValueToken(int code)
            {
                return code == 5 || code == 6 || code == 7 || code == 8;
            }

            private bool IsRepeatableSymbol(int code)
            {
                return code == 3 || code == 4 || code == 9 || code == 10 || code == 11 || code == 12;
            }

            private bool IsDictionaryInvalidSymbol(int code)
            {
                return code == 3 || code == 4 || code == 9 || code == 12;
            }

            private bool HasErrorAtCurrentPosition()
            {
                return errors.Any(e => e.Line == CurrentToken.Line && e.Column == CurrentToken.Start);
            }

            private bool Match(int code)
            {
                if (CurrentToken.Code == code)
                {
                    current++;
                    SkipRepeatedSymbols(code);
                    return true;
                }
                return false;
            }

            private void Error(string message)
            {
                errors.Add(new ParseError
                {
                    InvalidFragment = string.IsNullOrEmpty(CurrentToken.Lexeme) ? "конец строки" : CurrentToken.Lexeme,
                    Line = CurrentToken.Line,
                    Column = CurrentToken.Start,
                    Description = message
                });
            }

            // Метод Айронса
            private void Synchronize(bool consume, params int[] followSet)
            {
                while (current < tokens.Count)
                {
                    foreach (int code in followSet)
                    {
                        if (CurrentToken.Code == code)
                        {
                            if (consume) current++;
                            return;
                        }
                    }
                    current++;
                }
            }
            private void SkipIgnored()
            {
                while (current < tokens.Count && tokens[current].Code == 2)
                    current++;
            }

            private void SkipRepeatedSymbols(int code)
            {
                if (!IsRepeatableSymbol(code))
                    return;

                while (true)
                {
                    SkipIgnored();

                    if (current < tokens.Count && tokens[current].Code == code)
                        current++;
                    else
                        break;
                }
            }

            // START → DICTIONARY ';' { DICTIONARY ';' }
            private void Start()
            {
                while (!IsEnd())
                {
                    bool needSemicolon = Dictionary();

                    if (Match(12)) // ;
                    {
                        continue;
                    }

                    if (needSemicolon)
                    {
                        Error("Ожидался символ ';'");

                        if (CurrentToken.Code == 1)
                            continue;
                    }

                    Synchronize(true, 12);

                    if (needSemicolon && IsEnd() && !HasErrorAtCurrentPosition())
                    {
                        Error("Ожидался символ ';'");
                    }
                }
            }

            // DICTIONARY → IDENTIFIER '=' DICT
            private bool Dictionary()
            {
                if (!Match(1))
                {
                    Error("Ожидался идентификатор");

                    if (IsEnd())
                        return false;

                    Synchronize(false, 3, 4, 12);
                }

                if (!Match(3)) // =
                {
                    Error("Ожидался '='");

                    if (IsEnd())
                        return false;

                    Synchronize(false, 4, 12);

                    if (CurrentToken.Code != 4)
                        return false;
                }

                Dict();
                return true;
            }

            // DICT → '{' PAIRS '}' | '{' '}'
            private void Dict()
            {
                if (!Match(4)) // {
                {
                    if (CurrentToken.Code == 3)
                    {
                        Synchronize(false, 4, 12);

                        if (Match(4))
                        {
                            if (Match(11)) // {}
                                return;

                            Pairs();

                            if (!Match(11)) // }
                            {
                                Error("Ожидалась '}'");
                                Synchronize(false, 12);
                            }
                        }

                        return;
                    }

                    Error("Ожидалась '{'");
                    Synchronize(false, 11, 12);

                    if (CurrentToken.Code == 11) current++; // }
                    return;
                }

                if (Match(11)) // {}
                    return;

                bool needClosingBrace = Pairs();

                if (needClosingBrace && !Match(11)) // }
                {
                    Error("Ожидалась '}'");
                    Synchronize(false, 12);
                }

                if (!needClosingBrace && IsEnd() && !HasErrorAtCurrentPosition())
                    Error("Ожидалась '}'");
            }

            // PAIRS → PAIR { , PAIR }
            private bool Pairs()
            {
                while (CurrentToken.Code == 10)
                {
                    current++;
                }

                if (CurrentToken.Code == 11)
                    return true;

                if (CurrentToken.Code == 12)
                {
                    Error("Ожидалась ',' или '}'");
                    Synchronize(false, 10, 11);

                    if (CurrentToken.Code == 10)
                    {
                        Match(10);
                    }

                    if (CurrentToken.Code == 11)
                        return true;

                    if (IsEnd())
                        return false;
                }

                if (IsEnd())
                    return false;

                Pair();

                while (true)
                {
                    if (CurrentToken.Code == 11) // }
                        return true;

                    if (CurrentToken.Code == 12)
                    {
                        Error("Ожидалась ',' или '}'");
                        Synchronize(false, 10, 11);

                        if (CurrentToken.Code == 10)
                        {
                            Match(10);
                            Pair();
                            continue;
                        }

                        if (CurrentToken.Code == 11)
                            return true;

                        if (IsEnd())
                            return false;
                    }

                    if (IsEnd())
                        return false;

                    if (Match(10)) // ,
                    {
                        while (CurrentToken.Code == 10)
                        {
                            current++;
                        }

                        if (CurrentToken.Code == 11) // }
                            return true;

                        if (CurrentToken.Code == 12 || IsEnd())
                            return false;

                        Pair();
                        continue;
                    }

                    if (IsDictionaryInvalidSymbol(CurrentToken.Code))
                    {
                        Error("Недопустимый символ внутри словаря");
                        Synchronize(false, 11, 12);

                        if (CurrentToken.Code == 11)
                            return true;

                        return false;
                    }

                    Error("Ожидалась ',' или '}'");
                    Synchronize(false, 11);

                    if (CurrentToken.Code == 11)
                        return true;

                    return false;
                }
            }

            // PAIR → KEY ':' VALUE
            private void Pair()
            {
                if (CurrentToken.Code == 11) // }
                    return;

                Key();

                if (CurrentToken.Code == 11)
                    return;

                if (!Match(9)) // :
                {
                    Error("Ожидалось ':'");
                    Synchronize(false, 10, 11);
                    return;
                }

                Value();
            }

            private void Key()
            {
                if (CurrentToken.Code == 11) return;

                if (CurrentToken.Code == -1)
                {
                    if (CurrentToken.Lexeme == ".")
                        Error("Ожидалась цифра перед десятичной точкой");
                    else if (CurrentToken.Type == "Недопустимое число")
                        Error("Недопустимый ключ словаря");
                    else if (CurrentToken.Type == "Незакрытая строка" || CurrentToken.Type == "Недопустимый идентификатор")
                        Error("Недопустимый ключ словаря");
                    else
                        Error("Недопустимый символ внутри словаря");

                    Synchronize(false, 9, 10, 11);
                    return;
                }

                if (!IsValueToken(CurrentToken.Code))
                {
                    Error("Ожидался ключ (число или строка)");
                    Synchronize(false, 9, 10, 11);
                    return;
                }

                current++;
            }

            private void Value()
            {
                if (CurrentToken.Code == -1)
                {
                    if (CurrentToken.Lexeme == ".")
                        Error("Ожидалась цифра перед десятичной точкой");
                    else if (CurrentToken.Type == "Недопустимое число")
                        Error("Недопустимое значение словаря");
                    else
                        Error("Недопустимое значение словаря");

                    Synchronize(false, 10, 11, 12);
                    return;
                }

                if (!IsValueToken(CurrentToken.Code))
                {
                    Error("Ожидалось значение (число или строка)");
                    Synchronize(false, 10, 11, 12);
                    return;
                }

                current++;
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
                    richTextBoxCompil.SelectionLength = Math.Max(1, error.InvalidFragment.Length);
                    richTextBoxCompil.ScrollToCaret();
                }
            }
        }
        //РЕГУЛЯРНЫЕ ВЫРАЖЕНИЯ
        private class MatchInfo
        {
            public int StartIndex { get; set; }
            public int Length { get; set; }
        }
        private string GetRegexPattern(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0: //комплексные числа
                    return @"[A-Za-z]\d[A-Za-z] ?\d[A-Za-z]\d";
                case 1: // Maestro Card
                    return @"(50|5[6-9]|6[0-9])[0-9]{16,19}";
                case 2: // Комплексные числа
                    return @"-?\d+(?:\.\d+)?\s*[+-]\s*\d+(?:\.\d+)?[ij]|\d+(?:\.\d+)?[ij]";
                default:
                    return null;
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataGridViewRegular.Rows.Clear();
            dataGridViewRegular.Columns.Clear();
            dataGridViewRegular.Columns.Add("Match", "Найденная подстрока");
            dataGridViewRegular.Columns.Add("Position", "Начальная позиция");
            dataGridViewRegular.Columns.Add("Length", "Длина");

            string text = richTextBoxCompil.Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Нет данных для поиска.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (comboBoxRegular.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип поиска из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string pattern = GetRegexPattern(comboBoxRegular.SelectedIndex);
            if (pattern == null)
            {
                MessageBox.Show("Не удалось получить шаблон поиска.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RegexOptions options = RegexOptions.None;
            if (comboBoxRegular.SelectedIndex == 0 || comboBoxRegular.SelectedIndex == 2)
            {
                options = RegexOptions.IgnoreCase;
            }

            string overlappingPattern = $"(?=({pattern}))";
            Regex regex = new Regex(overlappingPattern, options);
            MatchCollection matches = regex.Matches(text);

            if (matches.Count == 0)
            {
                MessageBox.Show("Совпадений не найдено.", "Результат поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int foundCount = 0;
            foreach (Match match in matches)
            {
                if (match.Groups[1].Success)
                {
                    string matchedText = match.Groups[1].Value;
                    int startIndex = match.Groups[1].Index;
                    int length = matchedText.Length;

                    int line = richTextBoxCompil.GetLineFromCharIndex(startIndex);
                    int firstCharOfLine = richTextBoxCompil.GetFirstCharIndexFromLine(line);
                    int column = startIndex - firstCharOfLine + 1;
                    string position = $"строка {line + 1}, символ {column}";

                    int rowIndex = dataGridViewRegular.Rows.Add(matchedText, position, length);
                    dataGridViewRegular.Rows[rowIndex].Tag = new MatchInfo { StartIndex = startIndex, Length = length };
                    foundCount++;
                }
            }

            MessageBox.Show($"Найдено совпадений: {foundCount}", "Результат поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
            richTextBoxCompil.SelectionLength = 0;
        }
        private void dataGridViewRegular_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridViewRegular.Rows[e.RowIndex];
            MatchInfo info = row.Tag as MatchInfo;
            if (info != null)
            {
                richTextBoxCompil.SelectionStart = info.StartIndex;
                richTextBoxCompil.SelectionLength = info.Length;
                richTextBoxCompil.Focus();
                richTextBoxCompil.ScrollToCaret();
            }
        }
    }
}
