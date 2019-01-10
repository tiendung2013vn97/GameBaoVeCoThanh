using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBaoVeCoThanh
{
    class Dialog
    {
        Texture2D background;
        List<MenuItem> list;
        String content;
        float left, right, width, height;
        bool visible = false;

        public bool Visible { get => this.visible; set => this.visible = value; }

        public Dialog(Rectangle rectangle)
        {
            this.left = rectangle.Left;
            this.right = rectangle.Right;
            this.width = rectangle.Width;
            this.height = rectangle.Height;
        }

        public void LoadContent()
        {
            background = GameControl.g.Content.Load<Texture2D>("Dialog/Backgournd");

            createMenuItem("", new Rectangle(0, 0, 100, 100), "continue", new string[] { "Play", "Play_Click", "Play_Hover" });

            for (int i = 0; i < list.Count; i++)
            {
                list[i].LoadContent();
            }
        }

        public void UnloadContent()
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].UnloadContent();
            }
        }

        public void Update()
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Update();
            }
        }

        public void Draw()
        {
            GameControl.sb.Draw(background, new Rectangle((int)left, (int)right, (int)width, (int)height), Color.White);

            for (int i = 0; i < list.Count; i++)
            {
                list[i].Draw();
            }
        }

        public void createMenuItem(string name, Rectangle rectangle, string state, string[] imgsPath) // name là nội dung của menuItem
        {
            MenuItem menuItem = new MenuItem(name, rectangle, state, imgsPath);
            menuItem.Click += handleCLick;
            list.Add(menuItem);
        }

        public void handleCLick(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                if (menuItem.State.Equals("continue"))
                {
                    // Xử lý continue
                }

                if (menuItem.State.Equals("exitgame"))
                {
                    // Xử lý exitgame
                }
            }
        }
    }
}
