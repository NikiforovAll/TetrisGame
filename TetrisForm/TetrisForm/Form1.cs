using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace TetrisForm
{
    public partial class Form1 : Form
    {
        protected GameStatistics gameInfo = new GameStatistics(false);
        protected static LadderBoard LadderBoard = new LadderBoard();
        private static ListBox _users;
        private Button _cleanButt;
        private Label _tableLabel;
        readonly IFormatter _objBinaryFormatter = new BinaryFormatter();

        public Form1()
        {
            InitializeComponent();
            mainDropDownLadderStrip = this.ladderToolStripMenuItem;
            this.FormClosed += Form1_FormClosed;

        }


        public GameStatistics GameInfo
        {
            get { return gameInfo; }
            set { gameInfo = value; }
        }

        protected virtual void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!gameInfo.IsInGame)
            {
                // Game adjustments
                gameInfo.IsInGame = true;
                gameInfo.MainForm.Hide();
                if (GameInfo.PlayerForm != null)
                {
                    gameInfo.PlayerForm.Close();
                }
                gameInfo.PlayerForm = new Form2();
                SimpleCubePicBox.SetBasicParameters(gameInfo.PlayerForm, 80);
                gameInfo.PlayerForm.GameInfo = this.gameInfo;
                gameInfo.PlayerForm.Show();
            }
        }

        protected virtual void ladderToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //Bad GUI ?? 
            if (_users == null)
            {
                _users = new ListBox();
                _users.Top = Height / 4;
                _users.Left = Width / 4;
                _users.Height = 45;
                _users.Width = 300;
                for (int i = 0; i < LadderBoard.Count; i++)
                {
                    ListViewItem tmp = new ListViewItem();

                    tmp.Text = LadderBoard[i].Key + ":" + LadderBoard[i].Value;
                    _users.Items.Add(tmp);
                }
                _users.Hide();
                #region laddderControls
                this.Controls.Add(_users);
                _cleanButt = new Button();
                _cleanButt.Width = 90;
                _cleanButt.Height = 30;
                _cleanButt.Top = Height / 4 + 60;
                _cleanButt.BackColor = Color.CadetBlue;
                _cleanButt.Text = "Clear";
                _cleanButt.Font = new Font(_cleanButt.Font.FontFamily, 10);
                _cleanButt.TextAlign = ContentAlignment.MiddleCenter;
                _cleanButt.Left = (int)(this.Width * 0.75);
                _cleanButt.Click += cleanButt_Click;
                this.Controls.Add(_cleanButt);
                _tableLabel = new Label();
                _tableLabel.Width = 120;
                _tableLabel.Height = 30;
                _tableLabel.Top = Width / 4;
                _tableLabel.BackColor = Color.DeepSkyBlue;
                _tableLabel.Font = new Font(_tableLabel.Font.FontFamily, 10);
                _tableLabel.TextAlign = ContentAlignment.MiddleCenter;
                _tableLabel.Left = (int)(this.Width / 4);
                _tableLabel.Text = "Top Results:";
                this.Controls.Add(_tableLabel);
                #endregion

            }
            else
            {

                _users.Items.Clear();
                for (int i = 0; i < LadderBoard.Count; i++)
                {
                    ListViewItem tmp = new ListViewItem();

                    tmp.Text = LadderBoard[i].Key + ":" + LadderBoard[i].Value;
                    _users.Items.Add(tmp);
                }

                //for (int i = 0; i < ladderBoard.Count; i++)
                //{

                //    if (users.Items.Count > i)
                //        ((ListViewItem)users.Items[i]).Text = ladderBoard[i].Key + ":" + ladderBoard[i].Value;
                //    else
                //    {
                //        ListViewItem tmp = new ListViewItem();

                //        tmp.Text = ladderBoard[i].Key + ":" + ladderBoard[i].Value;
                //        users.Items.Add(tmp);

                //    }
                //}


            }
            if (!gameInfo.IsInGame)
            {
                _users.Show();
            }
            else
            {
                _users.Hide();
            }

        }

        void cleanButt_Click(object sender, EventArgs e)
        {
            if (_users != null)
            {
                _users.Items.Clear();
                // users = null;
                LadderBoard = new LadderBoard();
            }

        }

        protected virtual void Form1_Load(object sender, EventArgs e)
        {
            //  deserialization
            try
            {
                Stream objstreamdeserialize = new FileStream("data.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                LadderBoard = (LadderBoard)_objBinaryFormatter.Deserialize(objstreamdeserialize);
                objstreamdeserialize.Close();

            }
            catch (Exception ea)
            {
                LadderBoard = new LadderBoard();
            }
        }
        protected virtual void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //serialization
            try
            {
                Stream objStream = new FileStream("data.bin", FileMode.Create, FileAccess.ReadWrite, FileShare.None);
                _objBinaryFormatter.Serialize(objStream, LadderBoard);
                objStream.Close();
            }
            catch (Exception ea)
            {

            }
        }
    }
}
