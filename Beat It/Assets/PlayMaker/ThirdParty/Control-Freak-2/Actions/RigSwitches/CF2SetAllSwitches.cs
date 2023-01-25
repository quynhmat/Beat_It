using System;
using UnityEngine;
using ControlFreak2;

namespace HutongGames.PlayMaker.Actions.CF2
{
	[ActionCategory(ControlFreak2.Extra.PlaymakerUtils.CATEGORY_SWITCHES)]
	[Tooltip("Set All Input Rig's Switches to given state.")]
	public class CF2SetAllSwitches : ComponentActionEx<ControlFreak2.InputRig>
	{
		//[RequiredField]
		[CheckForComponent(typeof(ControlFreak2.InputRig))]
        [Tooltip("The CF2 Input Rig to modify. Set this to None to use the Active Rig.")]
		public FsmOwnerDefault rig;
		
        [Tooltip("State to set.")]
		public FsmBool switchState;
		
		
		public override void Reset()
		{
			rig = null;
			switchState = false;
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

		rig.SetAllSwitches(this.switchState.Value);
		}
	}
}
