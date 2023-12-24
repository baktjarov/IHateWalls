using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Walls
{
    public class WallHolder : MonoBehaviour
    {
        // Прогресс разрушения стены
        public int destructProgress { get; private set; } = 0;

        // Список кусков стены
        [SerializeField] public List<WallPiece> wallPieces = new List<WallPiece>();

        // Вызывается при создании объекта
        private void Awake()
        {
            // Получение всех компонентов WallPiece в дочерних объектах и добавление их в список
            wallPieces = GetComponentsInChildren<WallPiece>().ToList();
        }

        // Вызывается каждый кадр
        private void Update()
        {
            // Сброс прогресса разрушения
            destructProgress = 0;

            // Перебор всех кусков стены
            foreach (WallPiece piece in wallPieces)
            {
                // Если кусок стены разрушен
                if (piece.isRealeased == true)
                {
                    // Увеличение прогресса разрушения
                    destructProgress++;
                }
            }
        }
    }
}

