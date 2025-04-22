using System.Collections.Generic;

namespace OOPLaba3._1
{
    public class CircleStorage
    {
        // Поле для хранения коллекции кругов
        private List<CCircle> circles = new List<CCircle>();

        // Добавление нового круга
        public void AddCircle(CCircle circle)
        {
            circles.Add(circle);
        }

        // Удаление всех выделенных кругов
        public void RemoveSelectedCircles()
        {
            circles.RemoveAll(circle => circle.IsSelected());
        }

        // Получение всех кругов
        public List<CCircle> GetCircles()
        {
            return circles;
        }

        // Очистка контейнера
        public void Clear()
        {
            circles.Clear();
        }
    }
}