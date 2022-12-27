using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdaptiveLoadingScreen.Base;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Service.Loading
{
    class LoadingService : Singleton<LoadingService>
    {
        public event Action<bool> LoadingActiveChanged;
        public event Action<string> LoadingInformationChanged;
        public event Action<float> CurrentLoadingProgressChanged;

        private const string PERSISTENCE_SCENE_NAME = "PersistentScene";

        private bool _loadingActive;
        private string _loadingInformation;
        private float _currentLoadingProgress;
        
        private readonly List<AsyncOperation> _loadingOperations = new List<AsyncOperation>();
        private float _currentLoadingProcess;

        public bool LoadingActive
        {
            get
            {
                return _loadingActive;
            }
            private set
            {
                if(value == _loadingActive)
                    return;

                _loadingActive = value;
                LoadingActiveChanged?.Invoke(_loadingActive);
            }
        }

        public string LoadingInformation
        {
            get
            {
                return _loadingInformation;
            }
            private set
            {
                if(value == _loadingInformation)
                    return;

                _loadingInformation = value;
                LoadingInformationChanged?.Invoke(_loadingInformation);
            }
        }

        public float CurrentLoadingProgress
        {
            get
            {
                return _currentLoadingProgress;
            }
            private set
            {
                if(value == _currentLoadingProgress)
                    return;

                _currentLoadingProgress = value;
                CurrentLoadingProgressChanged?.Invoke(_currentLoadingProgress);
            }
        }

        /// <summary>
        /// Loads the specified Levels additive to the Persistence scene
        /// </summary>
        /// <param name="levelNames">scene names</param>
        public void LoadLevels(string[] levelNames)
        {
            LoadingActive = true;
            //_loadingOperations.Clear();
            UnloadAllLevels();
            foreach (string levelName in levelNames)
            {
                _loadingOperations.Add(SceneManager.LoadSceneAsync(levelName,LoadSceneMode.Additive));
            }

            ProcessLoading();
        }

        private async Task ProcessLoading()
        {
            try
            {
                for (int i = 0; i < _loadingOperations.Count; i++)
                {
                    while (!_loadingOperations[i].isDone)
                    {
                        _currentLoadingProcess = 0;

                        foreach (AsyncOperation loadingOperation in _loadingOperations)
                        {
                            _currentLoadingProcess += loadingOperation.progress;
                        }

                        _currentLoadingProcess = (_currentLoadingProcess / _loadingOperations.Count);
                        CurrentLoadingProgress = _currentLoadingProcess;
                        LoadingInformation = "Loading Levels";
                        await Task.Yield();
                    }
                }

                LoadingActive = false;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Unloads all Levels except the Persistence scene
        /// </summary>
        private void UnloadAllLevels()
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene sceneAt = SceneManager.GetSceneAt(i);
                if (sceneAt.name != PERSISTENCE_SCENE_NAME)
                    _loadingOperations.Add(SceneManager.UnloadSceneAsync(sceneAt));
            }
        }
    }
}