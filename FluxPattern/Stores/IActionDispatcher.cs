using FluxPattern.Stores.Interfaces;

namespace FluxPattern.Stores
{
    public interface IActionDispatcher
    {
        void Dispatch(IAction action);
        void Subscribe(Action<IAction> actionHandlers);
        void Unsubscribe(Action<IAction> actionHandlers);
    }
}