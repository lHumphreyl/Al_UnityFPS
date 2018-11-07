using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
	public class Box : BaseSceneObject, IDamageable
	{
		[SerializeField]
		private float _armor = 0f;

		[SerializeField]
		private float _currentHealth = 100f;
		[SerializeField]
		private float _maxHealth = 100f;

		public bool IsAlive {	get	{	return _currentHealth > 0;	}	}
		public float MaxHealth {	get {	return _maxHealth;	}	}
		public float CurrentHealth {	get {	return _currentHealth;	}	}


		public void ApplyDamage(float damage)
		{
			if (!IsAlive)
				return;

			if (_armor <= 0f) 
			{
				_currentHealth -= damage;
				Color = Random.ColorHSV ();
			} 
			else 
			{
				_currentHealth -= damage / _armor;
				Color = Random.ColorHSV ();
			}

			if (IsAlive)
				Die ();
		}

		private void Die()
		{
			Color = Color.red;
			Collider.enabled = false;
			Destroy (gameObject, 2f);
		}
	}
}
