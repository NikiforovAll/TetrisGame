using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tetris;
using TetrisLibrary;

namespace TetrisForm
{

    public partial class Form2 : Form1
    {
        private GameField<SimpleCubePicBox> _gameTetris;
        private Part<SimpleCubePicBox> _currPart;
        private Timer _gameSpeedTimer;
        private Label _scoreLabel;

        public Form2()
        {
            InitializeComponent();
            this.Text = "TetrisGamePlay";
            this.FormClosing += Form2_FormClosing;
        }

        void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.gameInfo.IsInGame)
            {
                if (e.KeyChar == 'a' || e.KeyChar == 'ф')
                {
                    _gameTetris.MoveLeft(_currPart);
                }
                else if (e.KeyChar == 'd' || e.KeyChar == 'в')
                {
                    _gameTetris.MoveRight(_currPart);
                }
                else if (e.KeyChar == 'e' || e.KeyChar == 'у')
                {
                    _gameTetris.Rotate(_currPart, true);
                }
                else if (e.KeyChar == 'q' || e.KeyChar == 'й')
                {
                    _gameTetris.Rotate(_currPart, false);
                }
                else if (e.KeyChar == 's' || e.KeyChar == 'ы')
                {
                    gameSpeedTimer_Tick(_gameSpeedTimer, e);
                }
            }
        }

        // Tetris Game logic  Controller 
        void gameSpeedTimer_Tick(object sender, EventArgs e)
        {
            if (!_gameTetris.PlayGame(ref _currPart))
            {
                GameInfo.IsInGame = false;
                _gameSpeedTimer.Stop();
                LadderBoard.AddValid(new KeyValuePair<string, int>("Foo", _gameTetris.GetScore));
                MessageBox.Show("You lost :(");
            }
            else
            {
                try
                {
                    _scoreLabel.Text = _scoreLabel.Text.Substring(0, 7) + _gameTetris.GetScore.ToString();
                }
                catch
                {
                    _scoreLabel.Text = "end";
                }
            }
        }

        void startButt_Click(object sender, EventArgs e)
        {
            //creating label 
            ((Button)sender).Dispose();
            _gameSpeedTimer.Interval = 500;
            _gameSpeedTimer.Tick += gameSpeedTimer_Tick;
            _gameSpeedTimer.Start();
            _scoreLabel = new Label();
            _scoreLabel.Width = 90;
            _scoreLabel.Height = 30;
            _scoreLabel.Top = 30;
            _scoreLabel.BackColor = Color.Olive;
            _scoreLabel.Font = new Font(_scoreLabel.Font.FontFamily, 10);
            _scoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            _scoreLabel.Left = (int)(this.Width * 0.75);
            _scoreLabel.Text = "Score: 0";
            this.Controls.Add(_scoreLabel);
            gameSpeedTimer_Tick(_gameSpeedTimer, e);
        }

        protected override void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // saving CAP
            this._gameSpeedTimer.Dispose();
            base.quitToolStripMenuItem_Click(sender, e);
        }
        protected override void ladderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //propper calling parent form and ladder event 
            this.gameInfo.MainForm.Show();
            this._gameSpeedTimer.Dispose();
            this.Close();
        }
        void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // was interrupted 
            _gameSpeedTimer.Stop();
            gameInfo.MainForm.Show();
            if (GameInfo.IsInGame)
                LadderBoard.AddValid(new KeyValuePair<string, int>("Foo", _gameTetris.GetScore));
            gameInfo.MainForm.GameInfo.IsInGame = false;
            gameInfo.MainForm.mainDropDownLadderStrip.PerformClick();
        }

        protected override void Form1_Load(object sender, EventArgs e)
        {
            _gameTetris = new GameField<SimpleCubePicBox>(12, 10);
            Button startButt = new Button();
            startButt.Width = this.Width / 2;
            startButt.Height = startButt.Width / 4;
            startButt.Top = this.Height / 4;
            startButt.Left = this.Width / 4;
            startButt.Text = "PLAY";
            startButt.BackColor = Color.Crimson;
            this.Controls.Add(startButt);
            startButt.Click += startButt_Click;
            this.gameInfo.IsInGame = true;
            _gameSpeedTimer = new Timer();
            this.KeyPress += Form2_KeyPress;
        }
    }
}
