
using System;
using UnityEngine;
using ControlFreak2;

namespace HutongGames.PlayMaker.Actions.CF2
{
	[ActionCategory(ControlFreak2.Extra.PlaymakerUtils.CATEGORY_SWITCHES)]
	[Tooltip("Set Input Rig's Switch state.")]
	public class CF2SetRigSwitch : ComponentActionEx<ControlFreak2.InputRig>
	{
		//[RequiredField]
		[CheckForComponent(typeof(ControlFreak2.InputRig))]
        [Tooltip("The CF2 Input Rig to modify. Set this to None to use the Active Rig.")]
		public FsmOwnerDefault rig;
		
		[RequiredFieldAttribute()]
        [Tooltip("Switch name.")]
		public FsmString switchName;
		
        [Tooltip("State to set.")]
		public FsmBool switchState;
		
		
		public override void Reset()
		{
			rig = null;
			switchName = null;
			switchState = null;
		}
		
		public override void OnEnter()
			{
			DoIt();
			Finish();
			}

	private int cachedId;

	void DoIt()
		{
		InputRig rig = (this.UpdateCache(Fsm.GetOwnerDefaultTarget(this.rig)) ? this.targetComponent : CF2Input.activeRig);
		if (rig == null)
			return;

		rig.SetSwitchState(this.switchName.Value, ref this.cachedId, this.switchState.Value);
		}
	}
}
