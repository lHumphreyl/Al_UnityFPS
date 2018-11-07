public interface IDamageable
{
	bool IsAlive { get; }

	float MaxHealth { get; }
	float CurrentHealth { get; }

	void ApplyDamage(float Damage);
}
