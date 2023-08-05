using FluxPattern.Stores.Interfaces;

namespace FluxPattern.Stores.CounterStore
{
    public class DecrementAction : IAction
    {
        public const string DECREMENT = "DECREMENT";

        public string Name => DECREMENT;
    }
}
