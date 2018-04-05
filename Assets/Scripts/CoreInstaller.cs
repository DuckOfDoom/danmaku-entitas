using DuckOfDoom.Danmaku.Configuration;
using Zenject;

namespace DuckOfDoom.Danmaku
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IJsonSerializer>().To<JsonSerializer>().AsSingle();
        }
    }
}