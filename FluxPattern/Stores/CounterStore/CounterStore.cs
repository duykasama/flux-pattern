using FluxPattern.Stores.Interfaces;

namespace FluxPattern.Stores.CounterStore
{
    public class CounterState
    {
        public int Count { get; }
        public CounterState(int count)
        {
            Count = count;
        }
    }

    public class CounterStore
    {
        public CounterState _state;
        private IActionDispatcher actionDispatcher;

        public CounterStore(IActionDispatcher actionDispatcher)
        {
            _state = new CounterState(0);
            this.actionDispatcher = actionDispatcher;
            this.actionDispatcher.Subscribe(HandleActions);
        }

        public CounterState GetState()
        {
            return _state;
        }

        private void HandleActions(IAction action)
        {
            switch (action)
            {
                case IncrementAction:
                    IncreaseCount();
                    break;
                case DecrementAction:
                    DecreaseCount();
                    break;
                default:
                    break;
            }
        }


        #region observer pattern
        private Action _listeners;

        public void AddStateChangeListener(Action listner)
        {
            _listeners += listner;
        }
        
        public void RemoveStateChangeListener(Action listner)
        {
            _listeners -= listner;
        }

        private void BroadcastStateChange()
        {
            _listeners?.Invoke();
        }

        #endregion

        private void IncreaseCount()
        {
            _state = new CounterState(_state.Count + 1);
            BroadcastStateChange();
        }

        private void DecreaseCount()
        {
            _state = new CounterState(_state.Count - 1);
            BroadcastStateChange();
        }
    }
}
