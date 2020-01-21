using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Armageddon.SceneManager
{
    public class Manager
    {
        // Map of the initialized screens
        Dictionary<string, Screen> screensMap = new Dictionary<string,Screen>();
        // Stack of screens to be rendered.
        List<string> screensStack = new List<string>();
        // Reference to your Game object
        private Game1 game;
        
        // Graphics Manager
        GraphicsDeviceManager graphics;

        public Manager( Game1 game, Dictionary<string, Screen> screensMap, List<string> screensStack )
        {
            this.screensMap = screensMap;
            this.screensStack = screensStack;
            this.game = game;
        }
        
        public Manager( Game1 game, Dictionary<string, Screen> screensMap, string screensStack )
        {
            this.screensMap = screensMap;
            this.screensStack = new List<string>(){screensStack};
            this.game = game;
        }

        public void Initialize()
        {
            graphics = new GraphicsDeviceManager(this.game);
        }
        
        public void LoadContentOfStack()
        {
            foreach ( string screenKey in this.screensStack )
                this.screensMap[screenKey].LoadContent();
        }
        
        public void Update (GameTime gt) {
            foreach (string screenKey in this.screensStack)
            {
                if (this.screensMap[screenKey].state == ScreenState.Background || !this.screensMap[screenKey].updateAlways )
                    continue;
                else
                    this.screensMap[screenKey].Update(gt);
            }
        }

        public void Draw(GameTime gt)
        {
            foreach( string screenKey in this.screensStack )
            {
                this.game.GraphicsDevice.Clear(Color.CornflowerBlue);
                
                if (this.screensMap[screenKey].state == ScreenState.Background)
                    continue;
                else
                    this.screensMap[screenKey].Draw(gt);
            }
        }

        public void Draw(GameTime gt, Color ClearColor)
        {
            foreach( string screenKey in this.screensStack )
            {
                this.game.GraphicsDevice.Clear(ClearColor);
                
                if (this.screensMap[screenKey].state == ScreenState.Background)
                    continue;
                else
                    this.screensMap[screenKey].Draw(gt);
            }
        }
        
        // Get the top screen of the stack
        public Screen screen()
        {
            return this.screensMap[this.screensStack[-1]];
        }
        
        // Change state of the top screen in the stack to background, then put the new screen on top, changing it's state to Active, and finally call LoadContent on the screen.
        public void Move(string topScreen)
        {
            if (this.screen().state == ScreenState.Active)
                this.screen().state = ScreenState.Background;
            
            this.screensStack.Add(topScreen);
            this.screen().state = ScreenState.Active;
            
            this.screen().LoadContent();;
        }
        
        // Change state of the top screen in the stack to hovered, then put the new screen on top, changing it's state to hovering, and finally call LoadContent on the screen.
        public void MoveToHover(string topScreen)
        {
            if (this.screen().state == ScreenState.Active)
                this.screen().state = ScreenState.Hovered;
            
            this.screensStack.Add(topScreen);
            this.screen().state = ScreenState.Hovering;
            
            this.screen().LoadContent();;
        }
       
        // Pop top screen out of the stack than change top screen state accordingly
        public bool MoveBack()
        {
            if (this.screensStack.Count == 1)
                return false;
            
            this.screensStack.RemoveAt(-1);
            
            if (this.screen().state == ScreenState.Hovered || this.screen().state == ScreenState.Background )
                this.screen().state = ScreenState.Active;

            return true;
        }
        
        // Clear the stack, add the new screen, and finally call LoadContent.
        public void EmptyStack(string firstScreen)
        {
            this.screensStack = new List<string>() {firstScreen};
            
            this.screen().LoadContent();;
        }
    }
    
}