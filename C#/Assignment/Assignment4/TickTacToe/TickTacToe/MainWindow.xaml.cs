using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TickTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MarkType[] mResults;
        private bool mPlayer1Turn;
        private bool mGameEnded;


        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }
        private void NewGame()
        {
            mResults = new MarkType[9];

            //Initially all the cells are free(Not Set)
            for (int i = 0; i < mResults.Length; i++)
                mResults[i] = MarkType.Free;

            //make sure player 1 starts the game
            mPlayer1Turn = true;


            //Iterate every button on grid
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });
            mGameEnded = false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mGameEnded) {
                NewGame();
                return;
            }

            // sender to button
            var button = (Button)sender;

            //finds which button got clicked
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            // do nothing if already a value is present
            if (mResults[index] != MarkType.Free)
                return;

            //set the cell value based on player's turn
            mResults[index] = mPlayer1Turn? MarkType.Cross : MarkType.Nought;

            button.Content = mPlayer1Turn ? "X" : "0";

            //Noughts to green
            if (!mPlayer1Turn)
                button.Foreground = Brushes.Red;

            //bitwise operators
            mPlayer1Turn ^= true;

            //find the winner 
            CheckForWinner();
        }
        private void CheckForWinner()
        {
            //we have 8 possible ways to win

            //Horizontal way
            // Row 0
            if (mResults[0]!= MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                mGameEnded = true;
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }

            // Row 1
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                mGameEnded = true;
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }

            // Row 2
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                mGameEnded = true;
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }



            //Vertical Wins
            // Column 0
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                mGameEnded = true;
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }

            // Column 1
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                mGameEnded = true;
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }

            // Column 2
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                mGameEnded = true;
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }


            // Diagonal Wins

            // Left Diagonal
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mGameEnded = true;
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }

            // Right Diagonal
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                mGameEnded = true;
                Button0_2.Background = Button1_1.Background = Button2_0.Background = Brushes.Green;
            }





            if (!mResults.Any(f=> f== MarkType.Free))
            {
                //Game Ended
                mGameEnded = true;
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    
                    button.Background = Brushes.Orange;
                    
                });
            }
        }
    }
}
