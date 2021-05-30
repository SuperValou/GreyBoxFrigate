using System;

namespace Assets.Scripts.Utilities
{
    public interface ISharedValueOut<out T>
    {
        T Value { get; }

        event Action<T> ValueChanged;
    }
}