using System.Drawing;
using System.Windows.Forms;
using Tetris;

namespace TetrisForm
{
    public sealed class SimpleCubePicBox : PictureBox, ITetrisable
    {
        public int BoxWidth;
        public int BoxHeight;
        public int padding;
        public static int FormWidth = 500;
        public static int BasicLength = 10;
        public static int FieldOffset;
        public static Form1 GameBoardstandard;
        public bool IsShowed;

        public static void SetBasicParameters(Form1 panel, int offset, int basicLength = 10, int formWidth = 500)
        {
            // standard 12 X 10; 
            SimpleCubePicBox.GameBoardstandard = panel;
            SimpleCubePicBox.BasicLength = basicLength;
            SimpleCubePicBox.FormWidth = formWidth;
            SimpleCubePicBox.FieldOffset = offset;
        }

        public SimpleCubePicBox()
        {
            IsShowed = false;
            BoxWidth = FormWidth / BasicLength - 2;
            BoxHeight = BoxWidth;
            padding = (int)(BoxWidth * 0.07);
            this.Width = BoxWidth;
            this.Height = BoxHeight;
            this.BackColor = Color.Chocolate;
            PictureBox innerBox = new PictureBox();
            innerBox.Width = BoxWidth - 2 * padding;
            innerBox.Height = BoxHeight - 2 * padding;
            innerBox.Top = padding;
            innerBox.Left = padding;
            innerBox.BackColor = Color.Brown;
            //place for image 
            this.Controls.Add(innerBox);
        }

        public void Sync(SimpleCube sc)
        {
            Render(sc);
        }
        public void Render(SimpleCube sc)
        {
            this.Left = sc.GetPosX * BoxWidth;
            this.Top = sc.GetPosY * BoxHeight + FieldOffset;
            if (IsShowed) return;
            GameBoardstandard.Controls.Add(this);
            IsShowed = true;
        }
        public void Delete()
        {
            this.Dispose();
            GameBoardstandard.Controls.Remove(this);

        }
        public ITetrisable Create(SimpleCube sc)
        {
            this.Render(sc);
            return this;
        }
    }
}
