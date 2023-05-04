using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CodeBase.App.Services
{
    public class SceneService : ISceneService
    {
        private readonly CoroutineService _coroutineService;
        public SceneService(CoroutineService coroutineObject)
        {
            _coroutineService = coroutineObject;
        }

        public void Load(string name, Action onLoaded)
        {
            _coroutineService.StartCoroutine(LoadYourAsyncScene(name, onLoaded));
        }

        private IEnumerator LoadYourAsyncScene(string name, Action onLoaded)
        {

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            onLoaded?.Invoke();

        }
    }
}
