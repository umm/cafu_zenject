using UniRx;

namespace CAFU.Zenject.Utility
{
    public interface IInstancePublisher
    {
        IMessagePublisher MessagePublisher { get; set; }
    }

    public static class InstancePublisherExtensions
    {
        public static void Publish(this IInstancePublisher self)
        {
            self.MessagePublisher.Publish(self);
        }
    }
}