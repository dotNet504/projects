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
        int initSwitch = 0;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (initSwitch == 0)
            {
                InitializeBoard(e.Graphics);
                initSwitch = 1;
            }
            else
            {
                RedraweBoard(e.Graphics);
            }

        }



        #region Initialize Chess Board

        private void RedraweBoard(Graphics g)
        {
            //MessageBox.Show("inredraw");

            DrawBoard(g);
            foreach (var w in _whites)
            {
                g.DrawImage(w.Icon, w.X, w.Y, 50, 50);
            }
            foreach (var w in _blacks)
            {
                g.DrawImage(w.Icon, w.X, w.Y, 50, 50);
            }
        }


        private void DrawBoard(Graphics g)
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


        }


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





        int moveSwitch = 0;
        bool whiteTurnSwitch = true;
        Pieces currentPiece;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //convert the X Y 
            int boardX = (e.X - 10) / 80;
            int boardY = (e.Y - 10) / 80;
            Pieces temp;

            //Graphics
            Graphics g;
            g = this.CreateGraphics();


            //select the current piece
            if (whiteTurnSwitch)
            {
                temp = _whites.Find(x => ((x.X == 30 + boardX * 80) && (x.Y == 30 + boardY * 80)));
            }
            else
            {
                temp = _blacks.Find(x => ((x.X == 30 + boardX * 80) && (x.Y == 30 + boardY * 80)));
            }
            
            //if sth is selected and nothing is selected in the last step
            if (temp != null )
            {
                //MessageBox.Show("step 1");
                currentPiece = temp;
                moveSwitch = 1;
                return;
            }

            //sth is selected and will move in this step
            if (moveSwitch == 1) 
            {
                //MessageBox.Show("step 2");
                string currentPieceName = currentPiece.Name;
                if (currentPieceName.Contains("Knight"))
                {
                    //if the knight is moved, return 0, otherwise,return 1
                    moveSwitch = KnightProcessing(currentPiece, e.X, e.Y);
                }
                if (currentPieceName.Contains("Bish"))
                {
                    int aaaaaa = 1;
                    BishopProcessing(currentPiece, e.X, e.Y);
                }
                if (moveSwitch==0)
                {
                    whiteTurnSwitch = !whiteTurnSwitch;
                    RedraweBoard(g);
                }
        

            }

        }

        private bool BishopProcessing(Pieces currentPiece, int X, int Y)
        {
            return true;
        }

        private bool checkEmptyGrid(int X, int Y)
        {
            //MessageBox.Show("check whether it is empty");
            int boardX = (X - 10) / 80;
            int boardY = (Y - 10) / 80;
            Pieces temp1 = _whites.Find(x => ((x.X == 30 + boardX * 80) && (x.Y == 30 + boardY * 80)));
            Pieces temp2 = _blacks.Find(x => ((x.X == 30 + boardX * 80) && (x.Y == 30 + boardY * 80)));

            //no poece in that grid
            if ((temp1 == null) || (temp2 == null))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool checkEnemyGrid(Pieces currentKnight, int X, int Y)
        {
            //MessageBox.Show("looking for enemy");
            int currentPieceBoardX = (currentKnight.X - 10) / 80;
            int currentPieceBoardY = (currentKnight.Y - 10) / 80;
            int targetgridBoardX = (X - 10) / 80;
            int targetgridBoardY = (Y - 10) / 80;
            Pieces temp;


            if (whiteTurnSwitch ==true)
            {
                temp = _blacks.Find(x => ((x.X == 30 + targetgridBoardX * 80) && (x.Y == 30 + targetgridBoardY * 80)));
            }
            else
            {
                temp = _whites.Find(x => ((x.X == 30 + targetgridBoardX * 80) && (x.Y == 30 + targetgridBoardY * 80)));
            }
            
            //if enemy is not empty
            if (temp != null)
            {
                return true;
            }
            //if enemy is empty
            else
            {
                return false;
            }
        }

        private void removeEnemyPiece(Pieces currentKnight, int X, int Y)
        {
            //MessageBox.Show("removing sth");
            int currentPieceBoardX = (currentKnight.X - 10) / 80;
            int currentPieceBoardY = (currentKnight.Y - 10) / 80;
            int targetgridBoardX = (X - 10) / 80;
            int targetgridBoardY = (Y - 10) / 80;

            Pieces temp;


            if (whiteTurnSwitch == true)
            {
                temp = _blacks.Find(x => ((x.X == 30 + targetgridBoardX * 80) && (x.Y == 30 + targetgridBoardY * 80)));
            }
            else
            {
                temp = _whites.Find(x => ((x.X == 30 + targetgridBoardX * 80) && (x.Y == 30 + targetgridBoardY * 80)));
            }

 
            if (whiteTurnSwitch==true)
            {
                _blacks.RemoveAll(x => ((x.X == 30 + targetgridBoardX * 80) && (x.Y == 30 + targetgridBoardY* 80)));
            }
            else
            {
                _whites.RemoveAll(x => ((x.X == 30 + targetgridBoardX* 80) && (x.Y == 30 + targetgridBoardY* 80)));
            }

           }

        private bool CheckKnightMove(Pieces currentKnight, int X, int Y)
        {

            int currentPieceBoardX = (currentKnight.X - 10) / 80;
            int currentPieceBoardY = (currentKnight.Y - 10) / 80;
            int targetgridBoardX = (X - 10) / 80;
            int targetgridBoardY = (Y - 10) / 80;

            //MessageBox.Show(    Math.Abs(currentPieceBoardX - targetgridBoardX).ToString()   );
            //MessageBox.Show(   Math.Abs(currentPieceBoardY - targetgridBoardY).ToString()    );

            if (  (Math.Abs(currentPieceBoardX - targetgridBoardX) == 1) && (Math.Abs(currentPieceBoardY - targetgridBoardY) == 2)   )
            {
                
                return true;
            }
            if ((Math.Abs(currentPieceBoardX - targetgridBoardX) == 2) && (Math.Abs(currentPieceBoardY - targetgridBoardY) == 1))
            {
                return true;
            }
            return false;




        }


        private int KnightProcessing(Pieces currentKnight, int X,int Y)
        {
            if (CheckKnightMove(currentKnight, X, Y))
            {
                // if the target grid is empty, move the piece on it. 
                if (checkEmptyGrid(X, Y))
                {
                    currentPiece.X = 30 + ((X - 10) / 80) * 80;
                    currentPiece.Y = 30 + ((Y - 10) / 80) * 80;
                }
                //if the target grid is occupied by enemy, replaceing the Enemy piece 
                if (checkEnemyGrid(currentKnight, X, Y))
                {
                    //MessageBox.Show("enemy is found");
                    removeEnemyPiece(currentKnight, X, Y);
                    currentPiece.X = 30 + ((X - 10) / 80) * 80;
                    currentPiece.Y = 30 + ((Y - 10) / 80) * 80;
                }


                if (whiteTurnSwitch == true)
                {
                    foreach (var w in _whites)
                    {
                        if (w.Name == currentPiece.Name)
                        {
                            w.X = currentPiece.X;
                            w.Y = currentPiece.Y;
                        }
                    }
                }
                else
                {
                    foreach (var w in _blacks)
                    {
                        if (w.Name == currentPiece.Name)
                        {
                            w.X = currentPiece.X;
                            w.Y = currentPiece.Y;
                        }
                    }
                }
                return 0;
            }
            else
            {
                return 1;
            }






        }
    }
}
