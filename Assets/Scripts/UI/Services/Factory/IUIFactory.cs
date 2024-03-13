using UnityEngine;

namespace UI.Services.Factory
{
	public interface IUIFactory
	{
		Transform UIRoot { get; }
		void CreateGameOverWindow(Transform parentTransform);
		void CreateUIRoot();
		void CreateMainMenuWindow(Transform parentTransform);
	}
}