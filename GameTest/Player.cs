using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameTest
{
	public class Player
	{
		public Texture2D texture;
		public Vector2 pos;
		public float rot;
		public Vector2 scale;
		public Vector2 size;
		int speed = 5;

		public Player(GraphicsDevice graphics, Vector2 size, Color color, Vector2 pos = default(Vector2), float rot = 0.0f, Vector2 scale = default(Vector2))
		{
			if (scale == default(Vector2))
			{
				scale = new Vector2(1, 1);
			}
			this.size = size;
			this.pos = pos;
			this.rot = rot;
			this.scale = scale;

			int area = (int)((size.X * scale.X)  * (size.Y * scale.Y));

			Color[] colorData = new Color[area];
			for (int i = 0; i < area; i++)
				colorData[i] = color;

			texture = new Texture2D(graphics, (int)(size.X * scale.X), (int)(size.Y * scale.Y));
			texture.SetData(colorData);
		}

		public Player(Texture2D texture, Vector2 pos = default(Vector2), float rot = 0.0f, Vector2 scale = default(Vector2), Vector2 size = default(Vector2))
		{
			if (size == default(Vector2))
			{
				size = new Vector2(texture.Width, texture.Height);
			}

			this.texture = texture;
			this.pos = pos;
			this.rot = rot;
			this.scale = scale;
			this.size = size;
		}

		public void updatePos(GraphicsDevice graphics){
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			if (Keyboard.GetState().IsKeyDown(Keys.A))
				pos.X -= speed;
			if (Keyboard.GetState().IsKeyDown(Keys.D))
				pos.X += speed;
			if (Keyboard.GetState().IsKeyDown(Keys.W))
				pos.Y -= speed;
			if (Keyboard.GetState().IsKeyDown(Keys.S))
				pos.Y += speed;

			if (pos.X > graphics.Viewport.Width - size.X)
				pos.X = graphics.Viewport.Width - size.X;
			if (pos.X < 0)
				pos.X = 0;
			if (pos.Y > graphics.Viewport.Height - size.Y)
				pos.Y = graphics.Viewport.Height - size.Y;
			if (pos.Y < 0)
				pos.Y = 0;
	}
}
