// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions.CF2
	{
	[ActionCategory(ControlFreak2.Extra.PlaymakerUtils.CATEGORY_INPUT)]
	[Tooltip("Sends an Event when a Button is pressed.")]
	public class CF2GetButtonDown : FsmStateAction
	{
		[RequiredField]
        [Tooltip("The name of the button. Set in the Unity Input Manager.")]
		public FsmString buttonName;

        [Tooltip("Event to send if the button is pressed.")]
		public FsmEvent sendEvent;

        [Tooltip("Set to True if the button is pressed.")]
		[UIHint(UIHint.Variable)]
		public FsmBool storeResult;
		
		public override void Reset()
		{
			buttonName = "Fire1";
			sendEvent = null;
			storeResult = null;
		}


		private int cachedId;
		public override void OnUpdate()
		{
			var buttonDown = ControlFreak2.CF2Input.GetButtonDown(buttonName.Value, ref this.cachedId);
			
			if (buttonDown)
			{
			    Fsm.Event(sendEvent);
			}
			
			storeResult.Value = buttonDown;
		}
	}
}