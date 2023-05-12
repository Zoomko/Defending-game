using UnityEngine;

namespace Assets.CodeBase.Factory
{
    public interface IPlayerFactory
    {
        GameObject Player { get; }
        GameObject Create();
    }
}