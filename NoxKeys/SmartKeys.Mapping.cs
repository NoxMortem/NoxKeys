using Infrastructure.Hardware.Mouse;
using UnityEngine;

namespace Infrastructure.NoxKeys
{
	public static partial class SmartKeys
	{
		public static class Mapping
		{
			public static bool Apple(Functor check) =>
				check.Any.Key(KeyCode.LeftApple, KeyCode.RightApple, KeyCode.LeftWindows, KeyCode.RightWindows);

			public static bool Win(Functor check) => Apple(check);

			public static bool Alt(Functor check) => check.Any.Key(KeyCode.LeftAlt, KeyCode.RightAlt);
			public static bool Shift(Functor check) => check.Any.Key(KeyCode.LeftShift, KeyCode.RightShift);

			public static bool Ctrl(Functor check)
			{
#if UNITY_EDITOR
				return check.Key(KeyCode.Comma);
#elif UNITY_STANDALONE_OSX
				return check.Any.Key(KeyCode.LeftCommand, KeyCode.RightCommand);		
#else
				return check.Any.Key(KeyCode.LeftControl, KeyCode.RightControl);
#endif
			}

			public static bool Delete(Functor check) => check.Any.Key(KeyCode.Delete, KeyCode.Backspace);

			public static bool Union(Functor check) => check.Any.Key(KeyCode.LeftShift, KeyCode.RightShift);

			public static bool DragCamera(Functor check)
			{
#if UNITY_STANDALONE_OSX
				return check.All.Key(KeyCode.LeftCommand, KeyCode.LeftAlt) && Input.GetMouseButton(1);
#else
				return check.All.Key(KeyCode.LeftControl, KeyCode.LeftAlt) && Input.GetMouseButton(1)
				    || Input.GetMouseButton(2);
#endif
			}

			public static bool Redo(Functor check) => Modifier.Ctrl && check.All.Key(KeyCode.Y);
			public static bool Undo(Functor check) => Modifier.Ctrl && check.All.Key(KeyCode.Z);
			public static bool Save(Functor check) => Modifier.Ctrl && check.All.Key(KeyCode.S);

			public static bool Copy(Functor check) => Modifier.Ctrl && check.All.Key(KeyCode.C);
			public static bool Paste(Functor check) => Modifier.Ctrl && check.All.Key(KeyCode.V);

			public static bool OpenScene(Functor check) => Modifier.Ctrl && check.All.Key(KeyCode.O);

			public static bool Screenshot(Functor check) => check.All.Key(KeyCode.F12);
			public static bool Help(Functor check) => check.All.Key(KeyCode.F1);

			public static bool Cancel(Functor check) => check.All.Key(KeyCode.Escape);

			public static bool CameraForward(Functor check) => check.All.Key(KeyCode.W);
			public static bool CameraBackward(Functor check) => check.All.Key(KeyCode.S);
			public static bool CameraLeft(Functor check) => check.All.Key(KeyCode.A);
			public static bool CameraRight(Functor check) => check.All.Key(KeyCode.D);

			public static bool CameraFlight(Functor check) => Mouse.Button.Get.Right;

			public static bool LeftShift(Functor check) => check.All.Key(KeyCode.LeftShift);

			public static bool Enter(Functor check) => check.All.Key(KeyCode.Return);
			public static bool Group(Functor check) => check.All.Key(KeyCode.G);
		}
	}
}