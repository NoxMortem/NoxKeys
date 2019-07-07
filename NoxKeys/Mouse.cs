using System;
using UnityEngine;

// ReSharper disable MemberHidesStaticFromOuterClass

// Library
// ReSharper disable UnusedMember.Global

namespace Infrastructure.NoxKeys
{
    public static class Mouse
    {
        public static class Cursor
        {
            public static class Movement
            {
                public static float DeltaX => Input.GetAxis("Mouse X");
                public static float DeltaY => Input.GetAxis("Mouse Y");
            }

            public static bool Inside(RectTransform rectTransform) =>
                RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Position);

            public static bool Outside(RectTransform rectTransform) => !Inside(rectTransform);

            public static bool OnScreen()
            {
                var input = Input.mousePosition;
                return input.x >= 0 && input.x <= Screen.width && input.y >= 0 && input.y <= Screen.height;
            }

            public static Vector2 ClampedToScreenPos()
            {
                var input = Input.mousePosition;
                return new Vector2(Mathf.Clamp(input.x, 0, Screen.width), Mathf.Clamp(input.y, 0, Screen.height));
            }

            public static Vector2 Position => Input.mousePosition;
        }

        public static class Button
        {
            public const int Left = 0;
            public const int Right = 1;
            public const int Middle = 2;

            public static readonly InputChecker GetUp = new InputChecker(Input.GetMouseButtonUp);
            public static readonly InputChecker Get = new InputChecker(Input.GetMouseButton);
            public static readonly InputChecker GetDown = new InputChecker(Input.GetMouseButtonDown);
            public static readonly Modifier Mod = new Modifier();

            public class Modifier
            {
                public static bool Left => Check(Button.Left);
                public static bool Right => Check(Button.Right);
                public static bool Middle => Check(Button.Middle);

                private static bool Check(int buttonKey) =>
                    Input.GetMouseButtonDown(buttonKey) || Input.GetMouseButton(buttonKey) || Input.GetMouseButtonUp(buttonKey);
            }

            public class InputChecker
            {
                private readonly Func<int, bool> functor;

                public InputChecker(Func<int, bool> functor)
                {
                    this.functor = functor;
                }

                public bool Left => functor.Invoke(Button.Left);
                public bool Right => functor.Invoke(Button.Right);
                public bool Middle => functor.Invoke(Button.Middle);
            }
        }
    }
}