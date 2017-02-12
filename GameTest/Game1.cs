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
		Level level;
		Hud hud;

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

			player = new Player(Content, spriteBatch, "sprites/sprite", 
			                    new Vector2(50, 50),
			                    0, new Vector2(0.5f, 0.5f) );
			player.layer = 0.5f;

			hud = new Hud(Content, graphics, spriteBatch);

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

				level.updatePos();

				base.Update(gameTime);
			}
		}

		// draws the graphics to the window
		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack);
			player.Draw();
			level.Draw();
			hud.Draw();
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
