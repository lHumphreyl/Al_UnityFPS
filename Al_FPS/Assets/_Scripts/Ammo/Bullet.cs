using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters;


namespace FPS
{
	public class Bullet : BaseAmmo
	{
		[SerializeField]
		private LayerMask _layerMask;

		[SerializeField]
		private float _destroyTime = 2f;

		private float _bulletSpeed;
		private bool _isHitted;


		public override void Initialize (Transform shotspawn, float force)
		{
			_bulletSpeed = force;

			transform.position = shotspawn.position;
			transform.rotation = shotspawn.rotation;

			Destroy (gameObject, _destroyTime);
		}
			
		private void FixedUpdate()
		{
			if (_isHitted)
				return;

			var finalPos = transform.position + transform.forward * _bulletSpeed * Time.fixedDeltaTime;
			RaycastHit hit;
			if (Physics.Linecast (transform.position, finalPos, out hit, _layerMask)) 
			{
				_isHitted = true;
				transform.position = hit.point;

				var rb = hit.collider.GetComponent<Rigidbody> ();
				if (rb)
					rb.AddForce (transform.forward * _bulletSpeed, ForceMode.Impulse);

				var enemy = hit.collider.GetComponent<IDamageable> ();
				if (enemy != null)
					enemy.ApplyDamage (_damage);

				Destroy (gameObject, _destroyTime);
			} 
			else 
			{
				transform.position = finalPos;
			}
		}
	}
}
