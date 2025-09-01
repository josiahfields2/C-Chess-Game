using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chess_Logic;

namespace Chess_UI
{
    
    public partial class MainWindow : Window
    {
        //2D array to hold images for each square on the chessboard
        private readonly Image[,] pieceImages = new Image[8, 8];

        private GameState gameState;

        
        public MainWindow()
        {
            //Sets up the chessboard and initializes the game state
            InitializeComponent();
            InitializeBoard();

            gameState = new GameState(Player.White, Board.Initial());
            DrawBoard(gameState.Board);
        }

        private void InitializeBoard()
        {
            //Creates an 8x8 grid of Image controls to represent the chessboard squares
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Image image = new Image();
                    {
                        pieceImages[r, c] = image;
                        PieceGrid.Children.Add(image);
                    }
                }
            }

        }

        private void DrawBoard(Board board)
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Piece piece = board[r, c];
                    pieceImages[r, c].Source = Images.GetImage(piece);
                    
                }
            }
        }

    }
}