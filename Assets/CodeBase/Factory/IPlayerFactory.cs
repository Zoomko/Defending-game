using UnityEngine;

namespace Assets.CodeBase.Factory
{
    public interface IPlayerFactory
    {
        GameObject Create();
    }
}