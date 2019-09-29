//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="FH Wiener Neustadt">
//     Copyright (c) Emre Rauhofer. All rights reserved.
// </copyright>
// <author>Emre Rauhofer</author>
// <summary>
// This program is a plot. 
// </summary>
//-----------------------------------------------------------------------
namespace ProjectThickLines.Views
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using ProjectThickLines.ViewModels;

    /// <summary>
    /// The <see cref="MainWindow"/> partial class.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// This  method is called when the user exits the application.
        /// </summary>
        /// <param name="sender"> The object sender. </param>
        /// <param name="e"> The exit event args. </param>
        private void OnApplicationExit(object sender, CancelEventArgs e)
        {
            MainWindowVM mvM = (MainWindowVM)this.DataContext;
            mvM.SaveAppMethod();
        }

        /// <summary>
        /// This method fires when the left mouse button is clicked in the canvas.
        /// </summary>
        /// <param name="sender"> The object sender. </param>
        /// <param name="e"> The event args. </param>
        private void Canvas_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                MainWindowVM mVM = (MainWindowVM)this.DataContext;
                mVM.ZoomVM.GetPoint(e.GetPosition((Canvas)sender));
            }
        }

        /// <summary>
        /// This method fires when the mouse is moved in the canvas.
        /// </summary>
        /// <param name="sender"> The object sender. </param>
        /// <param name="e"> The event args. </param>
        private void Canvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                MainWindowVM mVM = (MainWindowVM)this.DataContext;
                mVM.ZoomVM.GetWidthAndHeight(e.GetPosition((Canvas)sender));
            }
        }

        /// <summary>
        /// This method fires when the mouse is clicked in the canvas.
        /// </summary>
        /// <param name="sender"> The object sender. </param>
        /// <param name="e"> The event args. </param>
        private void Canvas_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindowVM mVM = (MainWindowVM)this.DataContext;
            mVM.ZoomVM.ScaleAxis(e.GetPosition((Canvas)sender));
        }
    }
}
