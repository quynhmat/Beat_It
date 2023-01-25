using UnityEngine;

namespace HutongGames.PlayMaker.Actions.CF2
	{
    public abstract class ComponentActionEx<T> : FsmStateAction where T : Component
	    {
        private GameObject cachedGameObject;
        private T component;


		public T targetComponent
			{
			get { return this.component; } 
			}

        protected bool UpdateCache(GameObject go)
        {
            if (go == null)
            {
                return false;
            }

            if (component == null || cachedGameObject != go)
            {
                component = go.GetComponent<T>();
                cachedGameObject = go;

                if (component == null)
                {
                    LogWarning("Missing component: " + typeof(T).FullName + " on: " + go.name);
                }
            }

            return component != null;
        }
    }
}