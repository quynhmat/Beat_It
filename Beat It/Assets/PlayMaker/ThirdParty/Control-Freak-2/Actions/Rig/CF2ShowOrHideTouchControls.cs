
using System;
using UnityEngine;
using ControlFreak2;

namespace HutongGames.PlayMaker.Actions.CF2
{
[ActionCategory(ControlFreak2.Extra.PlaymakerUtils.CATEGORY_RIG)]
[Tooltip("Show or Hide all touch controls of given Input Rig.")]
public class CF2ShowOrHideTouchControls : ComponentActionEx<ControlFreak2.InputRig>
	{
	//[RequiredField]
	[CheckForComponent(typeof(ControlFreak2.InputRig))]
    [Tooltip("The CF2 Input Rig to modify. Set this to None to use the Active Rig.")]
	public FsmOwnerDefault rig;
	
     [Tooltip("Show (true) or Hide (false)?")]
	public FsmBool showControls;
	
    [Tooltip("Skip animated fade-out/fade-in?")]
	public FsmBool skipAnimation;
		
		
		public override void Reset()
		{
			rig = null;
			showControls = true;
			skipAnimation = false;
		}
		
		public override void OnEnter()
			{
			DoIt();
			Finish();
			}

	void DoIt()
		{
		InputRig rig = (this.UpdateCache(Fsm.GetOwnerDefaultTarget(this.rig)) ? this.targetComponent : CF2Input.activeRig);
		if (rig == null)
			return;

		rig.ShowOrHideTouchControls(this.showControls.Value, this.skipAnimation.Value);
		}
	}
}
