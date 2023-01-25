using System;
using UnityEngine;
using ControlFreak2;

namespace HutongGames.PlayMaker.Actions.CF2
{
	[ActionCategory(ControlFreak2.Extra.PlaymakerUtils.CATEGORY_TOUCH_CONTROLS)]
	[Tooltip("Show or hide CF2 Touch Control.")]
	public class CF2ShowOrHideControl : ComponentActionEx<ControlFreak2.TouchControl>
	{
		[RequiredField]
		[CheckForComponent(typeof(ControlFreak2.TouchControl))]
        [Tooltip("The CF2 Touch Control to show/hide.")]
		public FsmOwnerDefault touchControl;
		
        [Tooltip("Show (true) or Hide (false)?")]
		public FsmBool showControl;
		
        [Tooltip("Skip animated fade-out/fade-in?")]
		public FsmBool skipAnimation;
		
		
		public override void Reset()
		{
			touchControl = null;
			showControl = true;
			skipAnimation = false;
		}
		
		public override void OnEnter()
			{
			DoIt();
			Finish();
			}

		void DoIt()
		{
		var go = Fsm.GetOwnerDefaultTarget(touchControl);			
		if (UpdateCache(go))
			{
			ControlFreak2.TouchControl c = this.targetComponent;
			c.ShowOrHideControl(this.showControl.Value, this.skipAnimation.Value);
			}
		}
	}
}
