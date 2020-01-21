using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Armageddon.SceneManager
{
    public enum ScreenState
    {
        Active,
        Background,
        Hovered,
        Hovering,
        Transitioning
    }
    
    public class Screen
    {
        // Reference to the Screen name inside Manager.ScreensMap
        public string name;
        // State of the screen
        public ScreenState state;
        // Percentage of the transition; Should be set 0 when stopped
        public int transitionPercentage;
        // Should this screen be updated while hovered or in background?
        public bool updateAlways = false;
        // Reference to the manager
        public Manager manager;
        // Screens' ContentManager
        public ContentManager contentManager;

        public Screen(Manager manager)
        {
            this.manager = manager;

            transitionPercentage = 0;
        }

        public void LoadContent()
        {
            // contentManager.Load<string>("");
        }
        
        public void Update (GameTime gt) {}
        
        public void Draw (GameTime gt) {}

        public void Unload()
        {
            contentManager.Unload();
        }
    }
}