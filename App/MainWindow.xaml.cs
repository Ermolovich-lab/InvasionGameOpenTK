using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using EngineLibrary;
using OpenTK.Graphics;
using GameLibrary;
using System.Windows.Media;
using WpfOpenGlControl;
using Color = System.Windows.Media.Color;
using GameLibrary.InvasionGame;

namespace Invasion
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game = new Game();

        public MainWindow()
        {
            InitializeComponent();

            GameEvents.EndGame += EndGame;
            GameEvents.PlayerState += PlayerState;
            GameEvents.Wave += delegate (string wave) { Wave.Text = wave; };
            game.ChengeScene(new StartScene());

            formHost.Visibility = Visibility.Hidden;
        }

        private void WindowsFormsHost_Initialized(object sender, EventArgs e)
        {
            glControl.MakeCurrent();
        }

        private void glControl_Load(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.Texture2D);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Viewport(0, 0, 1290, 750);

            _loaded = false;
        }

        private void glControl_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Render();
            glControl.Invalidate();
        }

        private bool _loaded;

        private void Render()
        {
            if (!_loaded)
                return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(System.Drawing.Color.FromArgb(1, 163, 213, 155));
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, glControl.Width, glControl.Height, 0, 0, 1);

            game.Rendering();

            glControl.SwapBuffers();
        }

        private void GLControl_Resize(object sender, EventArgs e)
        {
            if (!_loaded)
                return;
            GL.Viewport(0, 0, glControl.Width, glControl.Height);
            glControl.Invalidate();
        }

        private void EndGame(string winPlayer)
        {
            formHost.Visibility = Visibility.Hidden;
            Panel.Visibility = Visibility.Hidden;

            if (winPlayer != null)
            {
                if (winPlayer == "You Win.")
                {
                    Background = new SolidColorBrush(Color.FromRgb(255, 255, 22));
                    WinPanel.Content = "You are win!";
                }
                else
                {
                    Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    WinPanel.Content = "You are lose";
                }
            }

            WinPanel.Visibility = Visibility.Visible;

            GameEvents.EndGame -= EndGame;
            GameEvents.PlayerState -= PlayerState;
        }

        private void PlayerState(string player, string state)
        {
            if (player == "FirstPlayer")
            {
                FisrtState.Text = state;
            }
            else
            {
                SecondState.Text = state;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _loaded = true;
            playButton.Visibility = Visibility.Hidden;
            start.Visibility = Visibility.Hidden;
            formHost.Visibility = Visibility;
            Panel.Visibility = Visibility.Visible;
        }
    }
}
