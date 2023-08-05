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
        private Action _listeners;

        public CounterStore()
        {
            _state = new CounterState(0);
        }

        public CounterState GetState()
        {
            return _state;
        }

        #region flux pattern

        public void AddStateChangeListener(Action listner)
        {
            _listeners += listner;
        }
        
        public void RemoveStateChangeListener(Action listner)
        {
            _listeners -= listner;
        }

        private void BroadcastStateChnage()
        {
            _listeners?.Invoke();
        }

        #endregion

        public void IncreaseCount()
        {
            _state = new CounterState(_state.Count+1);
            BroadcastStateChnage();
        }
    }
}
