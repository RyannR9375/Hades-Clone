namespace HadesClone
{
    public interface IState
    {
        void OnEnter();
        void Update();
        void FixedUpdate();
        void OnChange();
        void OnExit();
    }
}