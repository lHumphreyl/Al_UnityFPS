using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
	public class AmmoView : MonoBehaviour 
	{
		private Text _text;

		void Awake()
		{
			_text = GetComponent<Text> ();
		}

		void Update()
		{
			_text.text = Main.Instance.WeaponController.GetAmmoInfo ();
		}
	}
}
