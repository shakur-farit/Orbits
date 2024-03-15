using System;
using System.Collections.Generic;

namespace Infrastructure.States
{
	public abstract class StateMachine
	{
		public Dictionary<Type, IState> StatesDictionary { get; set; }

		public IState ActiveState { get; set; }

		public void Enter<TState>() where TState : IState
		{
			ActiveState?.Exit();
			IState state = StatesDictionary[typeof(TState)];
			ActiveState = state;
			state.Enter();
		}
	}
}