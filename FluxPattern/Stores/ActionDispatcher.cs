using FluxPattern.Stores.Interfaces;

namespace FluxPattern.Stores
{
    public class ActionDispatcher : IActionDispatcher
    {
        private Action<IAction> _registeredActionHandlers;

        #region flux pattern
        public void Subscribe(Action<IAction> actionHandlers) => _registeredActionHandlers += actionHandlers;

        public void Unsubscribe(Action<IAction> actionHandlers) => _registeredActionHandlers -= actionHandlers;

        public void Dispatch(IAction action) => _registeredActionHandlers?.Invoke(action);
        #endregion
    }
}
