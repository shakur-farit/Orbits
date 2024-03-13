using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoadService;

namespace Infrastructure.States
{
	public class LoadProgressState : IState
	{
		private readonly GameStateMachine _stateMachine;
		private readonly IPersistentProgressService _progressService;
		private readonly ILoadService _loadService;

		public LoadProgressState(GameStateMachine stateMachine, IPersistentProgressService progressService, ILoadService loadService)
		{
			_stateMachine = stateMachine;
			_progressService = progressService;
			_loadService = loadService;
		}

		public void Enter()
		{ 
			LoadProgressOrInitNew();
			_stateMachine.Enter<LoadLevelState>();
		}

		public void Exit()
		{
		}

		private void LoadProgressOrInitNew() =>
			_progressService.Progress = _loadService.LoadProgress() ?? InitNewProgress();

		private Progress InitNewProgress() =>
			new();
	}
}