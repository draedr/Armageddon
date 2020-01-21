using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Armageddon.SceneManager.Screens
{
    public class TestScreen : Screen
    {
        public TestScreen(Manager manager) : base(manager) { }

        public void LoadContent()
        {
            contentManager.Load<Texture2D>("GlitchAi");
        }

        public void Update(GameTime gt)
        {
            
        }

        public void Draw(GameTime gt)
        {
            
        }
    }
}