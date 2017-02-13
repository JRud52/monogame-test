﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace GameTest
{
	public class Player : AnimSprite
	{
		public int health { get; set; }
		public int walk_speed { get; set; }
		public int run_speed { get; set; }

		int walkDownAnimIndex;
		int walkLeftAnimIndex;
		int walkRightAnimIndex;
		int walkUpAnimIndex;

		Animation walkDownAnim;
		Animation walkLeftAnim;
		Animation walkRightAnim;
		Animation walkUpAnim;


		public Player (ContentManager content, SpriteBatch batch, string texture, Vector2 frameSize, 
					  Vector2 pos = default(Vector2), float rot = 0.0f, Vector2 scale = default(Vector2)) 
			: base(content, batch, texture, frameSize, pos, rot, scale)
		{
			health = 100;
			walk_speed = 3;
			run_speed = 5;

			walkDownAnimIndex = 0;
			walkLeftAnimIndex = 1;
			walkRightAnimIndex = 2;
			walkUpAnimIndex = 3;

			walkDownAnim = new Animation(new Vector2(0, 49), new Vector2(16, 16), 3, 100);
			walkLeftAnim = new Animation(new Vector2(48, 49), new Vector2(16, 16), 3, 100);
			walkRightAnim = new Animation(new Vector2(96, 49), new Vector2(16, 16), 3, 100);
			walkUpAnim = new Animation(new Vector2(144, 49), new Vector2(16, 16), 3, 100);

			animList.Add(walkDownAnim);
			animList.Add(walkLeftAnim);
			animList.Add(walkRightAnim);
			animList.Add(walkUpAnim);

		}

		public void updateAnim()
		{
			KeyboardState state = Keyboard.GetState();

			//if (state.IsKeyDown(Keys.LeftShift) || state.IsKeyDown(Keys.RightShift))
			//currentAnim = runAnim;
			if (state.IsKeyDown(Keys.A))
			{
				animList[currentAnim].Stop();
				currentAnim = walkLeftAnimIndex;
				animList[currentAnim].Play();
			}
			if (state.IsKeyDown(Keys.D))
			{
				animList[currentAnim].Stop();
				currentAnim = walkRightAnimIndex;
				animList[currentAnim].Play();
			}
			if (state.IsKeyDown(Keys.W))
			{
				animList[currentAnim].Stop();
				currentAnim = walkUpAnimIndex;
				animList[currentAnim].Play();
			}
			if (state.IsKeyDown(Keys.S))
			{
				animList[currentAnim].Stop();
				currentAnim = walkDownAnimIndex;
				animList[currentAnim].Play();
			}

			if (!state.IsKeyDown(Keys.A) && !state.IsKeyDown(Keys.W) && !state.IsKeyDown(Keys.S) && !state.IsKeyDown(Keys.D))
			{
				animList[currentAnim].Stop();
			}
		}
	}
}
