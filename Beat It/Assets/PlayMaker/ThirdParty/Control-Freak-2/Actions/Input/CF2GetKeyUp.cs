// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions.CF2
	{
	[ActionCategory(ControlFreak2.Extra.PlaymakerUtils.CATEGORY_INPUT)]
	[Tooltip("Sends an Event when a Key is released.")]
	public class CF2GetKeyUp : FsmStateAction
	{
		[RequiredField]
		public KeyCode key;
		public FsmEvent sendEvent;
		[UIHint(UIHint.Variable)]
		public FsmBool storeResult;
		
		public override void Reset()
		{
			sendEvent = null;
			key = KeyCode.None;
			storeResult = null;
		}

		public override void OnUpdate()
		{
			bool keyUp = ControlFreak2.CF2Input.GetKeyUp(key);
			
			if (keyUp)
				Fsm.Event(sendEvent);
			
			storeResult.Value = keyUp;
		}
	}
}