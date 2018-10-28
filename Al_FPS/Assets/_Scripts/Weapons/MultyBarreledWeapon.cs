﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FPS
{
	public class MultyBarreledWeapon : BaseWeapon 
	{
		[SerializeField]
		private Transform[] _shotSpawns;
		private int _currentShotSpawn;

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
			bullet.Initialize (_shotSpawns[_currentShotSpawn], _force);

			_currentAmmo--;
			_currentShotSpawn++;
			if (_currentShotSpawn >= _shotSpawns.Length)
				_currentShotSpawn = 0;
		}

		public override void AlternateFire()
		{
			if (!CanFire() || _altMode == _alternateMode.None)
				return;

			if (_altMode == _alternateMode.AllBarrels) 
			{
				if (_currentAmmo > 1) 
				{
					for (_currentShotSpawn = 0; _currentShotSpawn < _shotSpawns.Length; _currentShotSpawn++) 
					{
						var bullet = Instantiate (_ammoPrefab);
						bullet.Initialize (_shotSpawns [_currentShotSpawn], _force);

						_currentAmmo--;
					}
				} 
				else 
				{
					var bullet = Instantiate (_ammoPrefab);
					bullet.Initialize (_shotSpawns [_currentShotSpawn], _force);

					_currentShotSpawn++;
					_currentAmmo--;
				}
			}

			if (_currentShotSpawn >= _shotSpawns.Length)
				_currentShotSpawn = 0;
			
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
