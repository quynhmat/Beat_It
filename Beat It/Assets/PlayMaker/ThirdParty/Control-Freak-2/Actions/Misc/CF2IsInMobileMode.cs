
using System;
using UnityEngine;
using ControlFreak2;

namespace HutongGames.PlayMaker.Actions.CF2
{
	[ActionCategory(ControlFreak2.Extra.PlaymakerUtils.CATEGORY_MISC)]
	[Tooltip("Store state of CF2 Mobile Mode into a variable.")]
	public class CF2IsInMobileMode : FsmStateAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
        [Tooltip("Store the result in a bool variable.")]
		public FsmBool storeResult;
		
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
		this.storeResult.Value = CF2Input.IsInMobileMode();
		}
	}
}
