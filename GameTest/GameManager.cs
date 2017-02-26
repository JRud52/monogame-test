using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameTest
{
	public class GameManager : Game
	{
		readonly GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		LevelManager level;

		Player player;
		Hud hud;

		// initialize window settings
		public GameManager()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			Window.Title = "Game Title";

			IsMouseVisible = true;
			IsFixedTimeStep = true;
			graphics.SynchronizeWithVerticalRetrace = true;
			TargetElapsedTime = new TimeSpan(0, 0, 0, 0, 17); // 33ms = 30fps, 16.67ms = 60fps
		}

		// initialize non-graphic content here
		protected override void Initialize()
		{
			base.Initialize();
		}

		// load all the graphical content
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			player = new Player(Content, spriteBatch, "sprites/charactersheet",
								new Vector2(16, 16),
								new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2),
								0, new Vector2(1.5f, 1.5f));
			player.layer = 0.5f;

			level = new LevelManager(Content, graphics, spriteBatch, player);

			hud = new Hud(Content, graphics, spriteBatch, player);
		}

		// unload all the content
		protected override void UnloadContent()
		{
			Content.Unload();
			base.UnloadContent();
		}

		// update loop
		protected override void Update(GameTime gameTime)
		{
			if (IsActive)
			{
				if (Keyboard.GetState().IsKeyDown(Keys.Escape))
					Exit();

				level.Update();
				player.UpdateAnim();

				base.Update(gameTime);
			}
		}

		// draws the graphics to the window
		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin(SpriteSortMode.FrontToBack);

			level.Draw();
			player.Draw(gameTime);
			hud.Draw();

			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
