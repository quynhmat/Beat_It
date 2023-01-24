﻿using System;
using UnityEngine;
using ControlFreak2;

namespace HutongGames.PlayMaker.Actions.CF2
{
	[ActionCategory(ControlFreak2.Extra.PlaymakerUtils.CATEGORY_ANIMATORS)]
	[Tooltip("Set Button Sprite Animator's Sprite and/or Color.")]
	public class CF2ModifyButtonSpriteAnimator : ComponentActionEx<ControlFreak2.TouchButtonSpriteAnimator>
	{
		[RequiredField]
		[CheckForComponent(typeof(ControlFreak2.TouchButtonSpriteAnimator))]
        [Tooltip("The CF2 Touch Button Sprite Animator.")]
		public FsmOwnerDefault spriteAnimator;
		
		[RequiredField]
		//[ObjectType(typeof(ControlFreak2.TouchButtonSpriteAnimator.ControlState))]
        [Tooltip("Button Animator's State to modify.")]
		//public FsmEnum
		public ControlFreak2.TouchButtonSpriteAnimator.ControlState 
			buttonState;

		[ObjectType(typeof(Sprite))]
	    [Tooltip("Sprite to set.")]
		public FsmObject sprite;

        [Tooltip("Color to set.")]
		public FsmColor color;

		
		public override void Reset()
		{
			spriteAnimator = null;
			buttonState = TouchButtonSpriteAnimator.ControlState.All; 
			this.sprite = null;
			this.color = null;
		}
		
		public override void OnEnter()
			{
			DoIt();
			Finish();
			}

		void DoIt()
		{
		var go = Fsm.GetOwnerDefaultTarget(this.spriteAnimator);			
		if (UpdateCache(go))
			{
			ControlFreak2.TouchButtonSpriteAnimator 
				a = this.targetComponent;
			TouchButtonSpriteAnimator.ControlState 
				state = (TouchButtonSpriteAnimator.ControlState)this.buttonState; //.Value;

			Sprite newSprite = null;
			if ((this.sprite != null) && !this.sprite.IsNone && ((newSprite = (this.sprite.Value as Sprite)) != null))
				a.SetStateSprite(state, newSprite);

			if ((this.color != null) && !this.color.IsNone)
				a.SetStateColor(state, this.color.Value);
			
			}
		}
	}
}
