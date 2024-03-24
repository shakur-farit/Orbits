using Infrastructure.Services.StaticData;

namespace Infrastructure.States
{
	public class LoadStaticDataState : IState
	{
		private readonly StaticDataService _staticDataService;
		private readonly GameStateMachine _stateMachine;

		public LoadStaticDataState(GameStateMachine stateMachine, StaticDataService staticDataService)
		{
			_stateMachine = stateMachine;
			_staticDataService = staticDataService;
		}

		public void Enter()
		{
			LoadStaticData();
			EnterLoadProgress();
		}

		private void EnterLoadProgress() => 
			_stateMachine.Enter<LoadProgressState>();

		public void Exit()
		{
		}

		private void LoadStaticData() =>
			_staticDataService.Load();
	}
}