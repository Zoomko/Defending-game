﻿using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Factory
{
    public class CrystalFactory : ICrystalFactory
    {
        public event Action HasDestroyed;
        private GameObject _crystal;
        private readonly IStaticDataService _staticDataService;

        public GameObject Crystal => _crystal;
        public CrystalFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public GameObject Create()
        {
            var crystalPrefab = _staticDataService.GameStaticData.Crystal;
            var crystalGameObject = GameObject.Instantiate(crystalPrefab);
            var healthController = crystalGameObject.GetComponent<CrystalHealthController>();
            var dieContoller = crystalGameObject.GetComponent<CrystalDieController>();

            healthController.Constructor(_staticDataService.GameStaticData);
            dieContoller.HasDestroyed += OnDestroyed;

            _crystal = crystalGameObject;
            return crystalGameObject;
        }

        public void OnDestroyed()
        {
            var dieContoller = _crystal.GetComponent<CrystalDieController>();
            dieContoller.HasDestroyed -= OnDestroyed;
            HasDestroyed?.Invoke();
        }
    }
}
