using UnityEngine;
using Interfaces;

namespace SO
{
    // Атрибут CreateAssetMenu указывает на то, как будет создаваться данный объект в редакторе Unity
    [CreateAssetMenu(fileName = nameof(GameSettings),
                     menuName = "Scriptables/" + nameof(GameSettings))]
    public class GameSettings : ScriptableObject, IService
    {
        // Публичное свойство winPercentage, сериализованное для отображения в инспекторе Unity и доступа извне
        [field: SerializeField] public float winPercentage { get; private set; } = 80;
    }
}