using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asx_Assign5
{
    public partial class Form1 : Form
    {
        public List<Pieces> _whites;
        public List<Pieces> _blacks;
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            InitializeBoard(e.Graphics);
        }

        #region Initialize Chess Board
        private void InitializeBoard(Graphics g)
        {
            int _bX = 10, _bY = 10;
            int _bWidth = 640, _bHeight = 640; //must be multiple of 8
            Brush _borderColor = Brushes.Black;
            Brush[] _bColor = { Brushes.DarkGray, Brushes.Beige };
            //drawing squares
            int spaceX = _bWidth / 8;
            int spaceY = _bHeight / 8;
            for (int c = 0; c < 8; c++)
            {
                for (int r = 0; r < 8; r++)
                {
                    g.FillRectangle(_bColor[(c + r) % 2], _bX + c * spaceX, _bY + r * spaceY, spaceX, spaceY);
                }
            }
            for (int i = 0; i < 8; i++)
            {
                g.DrawLine(new Pen(_borderColor), _bX, _bY + i * spaceY, _bX + _bWidth, _bY + i * spaceY);
                g.DrawLine(new Pen(_borderColor), _bX + i * spaceX, _bY, _bX + i * spaceX, _bY + _bHeight);
            }
            //draw border
            g.DrawRectangle(new Pen(_borderColor, 1), new Rectangle(_bX, _bY, _bWidth, _bHeight));

            InitializePieces(g);

        }

        private void InitializePieces(Graphics g)
        {
            LoadWhitePieces();
            foreach (var w in _whites)
            {
                g.DrawImage(w.Icon, w.X, w.Y, 50, 50);
            }

            LoadBlackPieces();
            foreach (var b in _blacks)
            {
                g.DrawImage(b.Icon, b.X, b.Y, 50, 50);
            }

        }
        #endregion


        #region Load Pieces
        private void LoadWhitePieces()
        {
            int xSpace = -10;
            _whites = new List<Pieces>();

            int iXPawn = 0;
            for (int i = 0; i < 8; i++)
            {
                var p = new Pieces
                {
                    Name = "Pawn" + (i + 1),
                    Icon = Image.FromFile(@"../../../Asx_Assign5/Images/WhitePawn.png"),
                    X = 40 + xSpace + iXPawn,
                    Y = 120 + xSpace
                };
                _whites.Add(p);
                iXPawn += 80;
            }
            _whites.Add(new Pieces
            {
                Name = "King",
                Icon = Image.FromFile(@"../../../Asx_Assign5/Images/WhiteKing.png"),
                X = 360 + xSpace,
                Y = 40 + xSpace
            });
            _whites.Add(new Pieces
            {
                Name = "Queen",
                Icon = Image.FromFile(@"../../../Asx_Assign5/Images/WhiteQueen.png"),
                X = 280 + xSpace,
                Y = 40 + xSpace
            });
            int iXBishop = 0;
            for (int i = 0; i < 2; i++)
            {
                var p = new Pieces
                {
                    Name = "Bishop" + (i + 1),
                    Icon = Image.FromFile(@"../../../Asx_Assign5/Images/WhiteBishop.png"),
                    X = 200 + xSpace + iXBishop,
                    Y = 40 + xSpace
                };
                _whites.Add(p);
                iXBishop += 240;
            }

            int iXKnight = 0;
            for (int i = 0; i < 2; i++)
            {
                var p = new Pieces
                {
                    Name = "Knight" + (i + 1),
                    Icon = Image.FromFile(@"../../../Asx_Assign5/Images/WhiteKnight.png"),
                    X = 120 + xSpace + iXKnight,
                    Y = 40 + xSpace
                };
                _whites.Add(p);
                iXKnight += 400;
            }

            int iXRook = 0;
            for (int i = 0; i < 2; i++)
            {
                var p = new Pieces
                {
                    Name = "Rook" + (i + 1),
                    Icon = Image.FromFile(@"../../../Asx_Assign5/Images/WhiteRook.png"),
                    X = 40 + xSpace + iXRook,
                    Y = 40 + xSpace
                };
                _whites.Add(p);
                iXRook += 560;
            }

        }

        private void LoadBlackPieces()
        {
            int xSpace = -10;
            _blacks = new List<Pieces>();

            int iXPawn = 0;
            for (int i = 0; i < 8; i++)
            {
                var p = new Pieces
                {
                    Name = "Pawn" + (i + 1),
                    Icon = Image.FromFile(@"../../../Asx_Assign5/Images/BlackPawn.png"),
                    X = 40 + xSpace + iXPawn,
                    Y = 520 + xSpace
                };
                _blacks.Add(p);
                iXPawn += 80;
            }
            _blacks.Add(new Pieces
            {
                Name = "King",
                Icon = Image.FromFile(@"../../../Asx_Assign5/Images/BlackKing.png"),
                X = 360 + xSpace,
                Y = 600 + xSpace
            });
            _blacks.Add(new Pieces
            {
                Name = "Queen",
                Icon = Image.FromFile(@"../../../Asx_Assign5/Images/BlackQueen.png"),
                X = 280 + xSpace,
                Y = 600 + xSpace
            });
            int iXBishop = 0;
            for (int i = 0; i < 2; i++)
            {
                var p = new Pieces
                {
                    Name = "Bishop" + (i + 1),
                    Icon = Image.FromFile(@"../../../Asx_Assign5/Images/BlackBishop.png"),
                    X = 200 + xSpace + iXBishop,
                    Y = 600 + xSpace
                };
                _blacks.Add(p);
                iXBishop += 240;
            }

            int iXKnight = 0;
            for (int i = 0; i < 2; i++)
            {
                var p = new Pieces
                {
                    Name = "Knight" + (i + 1),
                    Icon = Image.FromFile(@"../../../Asx_Assign5/Images/BlackKnight.png"),
                    X = 120 + xSpace + iXKnight,
                    Y = 600 + xSpace
                };
                _blacks.Add(p);
                iXKnight += 400;
            }

            int iXRook = 0;
            for (int i = 0; i < 2; i++)
            {
                var p = new Pieces
                {
                    Name = "Rook" + (i + 1),
                    Icon = Image.FromFile(@"../../../Asx_Assign5/Images/BlackRook.png"),
                    X = 40 + xSpace + iXRook,
                    Y = 600 + xSpace
                };
                _blacks.Add(p);
                iXRook += 560;
            }

        }
        #endregion

    }
}
