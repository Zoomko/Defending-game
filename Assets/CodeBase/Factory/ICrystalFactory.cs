using UnityEngine;

namespace Assets.CodeBase.Factory
{
    public interface ICrystalFactory
    {
        GameObject Crystal { get; }
        GameObject Create();
    }
}