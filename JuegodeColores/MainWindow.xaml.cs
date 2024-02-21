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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace JuegodeColores
{
    public partial class MainWindow : Window
    {
        private Button differentButton;
        private Random random = new Random();
        private DispatcherTimer timer;
        private TimeSpan timeAllowed = TimeSpan.FromSeconds(3); // Tiempo permitido inicialmente

        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Asignar los botones diferentes y sus eventos de clic
            AssignDifferentButton();

            // Iniciar el temporizador
            timer = new DispatcherTimer();
            timer.Interval = timeAllowed;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void AssignDifferentButton()
        {
            // Obtener un índice aleatorio para el botón diferente
            int index = random.Next(0, grid.Children.Count - 1);

            // Asignar el botón diferente y cambiar su color
            differentButton = (Button)grid.Children[index];
            differentButton.Click += DifferentButton_Click;
            differentButton.Background = Brushes.Red;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Cambiar el color y mostrar el mensaje de "Lento" si el temporizador llega a cero
            timer.Stop();
            differentButton.Background = Brushes.Green;
            MessageBox.Show("¡¡¡Lento!!!", "Mensaje");
        }

        private void DifferentButton_Click(object sender, RoutedEventArgs e)
        {
            // Detener el temporizador y mostrar el mensaje de "Ganador"
            timer.Stop();
            MessageBox.Show("¡¡¡Ganador!!!", "Mensaje");

            // Reiniciar el juego
            InitializeGame();
        }
    }
}

