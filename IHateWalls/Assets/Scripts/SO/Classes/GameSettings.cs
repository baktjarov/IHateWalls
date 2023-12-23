using UnityEngine;
using Interfaces;

namespace SO
{
    [CreateAssetMenu(fileName = nameof(GameSettings),
                     menuName = "Scriptables/" + nameof(GameSettings))]

    public class GameSettings : ScriptableObject, IService
    {
        [field: SerializeField] public float winPercentage { get; private set; } = 80;
    }
}