using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameBaoVeCoThanh
{
    public static class GameInfo
    {
        public static int curLevel = 1;
        public static int[] goldArr = { 350, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private static string filePath;

        public static void saveFile(string fileName)
        {
            try
            {
                // Get executing path
                filePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + fileName;

                // Check if file already exists. If yes, delete it.   
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                // Create a new file   
                using (StreamWriter sw = System.IO.File.CreateText(filePath))
                {
                    sw.WriteLine(curLevel);

                    for (int i = 0; i < goldArr.Length; i++)
                    {
                        sw.WriteLine(goldArr[i]);
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        public static void loadFile(string fileName)
        {
            try
            {
                // Get executing path
                filePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + fileName;
                string line;

                // Read the file and display it line by line.  
                System.IO.StreamReader file = new System.IO.StreamReader(filePath);

                // Read curLevel
                if ((line = file.ReadLine()) != null)
                {
                    curLevel = int.Parse(line);

                    // Read goldArr
                    for (int i = 0; i < goldArr.Length && ((line = file.ReadLine()) != null); i++)
                    {
                        goldArr[i] = int.Parse(line);
                    }
                }

                file.Close();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        public static void Update(int newLevel, int newGold)
        {
            curLevel = newLevel;
            goldArr[newLevel - 1] = newGold;
        }
    }
}
