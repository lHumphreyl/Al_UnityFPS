using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FPS
{
	public class TeammatesController : BaseController 
	{
		public static Action<TeammateModel> OnTeammateSelected;

		private TeammateModel _currentTeammate;

		public void MoveCommand()
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				TeammateModel _teammate = hit.collider.GetComponent<TeammateModel> ();
				if (_teammate)
					SelectTeammate (_teammate);
				else if (_currentTeammate)
					_currentTeammate.SetDestination (hit.point);
			}
		}

		public void SelectTeammate(TeammateModel _teammate)
		{
			_currentTeammate = _teammate;

			if (OnTeammateSelected != null)
				OnTeammateSelected.Invoke (_currentTeammate);
		}
	}
}
