using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBaoVeCoThanh
{
    class Menu
    {
        List<MenuItem> list = new List<MenuItem>();
        float left, top, width, height;

        public Menu(Rectangle rectangle)
        {
            this.left = rectangle.Left;
            this.top = rectangle.Top;
            this.width = rectangle.Width;
            this.height = rectangle.Height;
        }

        public void LoadContent()
        {
            createMenuItem("", new Rectangle(0, 0, 100, 100), "newgame", new string[] { "Play", "Play_Click", "Play_Hover" });

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

        //Sau khi click, kiểm tra nếu là newgame thì bắt đầu game từ level 1
        public void handleCLick(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                if (menuItem.State.Equals("newgame"))
                {
                    // Xử lý new game
                }

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
