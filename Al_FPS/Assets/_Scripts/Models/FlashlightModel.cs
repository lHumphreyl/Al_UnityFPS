using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace FPS
{
	public class FlashlightModel : MonoBehaviour 
	{
		public static UnityAction<float> OnFillAmountChanged;
		public float FillAmount { get; private set; }

		private Light _light;
		[SerializeField]
		private float _rechargeTime = 8f;
		[SerializeField]
		private float _drainMult = 4f;

		public bool isOn
		{
			get
			{
				if(_light == null)
					return false;
				return  _light.enabled;
			}
		}

		private void Awake()
		{
			_light = GetComponent<Light> ();
			FillAmount = 1f;
		}

		public void On()
		{			
			if (FillAmount < 0.2f)
				return;
			_light.enabled = true;
		}

		public void Off()
		{
			_light.enabled = false;
		}

		public void Switch()
		{
			if (isOn)
				Off ();
			else
				On ();
		}

		private void OnEnable()
		{
			StartCoroutine (ChangeFill ());
		}

		private void OnDisable()
		{
			StopCoroutine (ChangeFill ());
		}

		private IEnumerator ChangeFill()
		{
			while (true) 
			{
				yield return new WaitForSeconds (0.5f);
				if (isOn) 
				{
					FillAmount = Mathf.Clamp01 (FillAmount - (1f / (_drainMult * _rechargeTime) * 0.5f));
					if (FillAmount <= 0f)
						Off ();
				} 
				else 
				{
					FillAmount = Mathf.Clamp01 (FillAmount + (1f / _rechargeTime * 0.5f));
				}
				if (OnFillAmountChanged != null)
					OnFillAmountChanged (FillAmount);
			}
		}
	}
}
