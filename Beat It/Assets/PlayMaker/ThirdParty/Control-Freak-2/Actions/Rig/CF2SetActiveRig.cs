using System;
using UnityEngine;
using ControlFreak2;

namespace HutongGames.PlayMaker.Actions.CF2
{
	[ActionCategory(ControlFreak2.Extra.PlaymakerUtils.CATEGORY_RIG)]
	[Tooltip("Set CF2 Active Rig.")]
	public class CF2SetActiveRig : FsmStateAction
		{
		[Tooltip("Input Rig reference.")]
		[ObjectType(typeof(InputRig))]
		public FsmObject 
			rig;

		
		public override void Reset()
		{
			this.rig = null;
		}
		
		public override void OnEnter()
			{
			DoIt();
			Finish();
			}

	void DoIt()
		{
		CF2Input.activeRig = (InputRig)this.rig.Value;
		}
	}
}

