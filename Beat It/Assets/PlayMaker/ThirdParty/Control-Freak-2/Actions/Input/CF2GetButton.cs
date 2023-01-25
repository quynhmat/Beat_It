// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions.CF2
	{
	[ActionCategory(ControlFreak2.Extra.PlaymakerUtils.CATEGORY_INPUT)]
	[Tooltip("Gets the pressed state of the specified Button and stores it in a Bool Variable. See Unity Input Manager docs.")]
	public class CF2GetButton : FsmStateAction
	{
		[RequiredField]
        [Tooltip("The name of the button. Set in the Unity Input Manager.")]
		public FsmString buttonName;		

		[RequiredField]
		[UIHint(UIHint.Variable)]
        [Tooltip("Store the result in a bool variable.")]
		public FsmBool storeResult;

        [Tooltip("Repeat every frame.")]
		public bool everyFrame;

		public override void Reset()
		{
			buttonName = "Fire1";
			storeResult = null;
			everyFrame = true;
		}

		public override void OnEnter()
		{
			DoGetButton();

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoGetButton();
		}

		private int cachedId;
		void DoGetButton()
		{
			storeResult.Value = ControlFreak2.CF2Input.GetButton(buttonName.Value, ref this.cachedId);
		}
	}
}

