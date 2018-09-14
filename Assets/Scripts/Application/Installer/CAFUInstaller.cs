using UniRx;
using Zenject;

namespace CAFU.Zenject.Application.Installer
{
    public class CAFUInstaller : MonoInstaller<CAFUInstaller>
    {
        public override void InstallBindings()
        {
            // Bind MessageBroker as singleton
            Container
                .Bind(
                    typeof(IMessagePublisher),
                    typeof(IMessageReceiver)
                )
                .To<MessageBroker>()
                .AsSingle();
        }
    }
}