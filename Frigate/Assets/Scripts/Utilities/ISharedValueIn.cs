namespace Assets.Scripts.Utilities
{
    public interface ISharedValueIn<in T>
    {
        void Set(T messageToDisplay);
        void Reset();
    }
}