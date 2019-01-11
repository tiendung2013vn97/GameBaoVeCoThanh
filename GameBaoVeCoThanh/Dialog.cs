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
    class Dialog
    {
        Texture2D background;
        List<MenuItem> list = new List<MenuItem>();
        string name = "";
        string content = "";
        float left, top, width, height;
        bool visible = false;
        SpriteFont font;
        bool isReleased = false;

        public delegate void HandleResult(string resultName);
        public event HandleResult Result;

        public bool Visible { get => this.visible; set => this.visible = value; }

        public Dialog(Rectangle rectangle, bool visible)
        {
            this.left = rectangle.Left;
            this.top = rectangle.Top;
            this.width = rectangle.Width;
            this.height = rectangle.Height;
            this.visible = visible;
        }

        public void LoadContent()
        {
            font = GameControl.g.Content.Load<SpriteFont>("font/title");

            background = GameControl.g.Content.Load<Texture2D>("menu/dialog");

            // dialog for newgame, setting, exit
            createMenuItem("yes", new Rectangle(GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth / 2 - 100, 250, 70, 70), "",
                            new string[] { "menu/item/yes/normal", "menu/item/yes/normal", "menu/item/yes/hover" });
            createMenuItem("no", new Rectangle(GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth / 2 + 35, 250, 70, 70), "",
                            new string[] { "menu/item/no/normal", "menu/item/no/normal", "menu/item/no/hover" });

            //// dialog for maps
            //createMenuItem("no", new Rectangle(GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth / 2 + 130, 320, 70, 70), "",
            //                new string[] { "menu/item/no/normal", "menu/item/no/normal", "menu/item/no/hover" });

            //// list maps
            //createMenuItem("map1", new Rectangle(GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth / 2 - 190, 80, 70, 70), "",
            //                new string[] { "menu/item/number/normal", "menu/item/number/normal", "menu/item/number/hover" });
            //createMenuItem("map2", new Rectangle(GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth / 2 - 110, 80, 70, 70), "",
            //                new string[] { "menu/item/number/normal", "menu/item/number/normal", "menu/item/number/hover" });
            //createMenuItem("map3", new Rectangle(GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth / 2 - 30, 80, 70, 70), "",
            //                new string[] { "menu/item/number/normal", "menu/item/number/normal", "menu/item/number/hover" });
            //createMenuItem("map4", new Rectangle(GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth / 2 + 50, 80, 70, 70), "",
            //                new string[] { "menu/item/number/normal", "menu/item/number/normal", "menu/item/number/hover" });
            //createMenuItem("map5", new Rectangle(GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth / 2 + 130, 80, 70, 70), "",
            //                new string[] { "menu/item/number/normal", "menu/item/number/normal", "menu/item/number/hover" });
            //createMenuItem("map6", new Rectangle(GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth / 2 - 190, 160, 70, 70), "",
            //                new string[] { "menu/item/number/normal", "menu/item/number/normal", "menu/item/number/hover" });
            //createMenuItem("map7", new Rectangle(GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth / 2 - 110, 160, 70, 70), "",
            //                new string[] { "menu/item/number/normal", "menu/item/number/normal", "menu/item/number/hover" });
            //createMenuItem("map8", new Rectangle(GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth / 2 - 30, 160, 70, 70), "",
            //                new string[] { "menu/item/number/normal", "menu/item/number/normal", "menu/item/number/hover" });
            //createMenuItem("map9", new Rectangle(GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth / 2 + 50, 160, 70, 70), "",
            //                new string[] { "menu/item/number/normal", "menu/item/number/normal", "menu/item/number/hover" });
            //createMenuItem("map10", new Rectangle(GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth / 2 + 130, 160, 70, 70), "",
            //                new string[] { "menu/item/number/normal", "menu/item/number/normal", "menu/item/number/hover" });
            //createMenuItem("map11", new Rectangle(GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth / 2 - 190, 240, 70, 70), "",
            //                new string[] { "menu/item/number/normal", "menu/item/number/normal", "menu/item/number/hover" });
            //createMenuItem("map12", new Rectangle(GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth / 2 - 110, 240, 70, 70), "",
            //                new string[] { "menu/item/number/normal", "menu/item/number/normal", "menu/item/number/hover" });

            for (int i = 0; i < list.Count; i++)
            {
                list[i].LoadContent();
                list[i].Visible = false;
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
            if (this.visible)
            {
                MouseState ms = Mouse.GetState();

                if (ms.LeftButton == ButtonState.Released)
                {
                    isReleased = true;
                }

                if (isReleased)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].Update();
                    }
                }
            }
            else
            {
                isReleased = false;
            }
        }

        public void Draw()
        {
            if (this.visible)
            {
                GameControl.sb.Draw(background, new Rectangle((int)left, (int)top, (int)width, (int)height), Color.White);

                GameControl.sb.DrawString(font, content,
                                            new Vector2(GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth / 2 - 100, 170), Color.White);

                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Draw();
                }
            }
        }

        public void createMenuItem(string name, Rectangle rectangle, string state, string[] imgsPath) // name là nội dung của menuItem
        {
            MenuItem menuItem = new MenuItem(name, rectangle, state, imgsPath, true);
            menuItem.Click += handleClick;
            list.Add(menuItem);
        }

        public void handleClick(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Visible = false;
                }

                if (menuItem.Name.Equals("newgame"))
                {
                    // Xử lý khi click setting ở menu
                    this.name = "newgame";
                    this.content = "Ban co muon choi lai!\nTat ca man choi se bi\nxoa khoi bo nho!";
                    this.width = 300;
                    this.height = 300;
                    this.left = (GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth - width) / 2;
                    this.top = (GameControl.g.GraphicsDevice.PresentationParameters.BackBufferHeight - height) / 2;

                    list[0].Visible = list[1].Visible = true;
                }

                //if (menuItem.Name.Equals("maps"))
                //{
                //    // Xử lý khi click setting ở menu
                //    this.name = "maps";
                //    this.content = "";
                //    this.width = 500;
                //    this.height = 500;
                //    this.left = (GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth - width) / 2;
                //    this.top = (GameControl.g.GraphicsDevice.PresentationParameters.BackBufferHeight - height) / 2;

                //    list[2].Visible = true;
                    
                //    for (int i = 3; i < list.Count; i++)
                //    {
                //        list[i].Visible = true;
                //    }
                //}

                if (menuItem.Name.Equals("setting"))
                {
                    // Xử lý khi click setting ở menu
                    this.name = "setting";
                    this.content = "Am thanh";
                    this.width = 300;
                    this.height = 300;
                    this.left = (GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth - width) / 2;
                    this.top = (GameControl.g.GraphicsDevice.PresentationParameters.BackBufferHeight - height) / 2;

                    list[0].Visible = list[1].Visible = true;
                }

                if (menuItem.Name.Equals("exit"))
                {
                    // Xử lý khi click exit ở menu
                    this.name = "exit";
                    this.content = "Ban co muon thoat\nkhong!";
                    this.width = 300;
                    this.height = 300;
                    this.left = (GameControl.g.GraphicsDevice.PresentationParameters.BackBufferWidth - width) / 2;
                    this.top = (GameControl.g.GraphicsDevice.PresentationParameters.BackBufferHeight - height) / 2;

                    list[0].Visible = list[1].Visible = true;
                }

                if (menuItem.Name.Equals("no"))
                {
                    // Xử lý khi click no
                    //if (this.name.Equals("exit"))
                    //{
                    //    this.resultName = "exit_no";
                    //}
                    
                    this.visible = false;
                    this.Result("no");
                }

                if (menuItem.Name.Equals("yes"))
                {
                    // Xử lý khi click yes
                    this.visible = false;

                    if (this.name.Equals("newgame"))
                    {
                        this.Result("newgame_yes");
                    }

                    if (this.name.Equals("setting"))
                    {
                        this.Result("setting_yes");
                    }

                    if (this.name.Equals("exit"))
                    {
                        this.Result("exit_yes");
                    }

                    
                }
            }
        }
    }
}
