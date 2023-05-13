using Assets.CodeBase.Data.PersistentData;
using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Extentions;
using Assets.CodeBase.Factory;
using Assets.CodeBase.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.App
{
    public class SaveLoadController
    {
        private readonly PersistentDataService _persistentDataService;
        private readonly InputService _inputService;

        public SaveLoadController(InputService inputService, PersistentDataService persistentDataService)
        {           
            _inputService = inputService;          
            _persistentDataService = persistentDataService;
            _inputService.SavedProgress += SaveScene;
            _inputService.LoadedProgress += LoadScene;
        }  
        
        private void SaveScene()
        {
            Debug.Log("Save");
            _persistentDataService.Save();
        }
        private void LoadScene()
        {
            Debug.Log("Load");
            _persistentDataService.Load();
        }
    }
}
