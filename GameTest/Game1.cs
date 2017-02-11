using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameTest
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Player player;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			IsFixedTimeStep = true;
			graphics.SynchronizeWithVerticalRetrace = true;
			TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 33); // 33ms = 30fps
		}

		// initialize non-graphic content here
		protected override void Initialize()
		{
			base.Initialize();
		}

		// load all the content
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			player = new Player(Content, "sprites/sprite", new Vector2(100,100));

		}

		//unload all the content
		protected override void UnloadContent()
		{
			Content.Unload();
			base.UnloadContent();
		}

		//when window has focus
		protected override void OnActivated(object sender, EventArgs args)
		{
			Window.Title = "Active Application";
			base.OnActivated(sender, args);
		}

		// when window does not have focus
		protected override void OnDeactivated(object sender, EventArgs args)
		{
			Window.Title = "InActive Application";
			base.OnDeactivated(sender, args);
		}

		// update loop
		protected override void Update(GameTime gameTime)
		{
			if (IsActive)
			{
				if (Keyboard.GetState().IsKeyDown(Keys.Escape))
					Exit();

				player.updatePos();

				base.Update(gameTime);
			}
		}

		// draws the graphics to the window
		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();
			spriteBatch.Draw(player.texture, player.pos);
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
