namespace Alex_scripts.Interfaces
{
    public interface IListener<in T>
    {
        void HandleEvent(T data);
    }
}