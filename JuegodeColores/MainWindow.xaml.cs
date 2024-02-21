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
        private DispatcherTimer timer = new DispatcherTimer();
        private Button[] allButtons;
        private Button differentButton;
        private Random random = new Random();
        private const string DIFFERENT_BUTTON_COLOR = "Chocolate";
        private const string COMMON_BUTTON_COLOR = "#6633FF";

        public MainWindow()
        {
            InitializeComponent();

            // Inicializa todos los botones en un arreglo para fácil acceso
            allButtons = new Button[] { Button1, Button2, Button3, Button4, Button5, Button6 };

            // Configura el temporizador
            timer.Interval = TimeSpan.FromSeconds(5); // Cambiado a 5 segundos para este ejemplo
            timer.Tick += Timer_Tick;

            // Asocia el evento MouseEnter a todos los botones
            foreach (Button button in allButtons)
            {
                button.MouseEnter += Button_MouseEnter;
                button.Click += Button_Click; // Asegúrate de que el evento Click también esté conectado
            }

            // Establece el botón diferente inicial
            SetDifferentButton();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            // Inicia el temporizador solo si el ratón está sobre el botón diferente
            if (sender == differentButton)
            {
                timer.Start();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop(); // Detiene el temporizador cuando se hace clic en cualquier botón

            Button clickedButton = sender as Button;
            if (clickedButton == differentButton)
            {
                MessageBox.Show("¡¡¡Ganador!!!", "Mensaje");
                MoveDifferentButton();
            }
            else
            {
                MessageBox.Show("Intenta de nuevo", "Mensaje");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("¡¡¡Lento!!!", "Mensaje");
            MoveDifferentButton();
            timer.Stop(); // Detiene el temporizador después de mostrar el mensaje
        }

        private void SetDifferentButton()
        {
            // Elige el botón diferente al inicio
            differentButton = allButtons[random.Next(allButtons.Length)];
            UpdateButtonColors();
        }

        private void MoveDifferentButton()
        {
            // Cambia el botón diferente de forma aleatoria
            differentButton = allButtons[random.Next(allButtons.Length)];
            UpdateButtonColors();
        }

        private void UpdateButtonColors()
        {
            foreach (var button in allButtons)
            {
                button.Background = (SolidColorBrush)(new BrushConverter().ConvertFromString(COMMON_BUTTON_COLOR));
            }

            differentButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFromString(DIFFERENT_BUTTON_COLOR));
        }
    }
}


