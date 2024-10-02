namespace ShootMeUpV1
{
    interface IDamageable
    {
        int Health { get; set; }
        void TakeDamage(int damage);
        void Attack();
    }
}
