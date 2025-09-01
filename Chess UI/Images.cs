using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Chess_Logic;

namespace Chess_UI
{
    public static class Images
    {
        //Applies image to White and Black pieces
        private static readonly Dictionary<PieceType, ImageSource> whiteSources = new()
        {
            { PieceType.Pawn, LoadImage("Assets/PawnW.png") },
            { PieceType.Rook, LoadImage("Assets/RookW.png") },
            { PieceType.Knight, LoadImage("Assets/knightW.png") },
            { PieceType.Bishop, LoadImage("Assets/BishopW.png") },
            { PieceType.Queen, LoadImage("Assets/QueenW.png") },
            { PieceType.King, LoadImage("Assets/KingW.png") }
        };

        private static readonly Dictionary<PieceType, ImageSource> blackSources = new()
        {
            { PieceType.Pawn, LoadImage("Assets/PawnB.png") },
            { PieceType.Rook, LoadImage("Assets/RookB.png") },
            { PieceType.Knight, LoadImage("Assets/knightB.png") },
            { PieceType.Bishop, LoadImage("Assets/BishopB.png") },
            { PieceType.Queen, LoadImage("Assets/QueenB.png") },
            { PieceType.King, LoadImage("Assets/KingB.png") }
        };

        //Loacds image from filepath
        private static ImageSource LoadImage(string filepath)
        {
            return new BitmapImage(new Uri(filepath, UriKind.Relative));
        }

        //Returns image based on piece color and type
        public static ImageSource GetImage(Player color, PieceType type)
        {
            return color switch
            {
                Player.White => whiteSources[type],
                Player.Black => blackSources[type],
                _ => null
            };
        }
        //Returns image based on piece
        public static ImageSource GetImage(Piece piece)
        {
            if (piece == null)
            {
                return null;
            }

            return GetImage(piece.Color, piece.Type);
        }

    }
}
