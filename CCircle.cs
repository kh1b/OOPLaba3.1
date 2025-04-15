using System;
using System.Drawing;

namespace OOPLaba3._1
{
    public class CCircle
    {
        private int x, y; // Координаты центра
        private int radius = 30; // Постоянный радиус
        private bool isSelected; // Состояние выделения

        public CCircle(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.isSelected = false;
        }

        // Метод для проверки, находится ли точка внутри круга
        public bool ContainsPoint(int px, int py)
        {
            return (px - x) * (px - x) + (py - y) * (py - y) <= radius * radius;
        }

        // Метод для отрисовки круга
        public void Draw(Graphics g)
        {
            Brush brush = isSelected ? Brushes.Red : Brushes.Blue; // Красный, если выделен, иначе синий
            g.FillEllipse(brush, x - radius, y - radius, 2 * radius, 2 * radius);
        }

        // Метод для изменения состояния выделения
        public void SetSelected(bool selected)
        {
            isSelected = selected;
        }

        // Геттер для состояния выделения
        public bool IsSelected()
        {
            return isSelected;
        }
    }
}