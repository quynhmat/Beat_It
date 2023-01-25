using System;
using UnityEngine;
using ControlFreak2;

namespace HutongGames.PlayMaker.Actions.CF2
{
	[ActionCategory(ControlFreak2.Extra.PlaymakerUtils.CATEGORY_MISC)]
	[Tooltip("Set CF2 Mobile Mode.")]
	public class CF2SetMobileMode : FsmStateAction
		{
		//[RequiredAttribute()]
		[Tooltip("Mobile mode as boolean value. Set this parameter to NONE to use enum value defined below...")]
		public FsmBool 
			boolMobileMode;
		
		[Tooltip("Mobile mode as enum. Use this to set mobile mode to Automatic.")]
		//[ObjectType(typeof(CF2Input.MobileMode))]
		//public FsmEnum
		public CF2Input.MobileMode
			enumMobileMode;

		
		public override void Reset()
		{
			this.enumMobileMode = CF2Input.MobileMode.Auto;
			this.boolMobileMode = null;
		}
		
		public override void OnEnter()
			{
			DoIt();
			Finish();
			}

	void DoIt()
		{
		if ((this.boolMobileMode != null) && !this.boolMobileMode.IsNone)
			CF2Input.SetMobileMode(this.boolMobileMode.Value ? CF2Input.MobileMode.Enabled : CF2Input.MobileMode.Disabled);

		else //if ((this.enumMobileMode != null) && !this.enumMobileMode.IsNone)
				CF2Input.SetMobileMode((CF2Input.MobileMode)this.enumMobileMode); //.Value);

//#if UNITY_EDITOR
//		else
//			Debug.LogError("Target Mobile Mode is not assigned (bool nor enum)! FSM: " + this.Fsm.Name); 
//#endif
		
		}
	}
}

