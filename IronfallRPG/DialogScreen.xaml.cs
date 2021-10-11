using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ironfall_Engine.Events;
using Ironfall_Engine.ViewModels;

namespace IronfallRPG
{
    /// <summary>
    /// Interaction logic for DialogScreen.xaml
    /// </summary>
    public partial class DialogScreen : Window
    {
        private GameSession _gameSession = new GameSession();

        public DialogScreen()
        {
            InitializeComponent();
            _gameSession.OnMessageRaised += OnGameMessageRaised;

            DataContext = _gameSession;
        }
        private void OnGameMessageRaised(object sender, GameMessageEventArgs e)
        {
            GameMessages.Document.Blocks.Add(new Paragraph(new Run(e.Message)));
            GameMessages.ScrollToEnd();
        }

        private void OnClick_Answer(object sender, RoutedEventArgs e)
        {
            double nmb = (double)((Button)e.Source).DataContext;

            _gameSession.ChooseDialogOption(nmb);
        }
    }
}
