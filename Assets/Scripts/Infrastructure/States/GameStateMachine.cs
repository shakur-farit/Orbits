using System;
using System.Collections.Generic;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoadService;
using Infrastructure.Services.StaticData;
using UI.Services.Factory;
using UI.Services.Window;
using UnityEngine;

namespace Infrastructure.States
{
	public class GameStateMachine : StateMachine
	{
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
	}
}