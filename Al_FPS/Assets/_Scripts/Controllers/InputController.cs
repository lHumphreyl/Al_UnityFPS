using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class InputController : BaseController
    {
        private void Update()
        {
            if (Input.GetButtonDown("Flashlight")) 
				Main.Instance.FlashlightController.Switch();

			if (Input.GetButton ("Fire1"))
				Main.Instance.WeaponController.Fire ();

			if (Input.GetButton ("Fire2"))
				Main.Instance.WeaponController.AltFire ();

			if (Input.GetButtonDown ("ReloadWeapon"))
				Main.Instance.WeaponController.Reload ();

			if (Input.GetAxis ("Mouse ScrollWheel") != 0)
				Main.Instance.WeaponController.ChangeWeapon (true);

			if (Input.GetButtonDown ("SwitchToNextWeapon"))
				Main.Instance.WeaponController.ChangeWeapon ();
        }
    }
}