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
        List<MenuItem> menuItems = new List<MenuItem>();
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
            var menuItem = new MenuItem("newgame", new Rectangle(0, 0, 100, 100));
            menuItem.LoadContent(new string[] { "Play", "Play_Click", "Play_Hover" });
            menuItem.Click += menuItemClick;
            menuItems.Add(menuItem);
        }

        public void UnloadContent()
        {
            for (int i = 0; i < menuItems.Count; i++)
            {
                menuItems[i].UnloadContent();
            }
        }

        public void Update()
        {
            for (int i = 0; i < menuItems.Count; i++)
            {
                menuItems[i].Update();
            }
        }

        public void Draw()
        {
            for (int i = 0; i < menuItems.Count; i++)
            {
                menuItems[i].Draw();
            }
        }

        public void menuItemClick(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                if (menuItem.Name.Equals("newgame"))
                {
                    // Xử lý new game
                    int a = 1;
                }

                // ...
            }
        }
    }
}
