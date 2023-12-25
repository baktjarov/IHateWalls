using Interfaces;
using System.Collections.Generic;
using UnityEngine;
using Walls;
using Enviroments;

namespace SO
{
    [CreateAssetMenu(fileName = nameof(ListOfEnviroments),
                    menuName = "Scriptables/" + nameof(ListOfEnviroments))]
    public class ListOfEnviroments : ScriptableObject, IService
    {
        [SerializeField] private List<Enviroment> _enviroments = new List<Enviroment>();

        public Enviroment GetEnviroment()
        {
            if (_enviroments.Count == 0) { return null; }

            return _enviroments[Random.Range(0, _enviroments.Count)];
        }
    }
}