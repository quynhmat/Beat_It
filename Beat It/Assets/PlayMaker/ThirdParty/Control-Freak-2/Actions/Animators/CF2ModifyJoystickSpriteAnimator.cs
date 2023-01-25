using System;
using UnityEngine;
using ControlFreak2;

namespace HutongGames.PlayMaker.Actions.CF2
{
	[ActionCategory(ControlFreak2.Extra.PlaymakerUtils.CATEGORY_ANIMATORS)]
	[Tooltip("Set Button Sprite Animator's Sprite and/or Color.")]
	public class CF2ModifyJoystickSpriteAnimator : ComponentActionEx<ControlFreak2.TouchJoystickSpriteAnimator>
	{
		[RequiredField]
		[CheckForComponent(typeof(ControlFreak2.TouchJoystickSpriteAnimator))]
        [Tooltip("The CF2 Touch Joystick Sprite Animator.")]
		public FsmOwnerDefault spriteAnimator;
		
		[RequiredField]
		//[ObjectType(typeof(ControlFreak2.TouchJoystickSpriteAnimator.ControlState))]
        [Tooltip("Joystick Animator's State to modify.")]
		//public FsmEnum 
		public ControlFreak2.TouchJoystickSpriteAnimator.ControlState
			controlState;

		[ObjectType(typeof(Sprite))]
	    [Tooltip("Sprite to set.")]
		public FsmObject sprite;

        [Tooltip("Color to set.")]
		public FsmColor color;

		
		public override void Reset()
		{
			spriteAnimator = null;
			controlState = TouchJoystickSpriteAnimator.ControlState.All; 
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
			ControlFreak2.TouchJoystickSpriteAnimator 
				a = this.targetComponent;
			TouchJoystickSpriteAnimator.ControlState 
				state = (TouchJoystickSpriteAnimator.ControlState)this.controlState; //.Value;

			Sprite newSprite = null;
			if ((this.sprite != null) && !this.sprite.IsNone && ((newSprite = (this.sprite.Value as Sprite)) != null))
				a.SetStateSprite(state, newSprite);

			if ((this.color != null) && !this.color.IsNone)
				a.SetStateColor(state, this.color.Value);
			
			}
		}
	}
}
