using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Remoting.Messaging;

namespace FPS
{
	public class WeaponController : BaseController 
	{

		private BaseWeapon[] _weapons;
		private int _currentWeapon;

		private void Awake()
		{
			_weapons = Main.Instance.Player.GetComponentsInChildren<BaseWeapon> (true);

			for (int i = 0; i < _weapons.Length; i++)
				_weapons [i].IsVisible = i == 0;
		}

		/// <summary>
		/// Смена оружия по клавише (false) или с помощью колесика мыши (true). 
		/// </summary>
		/// <param name="_isScrolling">If set to <c>true</c> is scrolling.</param>
		public void ChangeWeapon(bool _isScrolling = false)
		{
			float _scroll = Input.GetAxisRaw ("Mouse ScrollWheel");

			if (_isScrolling) 
			{
				if (_scroll > 0)
					WeaponSwitch ();		//При скролле вверх
				else if (_scroll < 0) 
					WeaponSwitch (false);	//При скролле вниз
			} 
			else 
				WeaponSwitch ();			//По клавише
		}
			
		/// <summary>
		/// Основной режим выбранного оружия.
		/// </summary>
		/// <param name="AltFire">If set to <c>true</c> alternate fire.</param>
		public void Fire(bool AltFire = false)
		{
			if (_weapons.Length > _currentWeapon && _weapons [_currentWeapon]) 
					_weapons [_currentWeapon].Fire ();
		}

		/// <summary>
		/// Альтернативный режим выбранного оружия.
		/// </summary>
		public void AltFire()
		{
			if (_weapons.Length > _currentWeapon && _weapons [_currentWeapon]) 
				_weapons [_currentWeapon].AlternateFire ();
			
		}

		/// <summary>
		/// Перезарядка текущего оружия.
		/// </summary>
		public void Reload()
		{
			if (_weapons.Length > _currentWeapon && _weapons [_currentWeapon]) 
			{
				_weapons [_currentWeapon].Reload ();
			}
		}

		/// <summary>
		/// Смена оружия c определением направления колесика мыши (true - вперед/false - назад).
		/// </summary>
		/// <param name="isForward">If set to <c>true</c> is forward.</param>
		private void WeaponSwitch(bool isForward = true)
		{
			_weapons [_currentWeapon].IsVisible = false;

			if (isForward) 
			{
				_currentWeapon++;
				if (_currentWeapon >= _weapons.Length)
					_currentWeapon = 0;
			} 
			else 
			{
				_currentWeapon--;
				if (_currentWeapon < 0)
					_currentWeapon = _weapons.Length - 1;
			}

			_weapons [_currentWeapon].IsVisible = true;
		}

		/// <summary>
		/// Возвращает информацию о кол-ве амуниции для UI.
		/// </summary>
		/// <returns>Return ammo info.</returns>
		public string GetAmmoInfo()
		{
			return _weapons [_currentWeapon]._currentAmmo.ToString() + " / " + _weapons [_currentWeapon]._additionalAmmo.ToString();
		}
	}
}
