using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
	public abstract class BaseWeapon : BaseSceneObject
	{
		[SerializeField]
		protected BaseAmmo _ammoPrefab;
		[SerializeField]
		protected float _force = 50f;

		public float _reloadTime = 3.5f;

		protected enum _alternateMode {None, AllBarrels, Scope, GrenadeLauncher };

		protected Animator Animator;

		[SerializeField]
		protected float _firerate;
		private float _lastShotTime;

		[SerializeField]
		protected int _maxClipAmmo = 30;
		[SerializeField]
		public int _additionalAmmo = 60;
		[HideInInspector]
		public int _currentAmmo;

		public abstract void Fire ();
		public abstract void AlternateFire ();
		public abstract void Reload	();

		protected bool CanFire()
		{
			if (_currentAmmo <= 0 || Time.time - _lastShotTime < _firerate)
				return false;

			_lastShotTime = Time.time;
			return true;
		}
	}
}
