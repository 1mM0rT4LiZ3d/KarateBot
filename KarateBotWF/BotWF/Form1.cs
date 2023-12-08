using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotWF
{
    public partial class Form1 : Form
    {
        bool[] Woods = new bool[8];

        public Color UnderColor;

        //Для эмуляции мышки
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        //Для определения позиции курсора
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);
        static protected long totalPixels = 0;
        static protected int diffX;
        static protected int diffY;

        public bool IsWork;
        public bool IsColor;

        public Form1()
        {
            InitializeComponent();
        }

        public void GetXY()
        {
            Point defPnt = new Point();

            GetCursorPos(ref defPnt);

            textX.Text = defPnt.X.ToString();
            textY.Text = defPnt.Y.ToString();

            Col1.Text = GetDesktopColor(Convert.ToInt32(defPnt.X.ToString())
                , Convert.ToInt32(defPnt.Y.ToString())).ToString();
        }

        public void DoMouseClick()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        public void LeftClick()
        {
            Cursor.Position = new System.Drawing.Point(230, 450);

            DoMouseClick();
        }

        public void RightClick()
        {
            Cursor.Position = new System.Drawing.Point(800, 450);

            DoMouseClick();
        }

        //Определение цвета
        static Color GetDesktopColor(int x, int y)
        {
            using (Bitmap bmp = new Bitmap(800, 1080, PixelFormat.Format32bppArgb))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0,
                        Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                }
                return bmp.GetPixel(x, y);
            }
        }

        private void textTrig_TextChanged(object sender, EventArgs e)
        {
            GetXY();
        }

        public void Wood(bool[] Woods)
        {
            textWood.Text = "";

            foreach (var w in Woods)
            {
                textWood.Text += Convert.ToInt32(w);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GoGame();
        }

        public void GoGame()
        {
            UnderColor = GetDesktopColor(685, 988);
            WoodCheck2();
            RAGECheck();
        }

        bool[] StR = new bool[8];
        public Color C1, C2;
        private void button4_Click(object sender, EventArgs e)
        {
            IceScan();
        }

        async public void IceScan()
        {
            IceText.Text = "";
            for (int i = 0; i < 7; i++)
            {
                C1 = GetDesktopColor(619, 847 - i * 87);
                C2 = GetDesktopColor(619, 838 - i * 87);

                Cursor.Position = new System.Drawing.Point(619, 847 - i * 87);
                await Task.Delay(500);
                Cursor.Position = new System.Drawing.Point(619, 838 - i * 87);
                await Task.Delay(500);

                Col1.Text = "C1 " + Convert.ToString(C1);
                Col2.Text = "C2 " + Convert.ToString(C2);

                if (Convert.ToInt32(C2.G.ToString()) > Convert.ToInt32(C1.G.ToString()) + 35)
                {
                    IceText.Text = $"{Convert.ToInt32(C2.G.ToString())} {Convert.ToInt32(C1.G.ToString()) + 35} DetecteD {i}";
                    IsIce = i;
                }
            }
        }

        int IsIce = -1; bool IsRage;
        async public void WoodCheck2()
        {
            while (GetDesktopColor(685, 988) == UnderColor)
            {
                if(IsRage)
                {
                    IsRage = false;
                    await Task.Delay(4000);

                    Woods[0] = IsBeam(GetDesktopColor(516, 805)) || IsBeam(GetDesktopColor(560, 805));
                    Woods[1] = IsBeam(GetDesktopColor(518, 718)) || IsBeam(GetDesktopColor(560, 718));
                    Woods[2] = IsBeam(GetDesktopColor(518, 630)) || IsBeam(GetDesktopColor(560, 630));
                    Woods[3] = IsBeam(GetDesktopColor(518, 539)) || IsBeam(GetDesktopColor(560, 539));
                    Woods[4] = IsBeam(GetDesktopColor(518, 452)) || IsBeam(GetDesktopColor(560, 452));

                    Col2.Text = "";
                }

                //Проверка 3х позиций 2.0
                await Task.Delay(175);

                Woods[5] = IsBeam(GetDesktopColor(518, 365)) || IsBeam(GetDesktopColor(560, 365));
                Woods[6] = IsBeam(GetDesktopColor(518, 282)) || IsBeam(GetDesktopColor(560, 282));
                Woods[7] = IsBeam(GetDesktopColor(518, 193)) || IsBeam(GetDesktopColor(560, 193));

                Wood(Woods);

                //Лёд 2.0 (На 3 позиции)
                IceText.Text = "";
                for (int i = 5; i < 8; i++)
                {
                    C2 = GetDesktopColor(619, 838 - i * 87);

                    if (Convert.ToInt32(C2.G.ToString()) > 150)
                    {
                        IceText.Text = $"DetecteD {i}";
                        IsIce = i;
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                Ice:
                    if (!Woods[i] && !Woods[i + 1])
                    {
                        LeftClick();
                    }
                    else
                    {
                        RightClick();
                    }

                    if (i == IsIce)
                    {
                        IsIce = -1;
                        goto Ice;
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    Woods[i] = Woods[i + 3];
                }
                IsIce -= 3;
            }

            if (checkBox1.Checked)
            {
                await Task.Delay(5000);

                Cursor.Position = new System.Drawing.Point(685, 988);
                DoMouseClick();

                await Task.Delay(2000);

                GoGame();
            }
        }

        public async void RAGECheck()
        {
            while (GetDesktopColor(685, 988) == UnderColor)
            {
                if (((GetDesktopColor(702, 870).R > 230) && !IsRage)
                    || ((GetDesktopColor(604, 870).R > 230) && !IsRage))
                {
                    Col2.Text = "RAGE";
                    IsRage = true;
                }

                await Task.Delay(5);
            }
        }

        public bool ToColor(Color c1, Color c2)
        {
            return (Math.Abs(Convert.ToInt32(c1.G.ToString()) - Convert.ToInt32(c2.G.ToString())) == 0);
        }

        public bool IsBeam(Color Col)
        {
            bool a = false;

            a =  Is(Col, 85,135) //BaseWood 85 135
                || Is(Col, 152,178) //WhiteWood 152 178
                || Is(Col, 171, 150) //Stone 171 150
                || Is(Col, 164, 142); //Steel 164 142

            return a;
        }

        public bool Is(Color Col, int b, int g)
        {
            bool a = false;

            a = (Math.Abs(Col.B - b) < 4) && (Math.Abs(Col.G - g) < 4);

            return a;
        }

        private void Col1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Col2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}