namespace ShootEmUp
{
    public interface IBulletPool
    {
        Bullet Get();
        void Return(Bullet bullet);
    }
}