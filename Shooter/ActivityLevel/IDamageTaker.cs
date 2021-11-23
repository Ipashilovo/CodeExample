namespace ActivityLevel
{
    public interface IDamageTaker
    {
        public void TakeDamage(int damage);
        void TakeDamageAfterDelay(int damage, float delay);
    }
}