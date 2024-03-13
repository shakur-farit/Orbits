using UI.Services.Factory;

namespace UI.Services.Window
{
	public class WindowService : IWindowService
	{
		private readonly IUIFactory _uiFactory;

		public WindowService(IUIFactory uiFactory) => 
			_uiFactory = uiFactory;

		public void Open(WindowId windowId)
		{
			switch (windowId)
			{
				case WindowId.None:
					break;
				case WindowId.Main:
					_uiFactory.CreateMainMenuWindow(_uiFactory.UIRoot);
					break;
				case WindowId.GameOver:
					_uiFactory.CreateGameOverWindow(_uiFactory.UIRoot);
					break;
			}
		}
	}
}
