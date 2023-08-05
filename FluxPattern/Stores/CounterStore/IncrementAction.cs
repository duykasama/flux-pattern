using FluxPattern.Stores.Interfaces;

namespace FluxPattern.Stores.CounterStore
{
    public class IncrementAction : IAction
    {
        public const string INCREMENT = "INCREMENT";

        public string Name => INCREMENT;
    }
}
