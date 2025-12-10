namespace ShootEmUp
{
    public interface IBackgroundMovable
    {
        void Move();
        void MoveScreen();

        void Init(IParamsBackground p);
    }
}