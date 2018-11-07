using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
	public class TeammateView : BaseSceneObject 
	{
		private TeammateModel _model;

		protected override void Awake()
		{
			base.Awake ();

			_model = GetComponentInParent<TeammateModel> ();

			TeammatesController.OnTeammateSelected += TeammateSelected;
			IsVisible = false;
		}

		private void TeammateSelected (TeammateModel teammate)
		{
			IsVisible = _model == teammate;
		}

		private void OnDestroy()
		{
			TeammatesController.OnTeammateSelected -= TeammateSelected;
		}
	}
}