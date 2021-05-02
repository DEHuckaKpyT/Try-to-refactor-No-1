using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KuRa
{
    static class Actions
    {
        public static int length, width, height, partOfGrid, widthStart, heightStart;
        static int i, j;
        static BinaryFormatter binaryFormatter = new BinaryFormatter();
        static FileStream fileStream;

        public static void UpdateWindowSize(int width, int height)
        {
            Actions.width = width;
            Actions.height = height;
            length = height < width ? height : width;
            //на 8 частей, чтобы рисовать посередине 6 клеток
            partOfGrid = length / 8;
            widthStart = width / 2 - length / 2;
            heightStart = height / 2 - length / 2;
        }

        public static void DrawCross(Graphics g, Pen p, int i, int j)
        {
            g.DrawLine(p, widthStart + partOfGrid * (i + 1), heightStart + partOfGrid * (j + 1), 
                widthStart + partOfGrid * (i + 2), heightStart + partOfGrid * (j + 2));
            g.DrawLine(p, widthStart + partOfGrid * (i + 1), heightStart + partOfGrid * (j + 2), 
                widthStart + partOfGrid * (i + 2), heightStart + partOfGrid * (j + 1));
        }

        public static void DrawCircle(Graphics g, Pen p, int i, int j)
        {
            g.DrawEllipse(p, widthStart + partOfGrid * (i + 1), heightStart + partOfGrid * (j + 1), partOfGrid, partOfGrid);
        }

        public static void DrawGrid(Graphics g, Pen p)
        {
            for (i = -2; i < 3; i++)
                g.DrawLine(p, width / 2 - i * partOfGrid, height / 2 - 3 * partOfGrid, 
                    width / 2 - i * partOfGrid, height / 2 + 3 * partOfGrid);
            for (i = -2; i < 3; i++) 
                g.DrawLine(p, width / 2 - 3 * partOfGrid, height / 2 - i * partOfGrid, 
                    width / 2 + 3 * partOfGrid, height / 2 - i * partOfGrid);
        }

        public static void SaveGame(string name, int[,] ground)
        {
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Saves");
            name = Directory.GetCurrentDirectory() + "/Saves/" + name;
            using (fileStream = new FileStream(name, FileMode.OpenOrCreate))
                binaryFormatter.Serialize(fileStream, ground);
        }

        public static int[,] LoadGame(string name, int[,] ground)
        {
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Saves");
            name = Directory.GetCurrentDirectory() + "/Saves/" + name;
            using (fileStream = new FileStream(name, FileMode.OpenOrCreate))
            {
                if (fileStream.Length != 0)
                    ground = (int[,])binaryFormatter.Deserialize(fileStream);
                else
                    ground = SetStartGround(ground);
            }

            Form1.isActiveGround = !ClassAI.HasWinner(ref ground);

            return ground;
        }

        public static int[,] SetStartGround(int[,] ground)
        {
            for (i = 0; i < 6; i++)
                for (j = 0; j < 6; j++)
                    ground[i, j] = 0;
            return ground;
        }
    }
}
