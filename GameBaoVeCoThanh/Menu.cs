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
    class Menu
    {
        Texture2D background, window;
        Dialog dialog;
        List<MenuItem> menuItems = new List<MenuItem>();
        SpriteFont title, text;
        float left, top, width, height;
        bool visible = false;
        bool isReleased = false;

        public bool Visible { get => this.visible; set => this.visible = value; }

        public Menu(Rectangle rectangle, bool visible)
        {
            this.left = rectangle.Left;
            this.top = rectangle.Top;
            this.width = rectangle.Width;
            this.height = rectangle.Height;
            this.visible = visible;
        }

        public void LoadContent()
        {
            // dialog
            dialog = new Dialog(new Rectangle(0, 0, 0, 0), false);
            dialog.LoadContent();

            // font
            title = GameControl.g.Content.Load<SpriteFont>("font/title");
            text = GameControl.g.Content.Load<SpriteFont>("font/title");

            // background
            background = GameControl.g.Content.Load<Texture2D>("menu/background");
            window = GameControl.g.Content.Load<Texture2D>("menu/item/window");

            // menu item
            createMenuItem("continue", new Rectangle((int)((width - 170) / 2), 100, 170, 70), "Tiep tuc",
                            new string[] { "menu/item/text/normal", "menu/item/text/normal", "menu/item/text/hover" });
            createMenuItem("newgame", new Rectangle((int)((width - 170) / 2), 200, 170, 70), "Choi moi", 
                            new string[] { "menu/item/text/normal", "menu/item/text/normal", "menu/item/text/hover" });

            //createMenuItem("maps", new Rectangle((int)((width - 80) / 2) - 90, 300, 80, 80), "", 
            //                new string[] { "menu/item/maps/normal", "menu/item/maps/normal", "menu/item/maps/hover" });
            //createMenuItem("setting", new Rectangle((int)((width - 80) / 2), 300, 80, 80), "", 
            //                new string[] { "menu/item/setting/normal", "menu/item/setting/normal", "menu/item/setting/hover" });
            //createMenuItem("exit", new Rectangle((int)((width - 80) / 2) + 90, 300, 80, 80), "",
            //                new string[] { "menu/item/exit/normal", "menu/item/exit/normal", "menu/item/exit/hover" });

            createMenuItem("setting", new Rectangle((int)((width - 80) / 2) - 50, 300, 80, 80), "",
                            new string[] { "menu/item/setting/normal", "menu/item/setting/normal", "menu/item/setting/hover" });
            createMenuItem("exit", new Rectangle((int)((width - 80) / 2) + 50, 300, 80, 80), "",
                            new string[] { "menu/item/exit/normal", "menu/item/exit/normal", "menu/item/exit/hover" });

            for (int i = 0; i < menuItems.Count; i++)
            {
                menuItems[i].LoadContent();
            }
        }

        public void UnloadContent()
        {
            for (int i = 0; i < menuItems.Count; i++)
            {
                menuItems[i].UnloadContent();
            }

            dialog.UnloadContent();
        }

        public void Update()
        {
            if (this.visible && !dialog.Visible)
            {
                MouseState ms = Mouse.GetState();

                if (ms.LeftButton == ButtonState.Released)
                {
                    isReleased = true;
                }

                if (isReleased)
                {
                    for (int i = 0; i < menuItems.Count; i++)
                    {
                        menuItems[i].Update();
                    }
                }
            }
            else
            {
                isReleased = false;
            }

            if (dialog.Visible) dialog.Update();
        }

        public void Draw()
        {
            if (this.visible)
            {
                // background
                GameControl.sb.Draw(background, new Rectangle((int)left, (int)top, (int)width, (int)height), Color.White);
                GameControl.sb.Draw(window, new Rectangle((int)(width / 4), 0, (int)(width / 2), (int)height), Color.White);

                for (int i = 0; i < menuItems.Count; i++)
                {
                    menuItems[i].Draw();
                }

                // font
                GameControl.sb.DrawString(title, "Bao ve co thanh", new Vector2(width / 4 + 120, 15), Color.Black);
            }

            if (dialog.Visible) dialog.Draw();
        }

        public void createMenuItem(string name, Rectangle rectangle, string state, string[] imgsPath) // name là nội dung của menuItem
        {
            MenuItem menuItem = new MenuItem(name, rectangle, state, imgsPath, true);
            menuItem.Click += handleClick;
            menuItem.Click += dialog.handleClick;
            dialog.Result += handleResult;
            menuItems.Add(menuItem);
        }

        //Sau khi click, kiểm tra nếu là newgame thì bắt đầu game từ level 1
        public void handleClick(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                if (menuItem.Name.Equals("continue"))
                {
                    // Xử lý khi click continue
                    //dialog.Visible = true;
                }

                if (menuItem.Name.Equals("newgame"))
                {
                    // Xử lý khi click new game
                    dialog.Visible = true;
                }

                //if (menuItem.Name.Equals("maps"))
                //{
                //    // Xử lý khi click danh sach màn chơi
                //    dialog.Visible = true;
                //}

                if (menuItem.Name.Equals("setting"))
                {
                    // Xử lý khi click cài đặt
                    dialog.Visible = true;
                }

                if (menuItem.Name.Equals("exit"))
                {
                    // Xử lý khi click thoát game
                    dialog.Visible = true;
                }
            }
        }

        public void handleResult(string resultName)
        {
            if (resultName.Equals("no"))
            {
                dialog.Visible = false;
            }

            if (resultName.Equals("newgame_yes"))
            {
                dialog.Visible = false;
                // Xử lý khi bắt đầu lại game
                // ** TODO
            }

            if (resultName.Equals("setting_yes"))
            {
                dialog.Visible = false;
                // Xử lý khi lưu cài đặt (ví dụ: chỉnh âm thanh)
                // TODO
            }

            if (resultName.Equals("exit_yes"))
            {
                GameControl.g.Exit();
            }
        }
    }
}
