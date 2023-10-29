using UnityEngine;
using Zenject;

public class ControllsInstaller : MonoInstaller<ControllsInstaller>
{
    [SerializeField] private JoystickController _joystickController;
    
    public override void InstallBindings()
    {
        Container.Bind<IJoystickActivator>().To<JoystickController>().FromComponentOn(_joystickController.gameObject).AsSingle();
    }
}
