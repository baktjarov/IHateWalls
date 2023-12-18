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
        public int currentWallIndex => _currentWallIndex;

        [SerializeField] private int _currentWallIndex = 0;

        [SerializeField] private List<WallHolder> _walls = new List<WallHolder>();

        public WallHolder GetWall()
        {
            return _walls[_currentWallIndex];
        }
    }
}

