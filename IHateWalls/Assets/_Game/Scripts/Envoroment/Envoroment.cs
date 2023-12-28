using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enviroments
{
    public class Enviroment : MonoBehaviour
    {
        [SerializeField] private Material _skyBox;

        private void Awake()
        {
            RenderSettings.skybox = _skyBox;
        }
    }
}