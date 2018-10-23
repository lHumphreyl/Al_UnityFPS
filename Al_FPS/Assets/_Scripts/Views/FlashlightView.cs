using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
	public class FlashlightView : MonoBehaviour 
	{
		private Image _image;

		private void Awake()
		{
			_image = GetComponent<Image> ();

			FlashlightModel.OnFillAmountChanged += OnFillAmountChanged;
		}

		private void OnFillAmountChanged (float fillAmount)
		{
			if(Mathf.Abs(fillAmount - _image.fillAmount) > 0.02f)
				_image.fillAmount = fillAmount;
		}

		private void OnDestroy()
		{
			FlashlightModel.OnFillAmountChanged -= OnFillAmountChanged;
		}
	}
}

