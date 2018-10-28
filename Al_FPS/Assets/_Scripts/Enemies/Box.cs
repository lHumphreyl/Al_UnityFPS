using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
	public class Box : BaseSceneObject, IDamageable
	{
		[SerializeField]
		private float _health = 100f;

		[SerializeField]
		private float _armor = 0f;

		public float Health { get { return _health; } }

		public void ApplyDamage(float damage)
		{
			if (Health <= 0f)
				return;

			if (_armor <= 0f) 
			{
				_health -= damage;
				Color = Random.ColorHSV ();
			} 
			else 
			{
				_health -= damage / _armor;
				Color = Random.ColorHSV ();
			}

			if (Health <= 0f)
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
