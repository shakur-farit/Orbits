using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
	public abstract class WindowBase : MonoBehaviour
	{
		public Button CloseButton;

		private void Awake() => 
			OnAwake();

		protected abstract void OnAwake();

		protected void CloseWindow() => 
			Destroy(gameObject);
	}
}
