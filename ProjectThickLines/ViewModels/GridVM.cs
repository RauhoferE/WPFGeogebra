//-----------------------------------------------------------------------
// <copyright file="GridVM.cs" company="FH Wiener Neustadt">
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
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// The <see cref="GridVM"/> class.
    /// </summary>
    public class GridVM : INotifyPropertyChanged
    {
        /// <summary>
        /// The y axis <see cref="GridLines"/>.
        /// </summary>
        private ObservableCollection<GridLines> yAxeGrid;

        /// <summary>
        /// The x axis <see cref="GridLines"/>.
        /// </summary>
        private ObservableCollection<GridLines> xAxeGrid;

        /// <summary>
        /// The start of the y axis.
        /// </summary>
        private ObservableCollection<GridLines> yAxeStart;

        /// <summary>
        /// The start of the x axis.
        /// </summary>
        private ObservableCollection<GridLines> xAxeStart;

        /// <summary>
        /// The grid interval of the x axis.
        /// </summary>
        private float gridXInterval;

        /// <summary>
        /// The grid interval of the y axis.
        /// </summary>
        private float gridYInterval;

        /// <summary>
        /// The opacity of the x axis grid.
        /// </summary>
        private double gridXOpacity;

        /// <summary>
        /// The opacity of the y axis grid.
        /// </summary>
        private double gridYOpacity;

        /// <summary>
        /// The smallest value on the x axis.
        /// </summary>
        private double smallestXValue;

        /// <summary>
        /// The biggest value on the x axis.
        /// </summary>
        private double bigestXValue;

        /// <summary>
        /// The smallest value on the y axis.
        /// </summary>
        private double smallestYValue;

        /// <summary>
        /// The biggest value on the y axis.
        /// </summary>
        private double bigestYValue;

        /// <summary>
        /// The opacity of the x axis.
        /// </summary>
        private double xOpacity;

        /// <summary>
        /// The opacity of the y axis.
        /// </summary>
        private double yOpacity;

        /// <summary>
        /// The color of the x axis.
        /// </summary>
        private Color colorXAxis;

        /// <summary>
        /// The color of the y axis.
        /// </summary>
        private Color colorYAxis;

        /// <summary>
        /// The color of the x axis grid.
        /// </summary>
        private Color colorXAxisGrid;

        /// <summary>
        /// The color of the y axis grid.
        /// </summary>
        private Color colorYAxisGrid;

        /// <summary>
        /// Initializes a new instance of the <see cref="GridVM"/> class.
        /// </summary>
        public GridVM()
        {
            this.xAxeStart = new ObservableCollection<GridLines>();
            this.yAxeStart = new ObservableCollection<GridLines>();
            this.xAxeGrid = new ObservableCollection<GridLines>();
            this.yAxeGrid = new ObservableCollection<GridLines>();
            this.colorXAxis = Colors.Black;
            this.colorYAxis = Colors.Black;
            this.colorXAxisGrid = Colors.Gray;
            this.colorYAxisGrid = Colors.Gray;
            this.gridXInterval = 1;
            this.gridYInterval = 1;
            this.gridXOpacity = 0.1;
            this.gridYOpacity = 0.1;
            this.xOpacity = 1;
            this.yOpacity = 1;
            this.smallestXValue = -8;
            this.smallestYValue = -8;
            this.bigestXValue = 10;
            this.bigestYValue = 10;
            this.DrawXAxis();
            this.DrawYAxis();
            this.DrawXAxisGrid();
            this.DrawYAxisGrid();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GridVM"/> class.
        /// </summary>
        /// <param name="gridVMContainer"> The container of the saved grid. </param>
        public GridVM(GridVMContainer gridVMContainer)
        {
            this.xAxeStart = new ObservableCollection<GridLines>();
            this.yAxeStart = new ObservableCollection<GridLines>();
            this.xAxeGrid = new ObservableCollection<GridLines>();
            this.yAxeGrid = new ObservableCollection<GridLines>();
            this.colorXAxis = gridVMContainer.ColorXAxis;
            this.colorYAxis = gridVMContainer.ColorYAxis;
            this.colorXAxisGrid = gridVMContainer.ColorXAxisGrid;
            this.colorYAxisGrid = gridVMContainer.ColorYAxisGrid;
            this.gridXInterval = gridVMContainer.GridXInterval;
            this.gridYInterval = gridVMContainer.GridYInterval;
            this.gridXOpacity = gridVMContainer.GridXOpacity;
            this.gridYOpacity = gridVMContainer.GridYOpacity;
            this.xOpacity = gridVMContainer.XOpacity;
            this.yOpacity = gridVMContainer.YOpacity;
            this.smallestXValue = gridVMContainer.SmallestXValue;
            this.smallestYValue = gridVMContainer.SmallestYValue;
            this.bigestXValue = gridVMContainer.BigestXValue;
            this.bigestYValue = gridVMContainer.BigestYValue;
            this.DrawXAxis();
            this.DrawYAxis();
            this.DrawXAxisGrid();
            this.DrawYAxisGrid();
        }

        /// <summary>
        /// This event fires when the biggest and smallest x or y values change.
        /// </summary>
        public event EventHandler<IntValueEventArgs> OnXYValueChanged;

        /// <summary>
        /// This event fires when the property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the <see cref="ObservableCollection{T}"/> of the x axis.
        /// </summary>
        /// <value> A normal <see cref="ObservableCollection{T}"/>. </value>
        public ObservableCollection<GridLines> XAXe
        {
            get
            {
                return this.xAxeStart;
            }
        }

        /// <summary>
        /// Gets the <see cref="ObservableCollection{T}"/> of the y axis.
        /// </summary>
        /// <value> A normal <see cref="ObservableCollection{T}"/>. </value>
        public ObservableCollection<GridLines> YAXe
        {
            get
            {
                return this.yAxeStart;
            }
        }

        /// <summary>
        /// Gets the <see cref="ObservableCollection{T}"/> of the x axis grid.
        /// </summary>
        /// <value> A normal <see cref="ObservableCollection{T}"/>. </value>
        public ObservableCollection<GridLines> XAxeGrid
        {
            get
            {
                return this.xAxeGrid;
            }
        }

        /// <summary>
        /// Gets the <see cref="ObservableCollection{T}"/> of the y axis grid.
        /// </summary>
        /// <value> A normal <see cref="ObservableCollection{T}"/>. </value>
        public ObservableCollection<GridLines> YAxeGrid
        {
            get
            {
                return this.yAxeGrid;
            }
        }

        /// <summary>
        /// Gets or sets the color of the x axis.
        /// </summary>
        /// <value> A normal <see cref="Color"/>. </value>
        public Color ColorXAxis
        {
            get
            {
                return this.colorXAxis;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Error color cant be null.");
                }

                this.colorXAxis = value;
                this.DrawXAxis();
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the color of the y axis.
        /// </summary>
        /// <value> A normal <see cref="Color"/>. </value>
        public Color ColorYAxis
        {
            get
            {
                return this.colorYAxis;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Error color cant be null.");
                }

                this.colorYAxis = value;
                this.DrawYAxis();
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the color of the x axis grid.
        /// </summary>
        /// <value> A normal <see cref="Color"/>. </value>
        public Color ColorXAxisGrid
        {
            get
            {
                return this.colorXAxisGrid;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Error color cant be null.");
                }

                this.colorXAxisGrid = value;
                this.DrawXAxisGrid();
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the color of the y axis grid.
        /// </summary>
        /// <value> A normal <see cref="Color"/>. </value>
        public Color ColorYAxisGrid
        {
            get
            {
                return this.colorYAxisGrid;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Error color cant be null.");
                }

                this.colorYAxisGrid = value;
                this.DrawYAxisGrid();
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the opacity of the x axis.
        /// </summary>
        /// <value> A normal double value. </value>
        public double XOpacity
        {
            get
            {
                return this.xOpacity;
            }

            set
            {
                if (value > 1 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("Error the Value can only be between 1 and 0.");
                }

                this.xOpacity = value;
                this.DrawXAxis();
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the smallest value of the x axis.
        /// </summary>
        /// <value> A normal integer value. </value>
        public double SmallestXValue
        {
            get
            {
                return this.smallestXValue;
            }

            set
            {
                if (value > this.bigestXValue)
                {
                    throw new ArgumentOutOfRangeException("Error the value cant be greater than the biggest value.");
                }

                this.smallestXValue = value;
                this.DrawYAxis();
                this.DrawYAxisGrid();
                this.FireOnXYValueChanged(new IntValueEventArgs(this.smallestXValue, new SmallestXValue()));
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the biggest value of the y axis.
        /// </summary>
        /// <value> A normal integer value. </value>
        public double BigestXValue
        {
            get
            {
                return this.bigestXValue;
            }

            set
            {
                if (value < this.smallestXValue)
                {
                    throw new ArgumentOutOfRangeException("Error the value cant be smaller than the smallest value.");
                }

                this.bigestXValue = value;
                this.DrawYAxis();
                this.DrawYAxisGrid();
                this.FireOnXYValueChanged(new IntValueEventArgs(this.bigestXValue, new BiggestXValue()));
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the opacity of the y axis.
        /// </summary>
        /// <value> A normal double value. </value>
        public double YOpacity
        {
            get
            {
                return this.yOpacity;
            }

            set
            {
                if (value > 1 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("Error the Value can only be between 1 and 0.");
                }

                this.yOpacity = value;
                this.DrawYAxis();
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the smallest value of the y axis.
        /// </summary>
        /// <value> A normal integer value. </value>
        public double SmallestYValue
        {
            get
            {
                return this.smallestYValue;
            }

            set
            {
                if (value > this.bigestYValue)
                {
                    throw new ArgumentOutOfRangeException("Error the value cant be greater than the biggest value.");
                }

                this.smallestYValue = value;
                this.DrawXAxis();
                this.DrawXAxisGrid();
                this.FireOnXYValueChanged(new IntValueEventArgs(this.smallestYValue, new SmallestYValue()));
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the biggest value of the y axis.
        /// </summary>
        /// <value> A normal integer value. </value>
        public double BigestYValue
        {
            get
            {
                return this.bigestYValue;
            }

            set
            {
                if (value < this.smallestYValue)
                {
                    throw new ArgumentOutOfRangeException("Error the value cant be smaller than the smallest value.");
                }

                this.bigestYValue = value;
                this.DrawXAxis();
                this.DrawXAxisGrid();
                this.FireOnXYValueChanged(new IntValueEventArgs(this.bigestYValue, new BiggestYValue()));
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the opacity of the x axis grid.
        /// </summary>
        /// <value> A normal double value. </value>
        public double GridXOpacity
        {
            get
            {
                return this.gridXOpacity;
            }

            set
            {
                if (value > 1 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("Error the Value can only be between 1 and 0.");
                }

                this.gridXOpacity = value;
                this.DrawXAxisGrid();
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the interval of the x axis grid.
        /// </summary>
        /// <value> A normal integer value. </value>
        public float GridXInterval
        {
            get
            {
                return this.gridXInterval;
            }

            set
            {
                if (value < 0.1)
                {
                    throw new ArgumentOutOfRangeException("Error the Value has to be atleast 0.1.");
                }

                this.gridXInterval = value;
                this.DrawXAxisGrid();
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the possible colors of the grid.
        /// </summary>
        /// <value> A list of colors. </value>
        public IEnumerable<Color> ColorsValues
        {
            get
            {
                List<Color> temp = new List<Color>();
                temp.Add(Colors.Pink);
                temp.Add(Colors.Red);
                temp.Add(Colors.Blue);
                temp.Add(Colors.Black);
                temp.Add(Colors.Purple);
                temp.Add(Colors.Cyan);
                temp.Add(Colors.Gray);
                return temp;
            }
        }

        /// <summary>
        /// Gets or sets the opacity of the y axis grid.
        /// </summary>
        /// <value> A normal integer value. </value>
        public double GridYOpacity
        {
            get
            {
                return this.gridYOpacity;
            }

            set
            {
                if (value > 1 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("Error the Value can only be between 1 and 0.");
                }

                this.gridYOpacity = value;
                this.DrawYAxisGrid();
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the interval of the y axis grid.
        /// </summary>
        /// <value> A normal integer value. </value>
        public float GridYInterval
        {
            get
            {
                return this.gridYInterval;
            }

            set
            {
                if (value < 0.1)
                {
                    throw new ArgumentOutOfRangeException("Error the Value has to be atleast 1.");
                }

                this.gridYInterval = value;
                this.DrawYAxisGrid();
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// This method changes the smallest y value.
        /// </summary>
        /// <param name="sender"> The object sender. </param>
        /// <param name="e"> The <see cref="IntValueEventArgs"/>. </param>
        public void ChangeYMinValue(object sender, IntValueEventArgs e)
        {
            this.SmallestYValue = e.Value;
        }

        /// <summary>
        /// This method changes the biggest y value.
        /// </summary>
        /// <param name="sender"> The object sender. </param>
        /// <param name="e"> The <see cref="IntValueEventArgs"/>. </param>
        public void ChangeYMaxValue(object sender, IntValueEventArgs e)
        {
            this.BigestYValue = e.Value;
        }

        /// <summary>
        /// This method zooms into the canvas.
        /// </summary>
        /// <param name="sender"> The object sender. </param>
        /// <param name="e"> The start and end points. </param>
        public void Zoom(object sender, PointEventArgs e)
        {
            double smallX = this.smallestXValue;
            double widthY = 500D / ((double)this.BigestYValue - (double)this.SmallestYValue);
            double widthX = 600D / ((double)this.BigestXValue - (double)this.SmallestXValue);

            try
            {
                this.SmallestYValue = this.bigestYValue - (e.EndPoint.Y / widthY);
                this.SmallestXValue = this.SmallestXValue + (e.StartPoint.X / widthX);
                this.BigestYValue = this.BigestYValue - (e.StartPoint.Y / widthY);
                this.BigestXValue = smallX + (e.EndPoint.X / widthX);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// This method fires when the x or y value have been changed.
        /// </summary>
        /// <param name="e"> The <see cref="IntValueEventArgs"/>. </param>
        protected virtual void FireOnXYValueChanged(IntValueEventArgs e)
        {
            if (this.OnXYValueChanged != null)
            {
                this.OnXYValueChanged(this, e);
            }
        }

        /// <summary>
        /// This method fires when the property has been changed.
        /// </summary>
        /// <param name="propertyName"> The name of the property. </param>
        protected virtual void FireOnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// This method gets the start point of the x axis.
        /// </summary>
        private void DrawXAxis()
        {
            this.xAxeStart.Clear();
            double widthY = 500D / ((double)this.BigestYValue - (double)this.SmallestYValue);
            double y = (double)this.BigestYValue * widthY;
            this.xAxeStart.Add(new GridLines(new Point(0, y), this.XOpacity, this.ColorXAxis));
        }

        /// <summary>
        /// This method gets the start point of the y axis.
        /// </summary>
        private void DrawYAxis()
        {
            this.yAxeStart.Clear();
            double widthX = 600D / ((double)this.BigestXValue - (double)this.SmallestXValue);
            double x = 600D - ((double)this.bigestXValue * widthX);
            this.yAxeStart.Add(new GridLines(new Point(x, 0), this.YOpacity, this.ColorYAxis));
        }

        /// <summary>
        /// This method gets the start point of the x axis grid.
        /// </summary>
        private void DrawXAxisGrid()
        {
            var widthY = 500D / ((double)this.BigestYValue - (double)this.SmallestYValue);

            this.xAxeGrid.Clear();
            double temp = 0;

            for (var i = this.BigestYValue; i >= this.SmallestYValue; i = Math.Round(i - 0.1D, 1))
            {
                if (Math.Round((decimal)i % (decimal)this.GridXInterval, 2) == 0 && i != 0)
                {
                    var y = temp * widthY;
                    this.xAxeGrid.Add(new GridLines(new Point(0, y), this.GridXOpacity, this.ColorXAxisGrid));
                }

                temp = temp + 0.1;
            }
        }

        /// <summary>
        /// This method gets the start point of the y axis grid.
        /// </summary>
        private void DrawYAxisGrid()
        {
            double widthX = 600D / ((double)this.BigestXValue - (double)this.SmallestXValue);

            this.yAxeGrid.Clear();
            double temp = 0;

            for (double i = this.SmallestXValue; i <= this.BigestXValue; i = Math.Round(i + 0.1D, 1))
            {
                if (Math.Round((decimal)i % (decimal)this.GridYInterval, 2) == 0 && i != 0)
                {
                    double x = temp * widthX;
                    this.yAxeGrid.Add(new GridLines(new Point(x, 0), this.GridYOpacity, this.ColorYAxisGrid));
                }

                temp = temp + 0.1;
            }
        }
    }
}
