using System;
using UnityEngine;
using ControlFreak2;

namespace HutongGames.PlayMaker.Actions.CF2
{
	[ActionCategory(ControlFreak2.Extra.PlaymakerUtils.CATEGORY_ANIMATORS)]
	[Tooltip("Set Button Sprite Animator's Sprite and/or Color.")]
	public class CF2ModifySuperTouchZoneSpriteAnimator : ComponentActionEx<ControlFreak2.SuperTouchZoneSpriteAnimator>
	{
		[RequiredField]
		[CheckForComponent(typeof(ControlFreak2.SuperTouchZoneSpriteAnimator))]
      [Tooltip("The CF2 Super Touch Zone Sprite Animator.")]
		public FsmOwnerDefault spriteAnimator;
		
		[RequiredField]
		//[ObjectType(typeof(ControlFreak2.SuperTouchZoneSpriteAnimator.ControlState))]
      [Tooltip("Super Touch Zone Animator's State to modify.")]
		//public FsmEnum 
		public ControlFreak2.SuperTouchZoneSpriteAnimator.ControlState
			controlState;

		[ObjectType(typeof(Sprite))]
	    [Tooltip("Sprite to set.")]
		public FsmObject sprite;

        [Tooltip("Color to set.")]
		public FsmColor color;

		
		public override void Reset()
		{
			spriteAnimator = null;
			controlState = SuperTouchZoneSpriteAnimator.ControlState.All; 
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
			ControlFreak2.SuperTouchZoneSpriteAnimator 
				a = this.targetComponent;
			SuperTouchZoneSpriteAnimator.ControlState 
				state = (SuperTouchZoneSpriteAnimator.ControlState)this.controlState; //.Value;

			Sprite newSprite = null;
			if ((this.sprite != null) && !this.sprite.IsNone && ((newSprite = (this.sprite.Value as Sprite)) != null))
				a.SetStateSprite(state, newSprite);

			if ((this.color != null) && !this.color.IsNone)
				a.SetStateColor(state, this.color.Value);
			
			}
		}
	}
}
