using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Karkulacka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Operation ActiveOperation { get; set; }
        public float first { get; set; }
        public float second { get; set; }
        public MainWindow()
        {
            ActiveOperation = Operation.Plus;
            InitializeComponent();
        }

        private void setActiveOperation(object sender, RoutedEventArgs e)
        {
            if (sender is Button butt && butt.Tag is Operation o)
            {
                ActiveOperation = o;
            }
        }

        private float calculate()
        {
            try
            {
                first = float.Parse(firstTextBox.Text);
                second = float.Parse(secondTextBox.Text);
            } catch
            {

            }
            switch (ActiveOperation)
            {
                case Operation.Plus:
                    return first + second;
                case Operation.Minus:
                    return first - second;
                case Operation.Multiplication:
                    return first * second;
                case Operation.Division:
                    if (second == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    return first / second;
                default:
                    throw new ImpossibleStateException();
            }
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            playPH();
            float result = calculate();
            resultTextBlock.Text = result.ToString();
        }

        private void playFromButton(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button butt) || !(butt.Tag is string filename))
            {
                return;
            }
            play(filename);
        }

        private void play(string filename)
        {
            MediaPlayer playMedia = new MediaPlayer(); // making a new instance of the media player
            var uri = new Uri("pack://siteoforigin:,,,/music/" + filename); // browsing to the sound folder and then the WAV file location
            playMedia.Open(uri); // inserting the URI to the media player
            playMedia.Play(); // playing the media file from the media player class

        }

        private void playPH()
        {
            MediaPlayer playMedia = new MediaPlayer(); // making a new instance of the media player
            var uri = new Uri("pack://siteoforigin:,,,/music/ph.mp3"); // browsing to the sound folder and then the WAV file location
            playMedia.Open(uri); // inserting the URI to the media player
            playMedia.Play(); // playing the media file from the media player class

        }
    }
}
