using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDisable : MonoBehaviour 
{
	Animator _animator;

	void Awake()
	{
		_animator = GetComponent<Animator> ();
	}

	void Update()
	{
		if (!IsAnimationPlaying ("Shot"))
			_animator.SetBool ("isShooting", false);
		if (!IsAnimationPlaying ("Reload"))
			_animator.SetBool ("isReloading", false);
	}

	public bool IsAnimationPlaying(string animationName) 
	{        
		// берем информацию о состоянии
		var animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
		// смотрим, есть ли в нем имя какой-то анимации, то возвращаем true
		if (animatorStateInfo.IsName(animationName))             
			return true;

		return false;
	}
}
