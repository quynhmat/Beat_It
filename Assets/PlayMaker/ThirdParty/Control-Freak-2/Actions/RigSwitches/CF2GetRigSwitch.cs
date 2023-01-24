
using System;
using UnityEngine;
using ControlFreak2;

namespace HutongGames.PlayMaker.Actions.CF2
{
	[ActionCategory(ControlFreak2.Extra.PlaymakerUtils.CATEGORY_SWITCHES)]
	[Tooltip("Get Input Rig's Switch state.")]
	public class CF2GetRigSwitch : ComponentActionEx<ControlFreak2.InputRig>
	{
		//[RequiredField]
		[CheckForComponent(typeof(ControlFreak2.InputRig))]
        [Tooltip("The CF2 Input Rig to read from. Set this to None to use the Active Rig.")]
		public FsmOwnerDefault rig;
		
		[RequiredFieldAttribute()]
        [Tooltip("Switch name.")]
		public FsmString switchName;
		
        [Tooltip("Fallback value to use when given switch does not exit.")]
		public FsmBool fallbackValue;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
        [Tooltip("Store the result in a bool variable.")]
		public FsmBool storeResult;
		
		public override void Reset()
		{
			rig = null;
			switchName = null;
			fallbackValue = false;
			this.storeResult = null;
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
		this.storeResult.Value = ((rig != null) ? 
			rig.GetSwitchState(this.switchName.Value, ref this.cachedId, this.fallbackValue.Value) : this.fallbackValue.Value);
		}
	}
}
