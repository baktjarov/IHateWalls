using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Walls
{
    public class WallHolder : MonoBehaviour
    {
        public float destructPercentage { get; private set; } = 0;

        [SerializeField] public List<WallPiece> wallPieces = new List<WallPiece>();

        private void Awake()
        {
            wallPieces = GetComponentsInChildren<WallPiece>().ToList();
        }

        private void Update()
        {
            destructPercentage = 0;

            foreach (WallPiece piece in wallPieces)
            {
                if (piece.isRealeased == true)
                {
                    destructPercentage++;
                }
            }
        }
    }
}

