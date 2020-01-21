using System.Collections.Generic;
using Armageddon.SceneManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Armageddon
{
    public class Game1 : Game
    {
        private Manager manager;
        
        public Game1()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            manager = new Manager( this, null, new List<string>() );
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            this.manager.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            
            this.manager.LoadContentOfStack();
        }

        protected override void Update(GameTime gameTime)
        {
            // if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            //     Keyboard.GetState().IsKeyDown(Keys.Escape))
            //     Exit();
            
            this.manager.Update(gameTime);
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // GraphicsDevice.Clear(Color.CornflowerBlue);
            
            this.manager.Draw(gameTime, Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}