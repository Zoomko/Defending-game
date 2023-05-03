using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Services
{
    public class RaycastService
    {
        private readonly InputService _inputService;
        private readonly Camera _camera;

        public RaycastService(InputService inputService)
        {
            _inputService = inputService;
            _camera = Camera.main;
        }
        public bool RaycastFromMousePosition(out RaycastHit raycastHit)
        {
            var ray = _camera.ScreenPointToRay(_inputService.MousePosition);
            if(Physics.Raycast(ray,out raycastHit))
                return true;
            return false;
        }
    }
}
