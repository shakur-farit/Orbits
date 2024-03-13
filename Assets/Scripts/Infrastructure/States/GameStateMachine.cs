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
	public class GameStateMachine : IStateMachine
	{
		public Dictionary<Type, IState> StatesDictionary { get; }

		public IState ActiveState { get; private set; }

		public GameStateMachine(IStaticDataService staticDataService, IPersistentProgressService progressService,
			ILoadService loadService, IGameFactory gameFactory, IUIFactory uiFactory, IWindowService windowService)
		{
			StatesDictionary = new Dictionary<Type, IState>()
			{
				[typeof(LoadStaticDataState)] = new LoadStaticDataState(this, staticDataService),
				[typeof(LoadProgressState)] = new LoadProgressState(this, progressService, loadService),
				[typeof(LoadLevelState)] = new LoadLevelState(this, gameFactory, uiFactory),
				[typeof(GameLoopingState)] = new GameLoopingState(windowService)
			};
		}

		public void Enter<TState>() where TState : IState
		{
			ActiveState?.Exit();
			IState state = StatesDictionary[typeof(TState)];
			ActiveState = state;
			state.Enter();
		}
	}
}