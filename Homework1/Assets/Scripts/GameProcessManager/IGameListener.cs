namespace ShootEmUp
{
    public interface IGameListener
    {

    }

    public interface IGameStartListener : IGameListener
    {
        void StartGame();
    }

    public interface IGameFinishListener : IGameListener
    {
        void FinishGame();
    }

    public interface IGamePauseListener : IGameListener
    {
        void PauseGame();
    }

    public interface IGameResumeListener : IGameListener
    {
        void ResumeGame();
    }

    public interface IGameUpdateListener : IGameListener
    {
        void UpdateGame(float time);
    }
}