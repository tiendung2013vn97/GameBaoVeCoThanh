using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBaoVeCoThanh
{
    class PhysicalObject
    {
        public delegate void CollideHandler(object sender, EventArgs e);
        public event CollideHandler Collide;

        public List<Texture2D> img { get; set; }
        int imgIndex;
        public float Pos { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string Kind { get; set; }

        public PhysicalObject(string[] imgPath,string kind)
        {
            for (int i = 0; i < imgPath.Length; i++)
            {
                img.Add(GameControl.g.Content.Load<Texture2D>(imgPath[i]));
            }
            Kind = kind;
            imgIndex = 0;
        }

        public void AddCollideHandle(PhysicalObject other)
        {
            if(Kind=="binhSiThuong"||Kind=="tinhBinh"||Kind=="ninja"||Kind=="binhSiTrongGiap"||Kind=="rongDat"
            || Kind == "rongGio" || Kind == "rongDat")
            {
                if (other.Kind == "muiTen")
                {

                }

                if (other.Kind == "lua")
                {

                }

                if (other.Kind == "loc")
                {

                }

            }
        }
        bool checkPointInRectangle(float x, float y, Rectangle rec)
        {
            if (x >= rec.X && x <= rec.X + rec.Width && y >= rec.Y && y <= rec.Y + rec.Height)
            {
                return true;
            }
            return false;
        }

        bool isIntersectRectangle(Rectangle a,Rectangle b)
        {
            if (checkPointInRectangle(a.X, a.Y, b)||checkPointInRectangle(a.X, a.Y+a.Height, b)||
                checkPointInRectangle(a.X+a.Width, a.Y, b)||checkPointInRectangle(a.X+a.Width, a.Y+a.Height, b)||
                checkPointInRectangle(b.X, b.Y, a) || checkPointInRectangle(b.X, b.Y + b.Height, a) ||
                checkPointInRectangle(b.X+b.Width, b.Y, a)||checkPointInRectangle(b.X+b.Width, b.Y+b.Height, a))
            {
                return true;
            }
            return false;
        }

    }
}
