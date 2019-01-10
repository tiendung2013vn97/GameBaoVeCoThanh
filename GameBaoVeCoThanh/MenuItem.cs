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
        string state; // newgame, exitgame, continue
        string name = ""; // nội dung của menuItem
        string[] imgsPath;
        float left, top, width, height;

        public delegate void ClickHandler(object sender, EventArgs e);
        public event ClickHandler Click;
        bool isClicked = false;

        public string State { get => this.state; set => this.state = value; }

        public MenuItem(string name, Rectangle rectangle, string state, string[] imgsPath)
        {
            this.name = name;
            this.left = rectangle.Left;
            this.top = rectangle.Top;
            this.width = rectangle.Width;
            this.height = rectangle.Height;
            this.state = state;
            this.imgsPath = imgsPath;
        }

        public void LoadContent() // [0]: imgPath normal, [1]: imgPath click, [2]: imgPath hover
        {
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
            imgIndex = 0;

            this.HoverListener();
            this.ClickListener();

            if (isClicked) imgIndex = 1;
        }

        public void Draw()
        {
            GameControl.sb.Draw(imgs[imgIndex],
                new Rectangle((int)this.left, (int)this.top, (int)this.width, (int)this.height), Color.White);
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
