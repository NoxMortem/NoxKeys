using System;
using UnityEngine;

namespace Infrastructure.NoxKeys
{
	public static partial class SmartKeys
	{
		/// <summary>
		/// A Functor provides a set of input verification on KeyCodes.
		/// Common functors are Get (Input.GetKey), 
		/// </summary>
		public abstract partial class Functor
		{
			private readonly Func<KeyCode, bool> func;

			protected Functor(Func<KeyCode, bool> func)
			{
				this.func = func;
				All = new AllVerifier(this);
				Any = new AnyVerifier(this);
			}

			public bool Check(Func<Functor, bool> mapping) => mapping.Invoke(this);

			public readonly AllVerifier All;
			public readonly AnyVerifier Any;

			public bool Key(KeyCode key) => func.Invoke(key);
			public bool Apple => Check(Mapping.Apple);
			public bool Win => Check(Mapping.Win);
			public bool Alt => Check(Mapping.Alt);
			public bool Shift => Check(Mapping.Shift);
			public bool Ctrl => Check(Mapping.Ctrl);
			public bool Enter => Check(Mapping.Enter);
			public bool Delete => Check(Mapping.Delete);
			public bool Union => Check(Mapping.Union);
			public bool DragCamera => Check(Mapping.DragCamera);
			public bool Redo => Check(Mapping.Redo);
			public bool Undo => Check(Mapping.Undo);
			public bool Save => Check(Mapping.Save);
			public bool Copy => Check(Mapping.Copy);
			public bool Paste => Check(Mapping.Paste);
			public bool OpenScene => Check(Mapping.OpenScene);
			public bool Screenshot => Check(Mapping.Screenshot);
			public bool Help => Check(Mapping.Help);
			public bool Group => Check(Mapping.Group);
		}

		public class GetFunctor : Functor
		{
			public GetFunctor() : base(Input.GetKey) {}
		}

		public class GetKeyDownFunc : Functor
		{
			public GetKeyDownFunc() : base(Input.GetKeyDown) {}
		}

		public class GetKeyUpFunc : Functor
		{
			public GetKeyUpFunc() : base(Input.GetKeyUp) {}
		}
	}
}