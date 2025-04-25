namespace HadesClone {
    public interface ITransition {
        IPredicate Condition { get; }
        IState To { get; }
    }
}