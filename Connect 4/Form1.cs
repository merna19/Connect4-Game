using System.Drawing.Drawing2D;


namespace Connect_4
{

    public partial class Form1 : Form
    {
        Graphics g;
        Point firstCell;
        Size cellSize;
        int rowNo, colNo;
        //initialize your cell properties
        Color cellColor;
        Brush cellBrush;
        Color cellBorderColor;
        Pen cellBorderPen;
        Pen cellOuterBorderPen;
        cell[,] matrix;
        //define players blocks
        Color Player1Color;
        Color Player2Color;
        Brush Player1Brush;
        Brush Player2Brush;
        Size playerSize;
        Point PlayerStart;
        Rectangle Players;
        //modes
        enum MODES { P1, P2, P1_WINS, P2_WINS, DRAW, AI_WINS };
        MODES mode;
        //check matches Direction
        enum DIRECTION { SAME, FORWARD, BACKWARD = -1 };
        //matrix Full indicator
        int matrixFull;
        //AI MODE flag
        bool AI;
        enum DIFFICULTY { EASY, NORMAL, HARD };
        DIFFICULTY difficulty;

        // Random instance for AI (kept at class level to avoid reseeding issues)
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.DarkBlue;
            //initialize LB Cell LT point Location
            firstCell = new Point(200, 200);
            //initialize cell size
            cellSize = new Size(100, 100);
            //initialize matrix size
            rowNo = 5; colNo = 6;

            CreateMatrix();
            //To remove the glitch
            this.DoubleBuffered = true;

            this.Paint += Form1_Paint;
            this.MouseMove += Form1_MouseMove;
            this.MouseDown += Form1_MouseDown;

            //cell initialization 
            cellColor = Color.Blue;
            cellBrush = new SolidBrush(cellColor);
            cellBorderColor = Color.IndianRed;
            cellBorderPen = new Pen(cellBorderColor);
            cellOuterBorderPen = new Pen(cellBorderColor, 5);
            //players initialization
            Player1Color = Color.Gold;
            Player2Color = Color.Silver;
            Player1Brush = new SolidBrush(Player1Color);
            Player2Brush = new SolidBrush(Player2Color);
            PlayerStart = new Point(100, 100);
            playerSize = new Size(80, 80);
            Players = new Rectangle(PlayerStart, playerSize);
            //Set Mode
            mode = MODES.P1;
            //hide label 1
            //label1.Location = new Point(ClientSize.Width/2, ClientSize.Width - 25);
            label1.Hide();
            //matrix full
            matrixFull = 0;

            //AI
            AI = false;
            difficulty = DIFFICULTY.NORMAL;
        }
        protected void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;//avoids the redrawing and glitches with double buffer and paint event argument

            DisplayMatrix();


            if (mode == MODES.P1)
            {
                DisplayPlayer1(Players);
            }
            else if (mode == MODES.P2)
            {
                DisplayPlayer2(Players);
                if (AI)
                {
                    //if it's P2 turn
                    if (mode == MODES.P2 && AI)
                    {
                        AITurn();
                    }
                }
            }
            else if (mode == MODES.DRAW)
            {
                label1.Text = "DRAW";
                label1.Show();
            }

        }
        void CreateMatrix()
        {

            matrix = new cell[rowNo, colNo];
            matrixFull = 0;
            Point location = firstCell;
            for (int row = 0; row < rowNo; row++)
            {
                for (int col = 0; col < colNo; col++)
                {
                    //created new rectangle
                    matrix[row, col] = new cell(location, cellSize);
                    location.X += cellSize.Width;
                }
                location.X = firstCell.X;
                location.Y += cellSize.Height;
            }
            mode = MODES.P1;


        }
        void DisplayMatrix()
        {
            for (int row = 0; row < rowNo; row++)
            {
                for (int col = 0; col < colNo; col++)
                {
                    //display the rectangle
                    g.FillRectangle(cellBrush, matrix[row, col].MATRIX_CELL);
                    g.DrawRectangle(cellBorderPen, matrix[row, col].MATRIX_CELL);
                    //fill the matrix with Coins
                    if (matrix[row, col].player != PLAYER.NONE)
                    {
                        Point coinLoc = new Point(matrix[row, col].MATRIX_CELL.Left + 10, matrix[row, col].MATRIX_CELL.Bottom - Players.Height - 10);
                        Rectangle Pcoin = new Rectangle(coinLoc, playerSize);
                        if (matrix[row, col].player == PLAYER.P1)
                        {
                            DisplayPlayer1(Pcoin);

                        }
                        else if (matrix[row, col].player == PLAYER.P2)
                        {
                            DisplayPlayer2(Pcoin);
                        }

                    }
                }
            }
            //draw outer border
            g.DrawRectangle(cellOuterBorderPen, new Rectangle(firstCell, new Size(colNo * cellSize.Width, rowNo * cellSize.Height)));
        }

        protected void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e != null && (mode == MODES.P1 || ((mode == MODES.P2) && (!AI))))
            {
                if (matrix[0, 0].MATRIX_CELL.Left <= e.X - Players.Width / 2 && matrix[0, colNo - 1].MATRIX_CELL.Right >= e.X + Players.Width / 2)
                {
                    Players.X = e.Location.X - Players.Width / 2;
                    Invalidate();
                }
            }
        }
        protected void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (mode == MODES.P1 || ((mode == MODES.P2) && (!AI)))
            {
                //numberOf Occupied cells
                for (int col = 0; col < colNo; col++)
                {
                    if (matrix[0, col].MATRIX_CELL.Left <= Players.X && matrix[0, col].MATRIX_CELL.Right >= Players.X)
                    {
                        for (int row = rowNo - 1; row >= 0; row--)
                        {
                            if (matrix[row, col].player == PLAYER.NONE)
                            {
                                //matrix[row, col].OCCUPIED = true;
                                matrixFull++;
                                if (mode == MODES.P1)
                                {
                                    matrix[row, col].player = PLAYER.P1;
                                    Invalidate();
                                    if (!checkMatches(row, col, matrix[row, col].player, true))
                                    {
                                        mode = MODES.P2;
                                        if (matrixFull == rowNo * colNo)
                                        {
                                            mode = MODES.DRAW;
                                            Invalidate();
                                        }
                                    }
                                    else
                                    {
                                        WinMode(PLAYER.P1);
                                    }
                                }
                                else if (mode == MODES.P2)
                                {
                                    matrix[row, col].player = PLAYER.P2;
                                    Invalidate();
                                    if (!checkMatches(row, col, matrix[row, col].player, true))
                                    {
                                        mode = MODES.P1;
                                        if (matrixFull == rowNo * colNo)
                                        {
                                            mode = MODES.DRAW;
                                            Invalidate();
                                        }
                                    }
                                    else
                                    {
                                        WinMode(PLAYER.P2);
                                    }
                                }

                                break;
                            }
                        }
                        break;
                    }
                }
            }

        }

        public void DisplayPlayer1(Rectangle coin)
        {
            g.FillEllipse(Player1Brush, coin);
        }
        public void DisplayPlayer2(Rectangle coin)
        {
            g.FillEllipse(Player2Brush, coin);
        }

        int countMatches(int row, int col, DIRECTION dirRow, DIRECTION dirCol, PLAYER p)
        {
            int count = 0;
            int r = row + (int)dirRow;
            int c = col + (int)dirCol;

            while (((r < rowNo) && (r >= 0) && (c < colNo) && (c >= 0)) && (matrix[r, c].player != PLAYER.NONE && matrix[r, c].player == p))
            {
                count++;
                r += (int)dirRow;
                c += (int)dirCol;
            }

            return count;
        }
        bool checkMatches(int row, int col, PLAYER p, bool includeBackwardDiag)
        {
            //check Horizontal
            if (countMatches(row, col, DIRECTION.SAME, DIRECTION.FORWARD, p) + countMatches(row, col, DIRECTION.SAME, DIRECTION.BACKWARD, p) + 1 >= 4)
            {
                return true;
            }
            //check Vertically
            else if (countMatches(row, col, DIRECTION.FORWARD, DIRECTION.SAME, p) + countMatches(row, col, DIRECTION.BACKWARD, DIRECTION.SAME, p) + 1 >= 4)
            {
                return true;
            }
            //check Diagonally LB->RT
            else if (countMatches(row, col, DIRECTION.FORWARD, DIRECTION.FORWARD, p) + countMatches(row, col, DIRECTION.BACKWARD, DIRECTION.BACKWARD, p) + 1 >= 4)
            {
                return true;
            }
            //check Diagonally LT->RB
            else if (includeBackwardDiag)
            {
                if (countMatches(row, col, DIRECTION.FORWARD, DIRECTION.BACKWARD, p) + countMatches(row, col, DIRECTION.BACKWARD, DIRECTION.FORWARD, p) + 1 >= 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        void WinMode(PLAYER p)
        {
            if (p == PLAYER.P1)
            {
                mode = MODES.P1_WINS;
                label1.Text = "Player1 Wins";
                label1.Show();

            }
            else if (p == PLAYER.P2)
            {
                if(AI)
                {
                    mode = MODES.AI_WINS;
                    label1.Text = "AI Wins";
                }
                else
                {
                    mode = MODES.P2_WINS;
                    label1.Text = "Player2 Wins";
                }
                label1.Show();

            }
            Invalidate();
        }

        void restartBtn_Click(object sender, EventArgs e)
        {
            CreateMatrix();
            mode = MODES.P1;
            label1.Hide();

            Invalidate();
        }
        void quitBtn_Click(Object sender, EventArgs e)
        {
            this.Close();
        }
        void P1Gold(object sender, EventArgs e)
        {
            if (Player2Color != Color.Gold)
            {
                Player1Color = Color.Gold;
                Player1Brush = new SolidBrush(Player1Color);
            }
            else
            {
                MessageBox.Show("Both Players can't pick the same color");
            }
        }
        void P1Silver(object sender, EventArgs e)
        {
            if (Player2Color != Color.Silver)
            {
                Player1Color = Color.Silver;
                Player1Brush = new SolidBrush(Player1Color);
            }
            else
            {
                MessageBox.Show("Both Players can't pick the same color");
            }
        }
        void P1Green(object sender, EventArgs e)
        {
            if (Player2Color != Color.PaleGreen)
            {
                Player1Color = Color.PaleGreen;
                Player1Brush = new SolidBrush(Player1Color);
            }
            else
            {
                MessageBox.Show("Both Players can't pick the same color");
            }
        }
        void P1Yellow(object sender, EventArgs e)
        {
            if (Player2Color != Color.Yellow)
            {
                Player1Color = Color.Yellow;
                Player1Brush = new SolidBrush(Player1Color);
            }
            else
            {
                MessageBox.Show("Both Players can't pick the same color");
            }
        }

        private void goldToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Player1Color != Color.Gold)
            {
                Player2Color = Color.Gold;
                Player2Brush = new SolidBrush(Player2Color);
            }
            else
            {
                MessageBox.Show("Both Players can't pick the same color");
            }
        }

        private void silverToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Player1Color != Color.Silver)
            {
                Player2Color = Color.Silver;
                Player2Brush = new SolidBrush(Player2Color);
            }
            else
            {
                MessageBox.Show("Both Players can't pick the same color");
            }
        }

        private void greenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Player1Color != Color.PaleGreen)
            {
                Player2Color = Color.PaleGreen;
                Player2Brush = new SolidBrush(Player2Color);
            }
            else
            {
                MessageBox.Show("Both Players can't pick the same color");
            }
        }

        private void yellowToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (Player1Color != Color.Yellow)
            {
                Player2Color = Color.Yellow;
                Player2Brush = new SolidBrush(Player2Color);
            }
            else
            {
                MessageBox.Show("Both Players can't pick the same color");
            }
        }

        async void AITurn()
        {
            //a delay for the user to see
            await Task.Delay(500);

            //Dropping spot based on difficulty
            int chosenCol = -1;
            if (difficulty == DIFFICULTY.EASY)
            {
                chosenCol = EasyPickPlace();
            }
            else if (difficulty == DIFFICULTY.NORMAL)
            {
                chosenCol = NormalPickPlace();
            }
            else if (difficulty == DIFFICULTY.HARD)
            {
                chosenCol = HardPickPlace();
            }

            if (chosenCol >= 0 && chosenCol < colNo)
            {
                DropCoin(chosenCol, PLAYER.P2);
            }
        }
        //instead of MouseDown event 
        void DropCoin(int col, PLAYER p)
        {
            for (int row = rowNo - 1; row >= 0; row--)
            {
                if (matrix[row, col].player == PLAYER.NONE)
                {
                    matrix[row, col].player = p;
                    matrixFull++;
                    Invalidate();

                    if (!checkMatches(row, col, matrix[row, col].player, true))
                    {
                        if (mode == MODES.P1 && p == PLAYER.P1)
                            mode = MODES.P2;
                        else if (mode == MODES.P2 && p == PLAYER.P2)
                            mode = MODES.P1;
                        else
                            mode = (p == PLAYER.P1) ? MODES.P2 : MODES.P1;
                        //check Draw
                        if (matrixFull == rowNo * colNo)
                        {
                            mode = MODES.DRAW;
                            Invalidate();
                        }
                    }
                    else
                    {
                        WinMode(matrix[row, col].player);
                    }
                    break;

                }
            }
        }

        int GetAvailableRow(int col)
        {
            for (int r = rowNo - 1; r >= 0; r--)
            {
                if (matrix[r, col].player == PLAYER.NONE) return r;
            }
            return -1;
        }
        //easy mode algorithm 
        int EasyPickPlace()
        {

            //choose random col
            //stores all available columns to drop in 
            var available = new List<int>();
            for (int c = 0; c < colNo; c++)
            {
                if (matrix[0, c].player == PLAYER.NONE) available.Add(c);
            }
            //full Matrix check
            if (available.Count == 0) return -1;
            //pick one random col to drop in
            return available[rnd.Next(available.Count)];
        }

        int NormalPickPlace()
        {
            //Normal: skips backward-diagonal detection
            //Try to win
            for (int c = 0; c < colNo; c++)
            {
                int r = GetAvailableRow(c);
                if (r == -1) continue;
                matrix[r, c].player = PLAYER.P2;
                bool win = checkMatches(r, c, PLAYER.P2, false);
                matrix[r, c].player = PLAYER.NONE;
                if (win) return c;
            }
            //Try to block P1
            for (int c = 0; c < colNo; c++)
            {
                int r = GetAvailableRow(c);
                if (r == -1) continue;
                matrix[r, c].player = PLAYER.P1;
                bool willWin = checkMatches(r, c, PLAYER.P1, false);
                matrix[r, c].player = PLAYER.NONE;
                if (willWin) return c;
            }
            //Go for center if available
            int mid = colNo / 2;
            if (matrix[0, mid].player == PLAYER.NONE) return mid;
            //else random
            return EasyPickPlace();
        }

        int HardPickPlace()
        {
            // try to Win
            for (int c = 0; c < colNo; c++)
            {
                int r = GetAvailableRow(c);
                if (r == -1) continue;
                matrix[r, c].player = PLAYER.P2;
                bool win = checkMatches(r, c, PLAYER.P2, true);
                matrix[r, c].player = PLAYER.NONE;
                if (win) return c;
            }
            //try to Block
            for (int c = 0; c < colNo; c++)
            {
                int r = GetAvailableRow(c);
                if (r == -1) continue;
                matrix[r, c].player = PLAYER.P1;
                bool willWin = checkMatches(r, c, PLAYER.P1, includeBackwardDiag: true);
                matrix[r, c].player = PLAYER.NONE;
                if (willWin) return c;
            }
            //pick the closest to your pieces
            for (int c = 0; c < colNo; c++)
            {
                int r = GetAvailableRow(c);
                if (r == -1) continue;
                int horiz = countMatches(r, c, DIRECTION.SAME, DIRECTION.FORWARD, PLAYER.P2) + countMatches(r, c, DIRECTION.SAME, DIRECTION.BACKWARD, PLAYER.P2);
                int vert = countMatches(r, c, DIRECTION.FORWARD, DIRECTION.SAME, PLAYER.P2) + countMatches(r, c, DIRECTION.BACKWARD, DIRECTION.SAME, PLAYER.P2);
                int diagF = countMatches(r, c, DIRECTION.FORWARD, DIRECTION.FORWARD, PLAYER.P2) + countMatches(r, c, DIRECTION.BACKWARD, DIRECTION.BACKWARD, PLAYER.P2);
                int diagB = countMatches(r, c, DIRECTION.FORWARD, DIRECTION.BACKWARD, PLAYER.P2) + countMatches(r, c, DIRECTION.BACKWARD, DIRECTION.FORWARD, PLAYER.P2);
                int score = horiz + vert + diagF + diagB;
                if (score >= 2) return c;
            }
            // center then Random
            int center = colNo / 2;
            if (matrix[0, center].player == PLAYER.NONE) return center;
            return EasyPickPlace();
        }
        public void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AI = true;
            difficulty = DIFFICULTY.EASY;
            comboBox1.Text = "Easy";
            comboBox1.Visible = true;
            label3.Show();
            label1.Hide();
            CreateMatrix();
            Invalidate();
        }
        public void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AI = false;
            comboBox1.Visible = false;
            label3.Hide();
            label1.Hide();
            CreateMatrix();
            Invalidate();
        }
        public enum PLAYER { P1, P2, NONE };
        public class cell
        {
            public cell(Point Location, Size cellSize)
            {
                MATRIX_CELL = new Rectangle(Location, cellSize);
                player = PLAYER.NONE;
            }
            public Rectangle MATRIX_CELL { get; set; }
            public PLAYER player { get; set; }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Hard")
            {
                difficulty = DIFFICULTY.HARD;
            }
            if (comboBox1.Text == "Normal")
            {
                difficulty = DIFFICULTY.NORMAL;
            }
            else if (comboBox1.Text == "Easy")
            {
                difficulty = DIFFICULTY.EASY;
            }
            label1.Hide();
            CreateMatrix();
            Invalidate();
            
        }
    }
}
