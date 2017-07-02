﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MMXEngine.Windows.Editor.Contracts
{
	public interface IEditorInputManager
	{
		void Register(EditorGame game);

		bool IsPressed(Keys key);
		bool IsDown(Keys key);
		bool IsUp(Keys key);
		bool WasDownLastFrame(Keys key);
		bool WasUpLastFrame(Keys key);
		void Update();

		bool IsLeftMouseDown();
		bool IsLeftMouseUp();

		bool IsRightMouseDown();
		bool IsRightMouseUp();

		bool IsLeftMousePressed();
		bool IsRightMousePressed();

		Vector2 GetMousePosition();
	}
}
