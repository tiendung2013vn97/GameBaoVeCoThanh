using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBaoVeCoThanh
{
    class CustomPointer
    {
        Texture2D pointer;
        public CustomPointer()
        {
            pointer = GameControl.g.Content.Load<Texture2D>("pointer");
        }
        public void ChangeImage(string img)
        {
            pointer = GameControl.g.Content.Load<Texture2D>("pointer");
        }
        public void Draw()
        {
            GameControl.sb.Draw(pointer, new Vector2(Mouse.GetState().X, Mouse.GetState().Y),null,Color.White,
                0f,new Vector2(0,0),1,SpriteEffects.None,0.01f);
        }
    }
}
