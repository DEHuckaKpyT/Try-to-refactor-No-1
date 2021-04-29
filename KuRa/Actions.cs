using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KuRa
{
    class Actions
    {
        public static int length, width, height, part, widlen, heilen;
        static int i, j;
        static BinaryFormatter binaryFormatter = new BinaryFormatter();
        static FileStream fileStream;

        public static void Update(int width, int height)
        {
            Actions.width = width;
            Actions.height = height;
            if (height < width) length = height; else length = width;
            part = length / 8;
            widlen = width / 2 - length / 2;
            heilen = height / 2 - length / 2;
        }

        public static void DrawCross(Graphics g, Pen p, int i, int j)
        {
            g.DrawLine(p, widlen + part * (i + 1), heilen + part * (j + 1), widlen + part * (i + 2), heilen + part * (j + 2));
            g.DrawLine(p, widlen + part * (i + 1), heilen + part * (j + 2), widlen + part * (i + 2), heilen + part * (j + 1));
        }

        public static void DrawCircle(Graphics g, Pen p, int i, int j)
        {
            g.DrawEllipse(p, widlen + part * (i + 1), heilen + part * (j + 1), part, part);
        }

        public static void DrawGrid(Graphics g, Pen p)
        {
            for (i = -2; i < 3; i++) g.DrawLine(p, width / 2 - i * part, height / 2 - 3 * part, width / 2 - i * part, height / 2 + 3 * part);
            for (i = -2; i < 3; i++) g.DrawLine(p, width / 2 - 3 * part, height / 2 - i * part, width / 2 + 3 * part, height / 2 - i * part);
        }

        public static void SaveGame(string name, int[,] ground)
        {
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Saves");
            name = Directory.GetCurrentDirectory() + "/Saves/" + name;
            using (fileStream = new FileStream(name, FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fileStream, ground);
            }
        }

        public static int[,] LoadGame(string name, int[,] ground)
        {
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Saves");
            name = Directory.GetCurrentDirectory() + "/Saves/" + name;
            using (fileStream = new FileStream(name, FileMode.OpenOrCreate))
            {
                if (fileStream.Length != 0)
                    ground = (int[,])binaryFormatter.Deserialize(fileStream);
                else for (i = 0; i < 6; i++)
                        for (j = 0; j < 6; j++)
                            ground[i, j] = 0;
            }
            if (ClassAI.Check(ref ground)) Form1.activeGround = false; else Form1.activeGround = true;
            return ground;
        }
    }
}
