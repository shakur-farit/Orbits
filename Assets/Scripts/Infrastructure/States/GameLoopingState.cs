using UI.Services.Window;

namespace Infrastructure.States
{
	public class GameLoopingState : IState
	{
		private readonly WindowService _windowService;

		public GameLoopingState(WindowService windowService) => 
			_windowService = windowService;

		public void Enter() =>
			OpenMainMenuWindow();

		public void Exit()
		{
		}

		private void OpenMainMenuWindow() => 
			_windowService.Open(WindowId.Main);
	}
}