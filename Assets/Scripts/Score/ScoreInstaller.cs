using UnityEngine;
using Zenject;

public class ScoreInstaller : MonoInstaller<ScoreInstaller>
{
    [SerializeField] private ScoreWindowActivator _scorePopup;
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<ScoreController>().AsSingle();
        Container.Bind<IScoreWindowActivator>().To<ScoreWindowActivator>().FromComponentOn(_scorePopup.gameObject).AsSingle();
    }
}
