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

namespace PersonalBugTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Dictionary<Button, int> Pairs = new Dictionary<Button, int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            // These Effects values are set in the drop target's
            // DragOver event handler.
            if (e.Effects.HasFlag(DragDropEffects.Copy))
            {
                Mouse.SetCursor(Cursors.Cross);
            }
            else if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Cross);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }

        private void Minimise_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Maximise_Click(object sender, RoutedEventArgs e)
        {

            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void add(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.StackPanel tn = new System.Windows.Controls.StackPanel();
            System.Windows.Controls.TextBox tb = new System.Windows.Controls.TextBox();
            System.Windows.Controls.Button bt = new System.Windows.Controls.Button();
            System.Windows.Controls.Button btn = new System.Windows.Controls.Button();

            int rows = todoListGrid.RowDefinitions.Count();

            tn.MinHeight = 25;
            tn.Background = (Brush)new BrushConverter().ConvertFrom("#292B2F");
            tn.Orientation = Orientation.Horizontal;
            tn.Margin = new Thickness(0);

            tb.MaxLength = 24;
            tb.VerticalContentAlignment = VerticalAlignment.Center;
            tb.HorizontalAlignment = HorizontalAlignment.Left;
            tb.FontWeight = FontWeights.Bold;
            tb.Background = new SolidColorBrush(Colors.Transparent);
            tb.Foreground = new SolidColorBrush(Colors.Gray);
            tb.BorderThickness = new Thickness(0);
            tb.Margin = new Thickness(10);
            tb.Text = "Add Text Here";

            bt.Width = 20;
            bt.Height = 20;
            bt.Content = "+";
            bt.HorizontalAlignment = HorizontalAlignment.Right;
            bt.BorderThickness = new Thickness(0);
            bt.Background = new SolidColorBrush(Colors.Transparent);
            bt.Foreground = new SolidColorBrush(Colors.Gray);
            bt.Cursor = Cursors.Hand;
            bt.Click += newWindow;

            btn.Width = 20;
            btn.Height = 20;
            btn.Content = "-";
            btn.HorizontalAlignment = HorizontalAlignment.Right;
            btn.BorderThickness = new Thickness(0);
            btn.Margin = new Thickness(0, 0, 20, 0);
            btn.Background = new SolidColorBrush(Colors.Transparent);
            btn.Foreground = new SolidColorBrush(Colors.Gray);
            btn.Cursor = Cursors.Hand;
            btn.Click += remove;

            tn.Children.Add(tb);

            Grid.SetColumn(tn, 1);
            Grid.SetColumn(bt, 1);
            Grid.SetColumn(btn, 1);
            Grid.SetRow(tn, rows );
            Grid.SetRow(bt, rows );
            Grid.SetRow(btn, rows );
            Pairs[btn] = rows;

            todoListGrid.Children.Add(tn);
            todoListGrid.Children.Add(bt);
            todoListGrid.Children.Add(btn);

            todoListGrid.RowDefinitions.Add(new RowDefinition());

          
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            if (todoListGrid.RowDefinitions.Count >= 3)
            {
                todoListGrid.RowDefinitions.Remove(todoListGrid.RowDefinitions[Pairs[(Button)sender]]);
            }
        }

            private void newWindow(object sender, RoutedEventArgs e)
        {
            new AddWindow().Show();
        }

        
      
    }
}
