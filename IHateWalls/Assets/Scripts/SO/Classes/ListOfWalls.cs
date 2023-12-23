using Interfaces;
using System.Collections.Generic;
using UnityEngine;
using Walls;

namespace SO
{
    [CreateAssetMenu(fileName = nameof(ListOfWalls),
                     menuName = "Scriptables/" + nameof(ListOfWalls))]

    public class ListOfWalls : ScriptableObject, IService
    {
        public int currentWallIndex
        {
            get
            {
                if (_currentWallIndex >= _walls.Count)
                {
                    _currentWallIndex = 0;
                }

                if (_currentWallIndex < 0)
                {
                    _currentWallIndex = 0;
                }

                return _currentWallIndex;
            }
        }

        [SerializeField] private int _currentWallIndex = 0;

        [SerializeField] private List<WallHolder> _walls = new List<WallHolder>();

        public WallHolder GetWall()
        {
            return _walls[currentWallIndex];
        }

        public void SetNextWall()
        {
            _currentWallIndex++;

            if (_currentWallIndex >= _walls.Count)
            {
                _currentWallIndex = 0;
            }
        }
    }
}

