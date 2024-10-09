namespace ShootMeUpV1
{
    public interface IDamageable
    {
        int Health { get; }
        void TakeDamage(int damage);
        void Attack();
    }
}
