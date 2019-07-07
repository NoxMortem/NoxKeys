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
		public static class Modifier
		{
			public static bool Check(Func<Functor, bool> mapping) =>
				GetDown.Check(mapping) || Get.Check(mapping) || GetUp.Check(mapping);

			public static bool Key(KeyCode key) => GetDown.Key(key) || Get.Key(key) || GetUp.Key(key);

			public static bool Ctrl => Check(Mapping.Ctrl);
			public static bool Alt => Check(Mapping.Alt);
			public static bool Shift => Check(Mapping.Shift);
			public static bool AltShift => Check(Mapping.Alt) && Check(Mapping.Shift);
			public static bool CtrlAlt => Check(Mapping.Alt) && Check(Mapping.Ctrl);
			public static bool AltShiftCtrl => Check(Mapping.Alt) && Check(Mapping.Shift) && Check(Mapping.Ctrl);
			public static bool Win => Check(Mapping.Win);
			public static bool Apple => Check(Mapping.Apple);
			public static bool Delete => Check(Mapping.Delete);
			public static bool Union => Check(Mapping.Union);
			public static bool DragCamera => Check(Mapping.DragCamera);
			public static bool Redo => Check(Mapping.Redo);
			public static bool Undo => Check(Mapping.Undo);
			public static bool Save => Check(Mapping.Save);
			public static bool Copy => Check(Mapping.Copy);
			public static bool Paste => Check(Mapping.Paste);
			public static bool OpenScene => Check(Mapping.OpenScene);
			public static bool Screenshot => Check(Mapping.Screenshot);
			public static bool Help => Check(Mapping.Help);
		}
	}
}