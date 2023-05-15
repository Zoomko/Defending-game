using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.CodeBase.Factory
{
    public interface IHUDFactory
    {
        UIDocument HUD { get; }
        UIDocument Create();
    }
}