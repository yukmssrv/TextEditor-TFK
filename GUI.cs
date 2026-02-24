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

namespace LAB1_TFK
{
    public partial class GUI : Form
    {
        private string currentFilePath = null;
        private bool isTextChanged = false;
        public GUI()
        {
            InitializeComponent();
            splitContainer1.Visible = false;
            richTextBoxCompil.TextChanged += richTextBoxCompil_TextChanged;

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

            splitContainer1.Visible = true;
            richTextBoxCompil.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

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

                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
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
            //пускToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonQuestion_Click(object sender, EventArgs e)
        {
            справкаToolStripMenuItem2_Click(sender, e);
        }

        private void toolStripButtonInformation_Click(object sender, EventArgs e)
        {
            оПрограммеToolStripMenuItem_Click(sender, e);
        }
    }
}
