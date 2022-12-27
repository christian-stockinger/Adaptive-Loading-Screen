using System.Collections.Generic;
using UnityEngine;

namespace Service.Loading
{
    public class LoadingServiceTrigger : MonoBehaviour
    {
        public bool LoadOnInit;
        public List<SceneReference> ScenesToLoad;
        private void Start()
        {
            if (LoadOnInit)
            {
                LoadScenes();
            }
        }
        
        private void LoadScenes()
        {
            string[] levels = new string[ScenesToLoad.Count];
            
            for (int index = 0; index < ScenesToLoad.Count; index++)
            {
                levels[index] = ScenesToLoad[index].ScenePath;
            }

            LoadingService.Instance.LoadLevels(levels);
        }

        public void LoadLevel(int levelIndex)
        {
            LoadSpecificLevel(levelIndex);
        }

        private void LoadSpecificLevel(int levelIndex)
        {
            string[] levels = new[]
            {
                "Player",
                "Hud",
                $"Level{levelIndex}"
            };
            LoadingService.Instance.LoadLevels(levels);
        }
    }
}