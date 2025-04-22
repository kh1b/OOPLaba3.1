using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOPLaba3._1
{
    public partial class Form1 : Form
    {
        private CircleStorage storage = new CircleStorage(); // Контейнер для хранения кругов
        private bool isCtrlPressed = false; // Флаг для отслеживания нажатия Ctrl

        public Form1()
        {
            InitializeComponent();

            // Настройка формы
            this.Text = "Круги на форме";
            this.Size = new Size(800, 600);

            // Обработка событий мыши
            this.MouseDown += MainForm_MouseDown;
            this.Paint += MainForm_Paint;

            // Обработка клавиш
            this.KeyDown += MainForm_KeyDown;
            this.KeyUp += MainForm_KeyUp;

        }

        // Обработка нажатия мыши
        private void MainForm_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bool anySelected = false;

                foreach (var circle in storage.GetCircles())
                {
                    if (circle.ContainsPoint(e.X, e.Y))
                    {
                        if (!isCtrlPressed)
                        {
                            // Если Ctrl не нажат, сначала снимаем выделение со всех кругов
                            foreach (var c in storage.GetCircles())
                                c.SetSelected(false);
                        }

                        // Выделяем текущий круг
                        circle.SetSelected(!circle.IsSelected());
                        anySelected = true;
                    }
                }

                if (!anySelected)
                {
                    if (isCtrlPressed)
                    {
                        // Если Ctrl нажат, снимаем выделение со всех кругов
                        foreach (var c in storage.GetCircles())
                            c.SetSelected(false);
                    }
                    else
                    {
                        // Если Ctrl не нажат, создаем новый круг
                        storage.AddCircle(new CCircle(e.X, e.Y));
                    }
                }

                this.Invalidate(); // Перерисовываем форму
            }
        }

        // Обработка события перерисовки формы
        private void MainForm_Paint(object? sender, PaintEventArgs e)
        {
            foreach (var circle in storage.GetCircles())
            {
                circle.Draw(e.Graphics);
            }
        }

        // Обработка события нажатия клавиши
        private void MainForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) // Проверяем, была ли нажата клавиша Delete
            {
                storage.RemoveSelectedCircles(); // Удаляем все выделенные круги
                this.Invalidate(); // Перерисовываем форму
            }

            if (e.Control) // Проверяем, нажата ли клавиша Ctrl
            {
                isCtrlPressed = true;
            }
        }

        // Обработка события отпускания клавиши
        private void MainForm_KeyUp(object? sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                isCtrlPressed = false;
            }
        }
    }
}
