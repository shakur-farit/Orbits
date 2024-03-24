using Infrastructure.Factory;
using UI.Services.Factory;

namespace Infrastructure.States
{
	public class LoadLevelState : IState
	{
		private readonly GameFactory _gameFactory;
		private readonly UIFactory _uiFactory;
		private readonly GameStateMachine _gameStateMachine;

		public LoadLevelState(GameStateMachine gameStateMachine, GameFactory gameFactory, UIFactory uiFactory)
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
			InitHero();
			InitAsteroids();
			InitSpawner();
			InitHud();
		}

		private void InitHero() =>
			_gameFactory.CreateHero();

		private void InitAsteroids()
		{
			_gameFactory.CreateBigAsteroid();
			_gameFactory.CreateMiddleAsteroid();
			_gameFactory.CreateSmallAsteroid();
		}

		private void InitSpawner() => 
			_gameFactory.CreateSpawner();

		private void InitHud() =>
			_gameFactory.CreateHud();

		private void InitUIRoot() =>
			_uiFactory.CreateUIRoot();
	}
}