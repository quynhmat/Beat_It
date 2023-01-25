
using System;
using UnityEngine;
using ControlFreak2;

namespace HutongGames.PlayMaker.Actions.CF2
{
	[ActionCategory(ControlFreak2.Extra.PlaymakerUtils.CATEGORY_RIG)]
	[Tooltip("Get CF2 active rig reference.")]
	public class CF2GetActiveRig : FsmStateAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[ObjectType(typeof(InputRig))]
		[Tooltip("Store the result in a object variable.")]
		public FsmObject storeResult;
		
		public override void Reset()
		{
			this.storeResult = null;
		}
		
		public override void OnEnter()
			{
			DoIt();
			Finish();
			}

	void DoIt()
		{
		this.storeResult.Value = CF2Input.activeRig;
		}
	}
}
