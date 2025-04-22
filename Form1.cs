using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOPLaba3._1
{
    public partial class Form1 : Form
    {
        private CircleStorage storage = new CircleStorage(); // ��������� ��� �������� ������
        private bool isCtrlPressed = false; // ���� ��� ������������ ������� Ctrl

        public Form1()
        {
            InitializeComponent();

            // ��������� �����
            this.Text = "����� �� �����";
            this.Size = new Size(800, 600);

            // ��������� ������� ����
            this.MouseDown += MainForm_MouseDown;
            this.Paint += MainForm_Paint;

            // ��������� ������
            this.KeyDown += MainForm_KeyDown;
            this.KeyUp += MainForm_KeyUp;

        }

        // ��������� ������� ����
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
                            // ���� Ctrl �� �����, ������� ������� ��������� �� ���� ������
                            foreach (var c in storage.GetCircles())
                                c.SetSelected(false);
                        }

                        // �������� ������� ����
                        circle.SetSelected(!circle.IsSelected());
                        anySelected = true;
                    }
                }

                if (!anySelected)
                {
                    if (isCtrlPressed)
                    {
                        // ���� Ctrl �����, ������� ��������� �� ���� ������
                        foreach (var c in storage.GetCircles())
                            c.SetSelected(false);
                    }
                    else
                    {
                        // ���� Ctrl �� �����, ������� ����� ����
                        storage.AddCircle(new CCircle(e.X, e.Y));
                    }
                }

                this.Invalidate(); // �������������� �����
            }
        }

        // ��������� ������� ����������� �����
        private void MainForm_Paint(object? sender, PaintEventArgs e)
        {
            foreach (var circle in storage.GetCircles())
            {
                circle.Draw(e.Graphics);
            }
        }

        // ��������� ������� ������� �������
        private void MainForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) // ���������, ���� �� ������ ������� Delete
            {
                storage.RemoveSelectedCircles(); // ������� ��� ���������� �����
                this.Invalidate(); // �������������� �����
            }

            if (e.Control) // ���������, ������ �� ������� Ctrl
            {
                isCtrlPressed = true;
            }
        }

        // ��������� ������� ���������� �������
        private void MainForm_KeyUp(object? sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                isCtrlPressed = false;
            }
        }
    }
}
