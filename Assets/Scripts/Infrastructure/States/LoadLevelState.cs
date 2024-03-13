using Infrastructure.Factory;
using UI.Services.Factory;

namespace Infrastructure.States
{
	public class LoadLevelState : IState
	{
		private readonly IGameFactory _gameFactory;
		private readonly IUIFactory _uiFactory;
		private readonly GameStateMachine _gameStateMachine;

		public LoadLevelState(GameStateMachine gameStateMachine, IGameFactory gameFactory, IUIFactory uiFactory)
		{
			_gameStateMachine = gameStateMachine;
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
		}

		public void Enter()
		{
			InitObjects();
			_gameStateMachine.Enter<GameLoopingState>();
		}

		public void Exit()
		{
		}

		public void InitObjects()
		{
			InitGameObjects();
			InitUIRoot();
		}

		private void InitGameObjects()
		{
			InitBubble();
			InitNeedle();
			InitDebuffSpawner();
			InitHud();
		}

		private void InitBubble() =>
			_gameFactory.CreateBubble();

		private void InitNeedle() =>
			_gameFactory.CreateNeedle();

		private void InitDebuffSpawner() => 
			_gameFactory.CreateDebuffSpawner();

		private void InitHud() =>
			_gameFactory.CreateHud();

		private void InitUIRoot() =>
			_uiFactory.CreateUIRoot();
	}
}