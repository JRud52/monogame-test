using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameTest
{
	public class Game1 : Game
	{
		readonly GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Player player;
		LevelManager level;
		Hud hud;

		// initialize window settings
		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

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
								new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2),
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

		// when window has focus
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

				level.updatePos();
				player.updateAnim();

				base.Update(gameTime);
			}
		}

		// draws the graphics to the window
		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin(SpriteSortMode.FrontToBack);
			player.Draw(gameTime);
			level.Draw();
			hud.Draw();
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
