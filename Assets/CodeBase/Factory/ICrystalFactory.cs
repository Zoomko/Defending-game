using System;
using UnityEngine;

namespace Assets.CodeBase.Factory
{
    public interface ICrystalFactory
    {
        GameObject Crystal { get; }

        event Action HasDestroyed;
        GameObject Create();
    }
}