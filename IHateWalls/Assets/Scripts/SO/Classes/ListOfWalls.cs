using Interfaces;
using System.Collections.Generic;
using UnityEngine;
using Walls;

namespace SO
{
    // Атрибут CreateAssetMenu указывает на то, как будет создаваться данный объект в редакторе Unity
    [CreateAssetMenu(fileName = nameof(ListOfWalls),
                     menuName = "Scriptables/" + nameof(ListOfWalls))]

    public class ListOfWalls : ScriptableObject, IService
    {
        // Свойство, возвращающее текущий индекс стены
        public int currentWallIndex
        {
            get
            {
                // Проверка, чтобы индекс не выходил за пределы списка стен
                if (_currentWallIndex >= _walls.Count)
                {
                    _currentWallIndex = 0;
                }

                if (_currentWallIndex < 0)
                {
                    _currentWallIndex = 0;
                }

                // Возвращает текущий индекс стены
                return _currentWallIndex;
            }
        }

        // Текущий индекс стены
        [SerializeField] private int _currentWallIndex = 0;

        // Список стен
        [SerializeField] private List<WallHolder> _walls = new List<WallHolder>();

        // Метод для получения стены по текущему индексу
        public WallHolder GetWall()
        {
            // Возвращает стену по текущему индексу
            return _walls[currentWallIndex];
        }

        // Метод для установки следующей стены
        public void SetNextWall()
        {
            // Увеличение текущего индекса
            _currentWallIndex++;

            // Если текущий индекс выходит за пределы списка
            if (_currentWallIndex >= _walls.Count)
            {
                // Устанавливаем индекс в начало списка
                _currentWallIndex = 0;
            }
        }
    }
}

