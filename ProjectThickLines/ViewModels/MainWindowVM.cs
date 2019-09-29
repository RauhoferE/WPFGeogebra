//-----------------------------------------------------------------------
// <copyright file="MainWindowVM.cs" company="FH Wiener Neustadt">
//     Copyright (c) Emre Rauhofer. All rights reserved.
// </copyright>
// <author>Emre Rauhofer</author>
// <summary>
// This program is a plot. 
// </summary>
//-----------------------------------------------------------------------
namespace ProjectThickLines.ViewModels
{
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Input;
    using ProjectThickLines.Commands;

    /// <summary>
    /// The <see cref="MainWindowVM"/> class.
    /// </summary>
    [Serializable]
    public class MainWindowVM
    {
        /// <summary>
        /// Represents the grid.
        /// </summary>
        private GridVM grid;

        /// <summary>
        /// Represents the function manager.
        /// </summary>
        private FunctionListVM functionListVM;

        /// <summary>
        /// Represents the zoom model.
        /// </summary>
        private ZoomVM zoomVM;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowVM"/> class.
        /// </summary>
        public MainWindowVM()
        {
            this.LoadOldAppState();
        }

        /// <summary>
        /// Gets or sets the grid for the view.
        /// </summary>
        /// <value> A normal <see cref="GridVM"/>. </value>
        public GridVM Grid
        {
            get
            {
                return this.grid;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Error value cant be null.");
                }

                this.grid = value;
            }
        }

        /// <summary>
        /// Gets or sets the function list for the view.
        /// </summary>
        /// <value> A normal <see cref="FunctionListVM"/>. </value>
        public FunctionListVM FunctionListVM
        {
            get
            {
                return this.functionListVM;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Error value cant be null.");
                }

                this.functionListVM = value;
            }
        }

        /// <summary>
        /// Gets or sets the Zoom window.
        /// </summary>
        /// <value> A normal <see cref="ZoomVM"/>. </value>
        public ZoomVM ZoomVM
        {
            get
            {
                return this.zoomVM;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Error value cant be null.");
                }

                this.zoomVM = value;
            }
        }

        /// <summary>
        /// Gets the command to save the app status.
        /// </summary>
        /// <value> A normal <see cref="ICommand"/>. </value>
        public ICommand SaveApp
        {
            get
            {
                return new Command(obj =>
                {
                    this.SaveAppMethod();
                });
            }
        }

        /// <summary>
        /// This method saves the app status.
        /// </summary>
        public void SaveAppMethod()
        {
            try
            {
                var filePath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString())
                    .ToString();
                filePath = filePath + @"\app.dat";
                ApplicationSerealizer.Save(filePath, new MainWindowVMContainer(this.Grid, this.FunctionListVM));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured: " + ex);
            }
        }

        /// <summary>
        /// This method loads the old app state.
        /// </summary>
        private void LoadOldAppState()
        {
            this.ZoomVM = new ZoomVM();
            var filePath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString();
            filePath = filePath + @"\app.dat";
            MainWindowVMContainer masterVmContainer = ApplicationSerealizer.Load(filePath);

            if (masterVmContainer != null)
            {
                this.Grid = new GridVM(masterVmContainer.GridVMContainer);
                this.FunctionListVM = new FunctionListVM(masterVmContainer.FunctionalListVMContainer, this.Grid.SmallestXValue, this.Grid.BigestXValue, this.Grid.SmallestYValue, this.Grid.BigestYValue);
            }
            else
            {
                this.Grid = new GridVM();
                this.FunctionListVM = new FunctionListVM();
                this.FunctionListVM.SmallestXValueGrid = this.Grid.SmallestXValue;
                this.FunctionListVM.BigestXValueGrid = this.Grid.BigestXValue;
                this.FunctionListVM.SmallestYValueGrid = this.Grid.SmallestYValue;
                this.FunctionListVM.BigestYValueGrid = this.Grid.BigestYValue;
            }

            this.Grid.OnXYValueChanged += this.FunctionListVM.ChangeXYValueGrid;
            this.FunctionListVM.OnYMinChanged += this.Grid.ChangeYMinValue;
            this.FunctionListVM.OnYMaxChanged += this.Grid.ChangeYMaxValue;
            this.ZoomVM.OnXYChanged += this.Grid.Zoom;
            this.FunctionListVM.DrawNewPolyLines();
        }
    }
}
