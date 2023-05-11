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

        public RaycastService(InputService inputService)
        {
            _inputService = inputService;          
        }

        public bool RaycastFromMousePosition(out RaycastHit raycastHit)
        {
            var ray = Camera.main.ScreenPointToRay(_inputService.MousePosition);
            if(Physics.Raycast(ray,out raycastHit))
                return true;
            return false;
        }
    }
}
