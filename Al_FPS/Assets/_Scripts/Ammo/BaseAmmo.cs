using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FPS
{
	public abstract class BaseAmmo : BaseSceneObject
	{
		[SerializeField]
		protected float _damage = 10f;

		public abstract void Initialize (Transform shotspawn, float force);
	}
}
