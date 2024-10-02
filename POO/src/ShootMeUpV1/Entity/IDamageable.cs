namespace ShootMeUpV1
{
    interface IDamageable
    {
        int Health { get; }
        void TakeDamage(int damage);
        void Attack();
    }
}
