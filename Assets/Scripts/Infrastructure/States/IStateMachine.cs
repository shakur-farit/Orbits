using System;
using System.Collections.Generic;

namespace Infrastructure.States
{
	public interface IStateMachine
	{
		void Enter<TState>() where TState : IState;
		Dictionary<Type, IState> StatesDictionary { get; }
		IState ActiveState { get; }
	}
}