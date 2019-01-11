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
    class MenuItem
    {
        List<Texture2D> imgs = new List<Texture2D>(); // 3 img for normal, click, hover
        int imgIndex = 0; // 0: normal, 1: click, 2: hover
        string content; // newgame, exit, continue
        string name = ""; // nội dung của menuItem
        string[] imgsPath;
        float left, top, width, height;
        SpriteFont font;
        Color fontColor = Color.White;
        bool visible = false;

        public delegate void ClickHandler(object sender, EventArgs e);
        public event ClickHandler Click;
        bool isClicked = false;

        public string Name { get => this.name; set => this.name = value; }
        public bool Visible { get => this.visible; set => this.visible = value; }

        public MenuItem(string name, Rectangle rectangle, string content, string[] imgsPath, bool visible)
        {
            this.name = name;
            this.left = rectangle.Left;
            this.top = rectangle.Top;
            this.width = rectangle.Width;
            this.height = rectangle.Height;
            this.content = content;
            this.imgsPath = imgsPath;
            this.visible = visible;
        }

        public void LoadContent() // [0]: imgPath normal, [1]: imgPath click, [2]: imgPath hover
        {
            font = GameControl.g.Content.Load<SpriteFont>("font/title");

            for (int i = 0; i < imgsPath.Length; i++)
            {
                var img = GameControl.g.Content.Load<Texture2D>(imgsPath[i]);
                this.imgs.Add(img);
            }
        }

        public void UnloadContent()
        {
            imgs.Clear();
        }

        public void Update()
        {
            if (this.visible)
            {
                fontColor = Color.White;
                imgIndex = 0;

                this.HoverListener();
                this.ClickListener();

                if (isClicked) imgIndex = 1;
            }
        }

        public void Draw()
        {
            if (this.visible)
            {
                GameControl.sb.Draw(imgs[imgIndex],
                    new Rectangle((int)this.left, (int)this.top, (int)this.width, (int)this.height), Color.White);
                GameControl.sb.DrawString(font, content, new Vector2(left + width / 4, top + height / 4), fontColor);
            }
        }

        private void ClickListener()
        {
            MouseState ms = Mouse.GetState();

            if (!isClicked && this.IsSelected(ms) && ms.LeftButton == ButtonState.Pressed)
            {
                isClicked = true;
                if (this.Click != null)
                {
                    this.Click(this, new EventArgs()); // Event click
                }
            }

            if (ms.LeftButton == ButtonState.Released)
            {
                isClicked = false;
            }
        }

        private void HoverListener()
        {
            MouseState ms = Mouse.GetState();

            if (this.IsSelected(ms))
            {
                fontColor = Color.Yellow;
                imgIndex = 2;
            }
        }

        private bool IsSelected(MouseState ms)
        {
            float x = ms.X;
            float y = ms.Y;

            if (x >= this.left && x <= this.left + this.width &&
                y >= this.top && y <= this.top + this.height)
            {
                return true;
            }

            return false;
        }
    }
}
