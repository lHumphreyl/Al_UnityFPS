using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FPS
{
	public class SingleBarreledWeapon : BaseWeapon 
	{
		[SerializeField]
		private Transform _shotSpawn;

		[SerializeField]
		private _alternateMode _altMode;

		private void Start()
		{
			_currentAmmo = _maxClipAmmo;
		}

		public override void Fire ()
		{
			if (!CanFire())
				return;

			var bullet = Instantiate (_ammoPrefab);
			bullet.Initialize (_shotSpawn, _force);

			_currentAmmo--;
		}

		public override void AlternateFire()
		{
			if (!CanFire() || _altMode == _alternateMode.None)
				return;
		}

		public override void Reload ()
		{
			if (_currentAmmo == _maxClipAmmo)
				return;

			if (_additionalAmmo >= (_maxClipAmmo - _currentAmmo)) 
			{
				_additionalAmmo -= (_maxClipAmmo - _currentAmmo);
				_currentAmmo += (_maxClipAmmo - _currentAmmo);
			}
			else if(_additionalAmmo < (_maxClipAmmo - _currentAmmo))
			{
				_currentAmmo += _additionalAmmo;
				_additionalAmmo = 0;
			}
		}
	}
}
