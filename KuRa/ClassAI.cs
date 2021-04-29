using System;

namespace KuRa
{
    static class ClassAI
    {
        static Random rand = new Random();
        static int i, j, k;
        static int s;
        static bool fl;
        static int ii, iii;
        public static int[,] TurnAI(int[,] ground)
        {
            ground = Step0(ground);
            for (i = 0; i < 6; i++)
            {
                ground = Step1(ground, i, 0, 5, -2, -1, 30);
                ground = Step1(ground, i, 1, 6, -2, -1, 30);
                ground = Step1(ground, i, 0, 5, -1, -2, 27);
                ground = Step1(ground, i, 1, 6, -1, -2, 27);
            }
            for (j = 0; j < 6; j++)
            {
                ground = Step2(ground, j, 0, 5, -2, -1, 30);
                ground = Step2(ground, j, 1, 6, -2, -1, 30);
                ground = Step2(ground, j, 0, 5, -1, -2, 27);
                ground = Step2(ground, j, 1, 6, -1, -2, 27);
            }
            for (i = 0; i < 4; i++)
            {
                ground = Step3(ground, i, -2, -1, 30);
                ground = Step3(ground, i, -1, -2, 27);
                ground = Step4(ground, i, -2, -1, 30);
                ground = Step4(ground, i, -1, -2, 27);
            }
            return ground;
        }
        public static bool Check(ref int[,] ground)
        {
            for (i = 0; i < 6; i++)
            {
                if (Check1(ref ground, i, 0, 5, -2, -1)) return true;
                if (Check1(ref ground, i, 1, 6, -2, -1)) return true;
                if (Check1(ref ground, i, 0, 5, -1, -2)) return true;
                if (Check1(ref ground, i, 1, 6, -1, -2)) return true;
            }
            for (j = 0; j < 6; j++)
            {
                if (Check2(ref ground, j, 0, 5, -2, -1)) return true;
                if (Check2(ref ground, j, 1, 6, -2, -1)) return true;
                if (Check2(ref ground, j, 0, 5, -1, -2)) return true;
                if (Check2(ref ground, j, 1, 6, -1, -2)) return true;
            }
            for (i = 0; i < 4; i++)
            {
                if (Check3(ref ground, i, -2, -1)) return true;
                if (Check3(ref ground, i, -1, -2)) return true;
                if (Check4(ref ground, i, -2, -1)) return true;
                if (Check4(ref ground, i, -1, -2)) return true;
            }
            return false;
        }
        public static bool CheckDraw(int[,] ground)
        {
            k = 0;
            for (i = 0; i < 6; i++)
                for (j = 0; j < 6; j++)
                    if (ground[i, j] == -1 || ground[i, j] == -2) k++;
            if (k == 36) return true;
            return false;
        }

        static int[,] Step0(int[,] ground)
        {
            for (i = 0; i < 6; i++)
                for (j = 0; j < 6; j++)
                    if (ground[i, j] != -1 & ground[i, j] != -2) ground[i, j] = 0;
            return ground;
        }

        static int[,] Step1(int[,] ground, int i, int start, int end, int Me, int Enemy, int weight)
        {
            s = 0;
            fl = false;
            for (j = start; j < end; j++)
            {
                if (ground[i, j] == Enemy || ground[i, j] == -3 || ground[i, j] == -4) fl = true;
                if (ground[i, j] == Me) s++;
            }
            if (!fl)
                switch (s)
                {
                    case 1:
                        for (j = start; j < end; j++)
                            if (ground[i, j] != Me) ground[i, j] += weight + rand.Next(10);
                        break;
                    case 2:
                        for (j = start; j < end; j++)
                            if (ground[i, j] != Me) ground[i, j] += weight * 4 + rand.Next(10);
                        break;
                    case 3:
                        for (j = start; j < end; j++)
                            if (ground[i, j] != Me) ground[i, j] += weight * 9 + rand.Next(10);
                        break;
                    case 4:
                        for (j = start; j < end; j++)
                            if (ground[i, j] != Me) ground[i, j] += weight * 25 + rand.Next(10);
                        break;
                }
            return ground;
        }

        static int[,] Step2(int[,] ground, int j, int start, int end, int Me, int Enemy, int weight)
        {
            s = 0;
            fl = false;
            for (i = start; i < end; i++)
            {
                if (ground[i, j] == Enemy || ground[i, j] == -3 || ground[i, j] == -4) fl = true;
                if (ground[i, j] == Me) s++;
            }
            if (!fl)
                switch (s)
                {
                    case 1:
                        for (i = start; i < end; i++)
                            if (ground[i, j] != Me) ground[i, j] += weight + rand.Next(10);
                        break;
                    case 2:
                        for (i = start; i < end; i++)
                            if (ground[i, j] != Me) ground[i, j] += weight * 4 + rand.Next(10);
                        break;
                    case 3:
                        for (i = start; i < end; i++)
                            if (ground[i, j] != Me) ground[i, j] += weight * 9 + rand.Next(10);
                        break;
                    case 4:
                        for (i = start; i < end; i++)
                            if (ground[i, j] != Me) ground[i, j] += weight * 25 + rand.Next(10);
                        break;

                }
            return ground;
        }

        static int[,] Step3(int[,] ground, int i, int Me, int Enemy, int weight)
        {
            s = 0;
            fl = false;
            ii = i / 2;
            iii = i % 2;
            for (j = 0; j < 5; j++)
            {
                if (ground[j + ii, j + iii] == Enemy || ground[j + ii, j + iii] == -3 || ground[j + ii, j + iii] == -4) fl = true;
                if (ground[j + ii, j + iii] == Me) s++;
            }
            if (!fl)
                switch (s)
                {
                    case 1:
                        for (j = 0; j < 5; j++)
                            if (ground[j + ii, j + iii] != Me) ground[j + ii, j + iii] += weight + rand.Next(10);
                        break;
                    case 2:
                        for (j = 0; j < 5; j++)
                            if (ground[j + ii, j + iii] != Me) ground[j + ii, j + iii] += weight * 4 + rand.Next(10);
                        break;
                    case 3:
                        for (j = 0; j < 5; j++)
                            if (ground[j + ii, j + iii] != Me) ground[j + ii, j + iii] += weight * 9 + rand.Next(10);
                        break;
                    case 4:
                        for (j = 0; j < 5; j++)
                            if (ground[j + ii, j + iii] != Me) ground[j + ii, j + iii] += weight * 25 + rand.Next(10);
                        break;

                }
            return ground;
        }

        static int[,] Step4(int[,] ground, int i, int Me, int Enemy, int weight)
        {
            s = 0;
            fl = false;
            ii = i / 2;
            iii = i % 2;
            for (j = 0; j < 5; j++)
            {
                if (ground[4 - j + ii, j + iii] == Enemy || ground[4 - j + ii, j + iii] == -3 || ground[4 - j + ii, j + iii] == -4) fl = true;
                if (ground[4 - j + ii, j + iii] == Me) s++;
            }
            if (!fl)
                switch (s)
                {
                    case 1:
                        for (j = 0; j < 5; j++)
                            if (ground[4 - j + ii, j + iii] != Me) ground[4 - j + ii, j + iii] += weight + rand.Next(10);
                        break;
                    case 2:
                        for (j = 0; j < 5; j++)
                            if (ground[4 - j + ii, j + iii] != Me) ground[4 - j + ii, j + iii] += weight * 4 + rand.Next(10);
                        break;
                    case 3:
                        for (j = 0; j < 5; j++)
                            if (ground[4 - j + ii, j + iii] != Me) ground[4 - j + ii, j + iii] += weight * 9 + rand.Next(10);
                        break;
                    case 4:
                        for (j = 0; j < 5; j++)
                            if (ground[4 - j + ii, j + iii] != Me) ground[4 - j + ii, j + iii] += weight * 25 + rand.Next(10);
                        break;
                }
            return ground;
        }

        static bool Check1(ref int[,] ground, int i, int start, int end, int Me, int Enemy)
        {
            s = 0;
            fl = false;
            for (j = start; j < end; j++)
            {
                if (ground[i, j] == Enemy || ground[i, j] == Enemy - 2) fl = true;
                if (ground[i, j] == Me || ground[i, j] == Me - 2) s++;
            }
            if (!fl)
                if (s == 5)
                {
                    if (Me == -1)
                        for (j = start; j < end; j++) ground[i, j] = -3;
                    else for (j = start; j < end; j++) ground[i, j] = -4;
                    return true;
                }
            return false;
        }
        static bool Check2(ref int[,] ground, int j, int start, int end, int Me, int Enemy)
        {
            s = 0;
            fl = false;
            for (i = start; i < end; i++)
            {
                if (ground[i, j] == Enemy || ground[i, j] == Enemy - 2) fl = true;
                if (ground[i, j] == Me || ground[i, j] == Me - 2) s++;
            }
            if (!fl)
                if (s == 5)
                {
                    if (Me == -1)
                        for (i = start; i < end; i++) ground[i, j] = -3;
                    else for (i = start; i < end; i++) ground[i, j] = -4;
                    return true;
                }
            return false;
        }

        static bool Check3(ref int[,] ground, int i, int Me, int Enemy)
        {
            s = 0;
            fl = false;
            ii = i / 2;
            iii = i % 2;
            for (j = 0; j < 5; j++)
            {
                if (ground[j + ii, j + iii] == Enemy || ground[j + ii, j + iii] == Enemy - 2) fl = true;
                if (ground[j + ii, j + iii] == Me || ground[j + ii, j + iii] == Me - 2) s++;
            }
            if (!fl)
                if (s == 5)
                {
                    if (Me == -1)
                        for (j = 0; j < 5; j++) ground[j + ii, j + iii] = -3;
                    else for (j = 0; j < 5; j++) ground[j + ii, j + iii] = -4;
                    return true;
                }
            return false;
        }
        static bool Check4(ref int[,] ground, int i, int Me, int Enemy)
        {
            s = 0;
            fl = false;
            ii = i / 2;
            iii = i % 2;
            for (j = 0; j < 5; j++)
            {
                if (ground[4 - j + ii, j + iii] == Enemy || ground[4 - j + ii, j + iii] == Enemy - 2) fl = true;
                if (ground[4 - j + ii, j + iii] == Me || ground[4 - j + ii, j + iii] == Me - 2) s++;
            }
            if (!fl)
                if (s == 5)
                {
                    if (Me == -1)
                        for (j = 0; j < 5; j++) ground[4 - j + ii, j + iii] = -3;
                    else for (j = 0; j < 5; j++) ground[4 - j + ii, j + iii] = -4;
                    return true;
                }
            return false;
        }
    }
}
