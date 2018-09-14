using System;
using UniRx;

namespace CAFU.Zenject.Utility
{
    public interface IInstanceReceiver
    {
        IMessageReceiver MessageReceiver { get; }
    }

    public static class InstanceReceiverExtensions
    {
        public static IObservable<T> Receive<T>(this IInstanceReceiver self)
        {
            return self
                .MessageReceiver
                .Receive<IInstancePublisher>()
                .OfType(default(T));
        }
    }
}