using System;
using System.Collections.Generic;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoadService;
using Infrastructure.Services.StaticData;
using UI.Services.Factory;
using UI.Services.Window;

namespace Infrastructure.States
{
	public class GameStateMachine
	{
		private readonly Dictionary<Type, IState> _statesDictionary;

		private IState _activeState;

		public GameStateMachine(StaticDataService staticDataService, PersistentProgressService progressService,
			ILoadService loadService, GameFactory gameFactory, UIFactory uiFactory, WindowService windowService)
		{
			_statesDictionary = new Dictionary<Type, IState>()
			{
				[typeof(LoadStaticDataState)] = new LoadStaticDataState(this, staticDataService),
				[typeof(LoadProgressState)] = new LoadProgressState(this, progressService, loadService),
				[typeof(LoadLevelState)] = new LoadLevelState(this, gameFactory, uiFactory),
				[typeof(GameLoopingState)] = new GameLoopingState(windowService)
			};
		}

		public void Enter<TState>() where TState : IState
		{
			_activeState?.Exit();
			IState state = _statesDictionary[typeof(TState)];
			_activeState = state;
			state.Enter();
		}
	}
}