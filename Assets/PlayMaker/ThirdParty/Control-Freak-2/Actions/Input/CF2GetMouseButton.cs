// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions.CF2
	{
	[ActionCategory(ControlFreak2.Extra.PlaymakerUtils.CATEGORY_INPUT)]
	[Tooltip("Gets the pressed state of the specified Mouse Button and stores it in a Bool Variable. See Unity Input Manager doc.")]
	public class CF2GetMouseButton : FsmStateAction
	{
		[RequiredField]
        [Tooltip("The mouse button to test.")]
		public MouseButton button;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
        [Tooltip("Store the pressed state in a Bool Variable.")]
		public FsmBool storeResult;

		public override void Reset()
		{
			button = MouseButton.Left;
			storeResult = null;
		}

        public override void OnEnter()
        {
            storeResult.Value = ControlFreak2.CF2Input.GetMouseButton((int)button);
        }

		public override void OnUpdate()
		{
			storeResult.Value = ControlFreak2.CF2Input.GetMouseButton((int)button);
		}
	}
}

