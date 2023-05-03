using UnityEngine;
using Zenject;

public class ProjectContext : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<InputService>().AsSingle();
    }
}