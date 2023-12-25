using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    public class SceneLoader
    {
        public static IEnumerator LoadScene(string sceneName, Action callback)
        {
            var handle = SceneManager.LoadSceneAsync(sceneName);
            while (handle.isDone == false)
            {
                yield return new WaitForEndOfFrame();
            }

            callback?.Invoke();
        }
    }
}