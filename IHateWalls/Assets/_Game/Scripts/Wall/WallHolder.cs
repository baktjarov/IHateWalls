using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Walls
{
    public class WallHolder : MonoBehaviour
    {
        [field: SerializeField] public int destructProgress { get; private set; } = 0;

        [field: SerializeField] public List<WallPiece> wallPieces = new List<WallPiece>();

        private void Awake()
        {
            wallPieces = GetComponentsInChildren<WallPiece>().ToList();
        }

        private void Update()
        {
            destructProgress = 0;

            foreach (WallPiece piece in wallPieces)
            {
                if (piece.isRealeased == true)
                {
                    destructProgress++;
                }
            }
        }
    }
}