// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions.CF2
	{
	[ActionCategory(ControlFreak2.Extra.PlaymakerUtils.CATEGORY_INPUT)]
	[Tooltip("Gets the position of the mouse and stores it in a Float/Vector2/Vector3 Variable.")]
	public class CF2GetMousePosition : FsmStateAction
	{
		[UIHint(UIHint.Variable)]
		public FsmFloat storeResultX;
		[UIHint(UIHint.Variable)]
		public FsmFloat storeResultY;
		[UIHint(UIHint.Variable)]
		public FsmVector2 storeResultVec2;
		[UIHint(UIHint.Variable)]
		public FsmVector3 storeResultVec3;

		public bool normalize;
		
		public override void Reset()
		{
			storeResultX = null;
			storeResultY = null;
			storeResultVec2 = null;
			storeResultVec3 = null;
			normalize = true;
		}

		public override void OnEnter()
		{
			DoGetMousePos();
		}

		public override void OnUpdate()
		{
			DoGetMousePos();
		}
		
		void DoGetMousePos()
			{
			Vector3 mousePos = ControlFreak2.CF2Input.mousePosition;
			if (this.normalize)
				{
				mousePos.x /= (float)Screen.width;
				mousePos.y /= (float)Screen.height;
				}

			if (this.storeResultX != null)
				this.storeResultX.Value = mousePos.x;

			if (this.storeResultY != null)
				this.storeResultY.Value = mousePos.y;

			if (this.storeResultVec2 != null)
				this.storeResultVec2.Value = new Vector2(mousePos.x, mousePos.y);

			if (this.storeResultVec3 != null)
				this.storeResultVec3.Value = mousePos;
	
			}
	}
}

