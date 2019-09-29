//-----------------------------------------------------------------------
// <copyright file="PolyFunctionVM.cs" company="FH Wiener Neustadt">
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
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using ProjectThickLines.Models;

    /// <summary>
    /// The <see cref="PolyFunctionVM"/> class.
    /// </summary>
    public class PolyFunctionVM : INotifyPropertyChanged
    {
        /// <summary>
        /// The model of the function.
        /// </summary>
        public readonly PolyFunction Model;

        /// <summary>
        /// The command to remove the function.
        /// </summary>
        private ICommand removeCommand;

        /// <summary>
        /// The point collection of the function.
        /// </summary>
        private PointCollection points;

        /// <summary>
        /// The opacity of the function.
        /// </summary>
        private double opacity;

        /// <summary>
        /// The stroke thickness of the function.
        /// </summary>
        private double strokeThickness;

        /// <summary>
        /// The color of the function.
        /// </summary>
        private Color functionColor;

        /// <summary>
        /// Represents the brush of the function.
        /// </summary>
        private SolidColorBrush brush;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolyFunctionVM"/> class.
        /// </summary>
        /// <param name="polyFunction"> The model of the <see cref="PolyFunction"/>. </param>
        /// <param name="removeCommand"> The remove command. </param>
        public PolyFunctionVM(PolyFunction polyFunction, ICommand removeCommand)
        {
            this.points = new PointCollection();
            this.Model = polyFunction;
            this.Values = polyFunction.ParameterList;
            this.removeCommand = removeCommand;
            this.opacity = 1;
            this.strokeThickness = 1;
            this.functionColor = Colors.Red;
            this.Brush = new SolidColorBrush();
            this.Brush.Color = this.functionColor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolyFunctionVM"/> class.
        /// </summary>
        /// <param name="polyFunctionVMContainer"> The container for the <see cref="PolyFunction"/>. </param>
        /// <param name="removeCommand"> The remove command. </param>
        public PolyFunctionVM(PolyFunctionVMContainer polyFunctionVMContainer, ICommand removeCommand)
        {
            this.points = new PointCollection();
            this.Model = polyFunctionVMContainer.PolyFunction;
            this.Name = polyFunctionVMContainer.PolyFunction.Name;
            this.Values = polyFunctionVMContainer.PolyFunction.ParameterList;
            this.removeCommand = removeCommand;
            this.opacity = polyFunctionVMContainer.Opacity;
            this.strokeThickness = polyFunctionVMContainer.StrokeThickness;
            this.functionColor = polyFunctionVMContainer.FunctionColor;
            this.Brush = new SolidColorBrush();
            this.Brush.Color = this.functionColor;
        }

        /// <summary>
        /// This event fires when a property has been changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This event fires when the function has been changed.
        /// </summary>
        public event EventHandler<PolyFunctionVMEventArgs> OnPolyFunctionChanged;

        /// <summary>
        /// Gets the points of the function.
        /// </summary>
        /// <value> A normal <see cref="PointCollection"/>. </value>
        public PointCollection Points
        {
            get
            {
                return this.points;
            }
        }

        /// <summary>
        /// Gets or sets the brush of the function.
        /// </summary>
        /// <value> A normal <see cref="SolidColorBrush"/>. </value>
        public SolidColorBrush Brush
        {
            get
            {
                return this.brush;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Error brush cant be null.");
                }

                this.brush = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the first parameter of the function.
        /// </summary>
        /// <value> A normal float value. </value>
        public float DegreeZero
        {
            get
            {
                return this.Values[0];
            }

            set
            {
                this.Values[0] = value;
                this.FireOnPropertyChanged();
                this.FireOnPolyFunctionChanged(new PolyFunctionVMEventArgs(this));
            }
        }

        /// <summary>
        /// Gets or sets the value of the second parameter of the function.
        /// </summary>
        /// <value> A normal float value. </value>
        public float DegreeOne
        {
            get
            {
                return this.Values[1];
            }

            set
            {
                this.Values[1] = value;
                this.FireOnPropertyChanged();
                this.FireOnPolyFunctionChanged(new PolyFunctionVMEventArgs(this));
            }
        }

        /// <summary>
        /// Gets or sets the value of the third parameter of the function.
        /// </summary>
        /// <value> A normal float value. </value>
        public float DegreeTwo
        {
            get
            {
                return this.Values[2];
            }

            set
            {
                this.Values[2] = value;
                this.FireOnPropertyChanged();
                this.FireOnPolyFunctionChanged(new PolyFunctionVMEventArgs(this));
            }
        }

        /// <summary>
        /// Gets or sets the value of the fourth parameter of the function.
        /// </summary>
        /// <value> A normal float value. </value>
        public float DegreeThree
        {
            get
            {
                return this.Values[3];
            }

            set
            {
                this.Values[3] = value;
                this.FireOnPropertyChanged();
                this.FireOnPolyFunctionChanged(new PolyFunctionVMEventArgs(this));
            }
        }

        /// <summary>
        /// Gets or sets the value of the fifth parameter of the function.
        /// </summary>
        /// <value> A normal float value. </value>
        public float DegreeFour
        {
            get
            {
                return this.Values[4];
            }

            set
            {
                this.Values[4] = value;
                this.FireOnPropertyChanged();
                this.FireOnPolyFunctionChanged(new PolyFunctionVMEventArgs(this));
            }
        }

        /// <summary>
        /// Gets or sets the value of the sixth parameter of the function.
        /// </summary>
        /// <value> A normal float value. </value>
        public float DegreeFive
        {
            get
            {
                return this.Values[5];
            }

            set
            {
                this.Values[5] = value;
                this.FireOnPropertyChanged();
                this.FireOnPolyFunctionChanged(new PolyFunctionVMEventArgs(this));
            }
        }

        /// <summary>
        /// Gets or sets the value of the seventh parameter of the function.
        /// </summary>
        /// <value> A normal float value. </value>
        public float DegreeSix
        {
            get
            {
                return this.Values[6];
            }

            set
            {
                this.Values[6] = value;
                this.FireOnPropertyChanged();
                this.FireOnPolyFunctionChanged(new PolyFunctionVMEventArgs(this));
            }
        }

        /// <summary>
        /// Gets or sets the value of the eight parameter of the function.
        /// </summary>
        /// <value> A normal float value. </value>
        public float DegreeSeven
        {
            get
            {
                return this.Values[7];
            }

            set
            {
                this.Values[7] = value;
                this.FireOnPropertyChanged();
                this.FireOnPolyFunctionChanged(new PolyFunctionVMEventArgs(this));
            }
        }

        /// <summary>
        /// Gets or sets the value of the ninth parameter of the function.
        /// </summary>
        /// <value> A normal float value. </value>
        public float DegreeEight
        {
            get
            {
                return this.Values[8];
            }

            set
            {
                this.Values[8] = value;
                this.FireOnPropertyChanged();
                this.FireOnPolyFunctionChanged(new PolyFunctionVMEventArgs(this));
            }
        }

        /// <summary>
        /// Gets or sets the value of the tenth parameter of the function.
        /// </summary>
        /// <value> A normal float value. </value>
        public float DegreeNine
        {
            get
            {
                return this.Values[9];
            }

            set
            {
                this.Values[9] = value;
                this.FireOnPropertyChanged();
                this.FireOnPolyFunctionChanged(new PolyFunctionVMEventArgs(this));
            }
        }

        /// <summary>
        /// Gets or sets the value of the eleventh parameter of the function.
        /// </summary>
        /// <value> A normal float value. </value>
        public float DegreeTen
        {
            get
            {
                return this.Values[10];
            }

            set
            {
                this.Values[10] = value;
                this.FireOnPropertyChanged();
                this.FireOnPolyFunctionChanged(new PolyFunctionVMEventArgs(this));
            }
        }

        /// <summary>
        /// Gets the command to remove the function.
        /// </summary>
        /// <value> A normal <see cref="ICommand"/>. </value>
        public ICommand RemoveCommand
        {
            get
            {
                return this.removeCommand;
            }
        }

        /// <summary>
        /// Gets or sets the name of the function.
        /// </summary>
        /// <value> A normal string value. </value>
        public string Name
        {
            get
            {
                return this.Model.Name;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 10)
                {
                    this.Model.Name = "Default";
                }

                this.Model.Name = value;
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the color values to choose.
        /// </summary>
        /// <value> A normal color value. </value>
        public IEnumerable<Color> ColorsValues
        {
            get
            {
                List<Color> temp = new List<Color>();
                temp.Add(Colors.Pink);
                temp.Add(Colors.Red);
                temp.Add(Colors.Blue);
                return temp;
            }
        }

        /// <summary>
        /// Gets the current model.
        /// </summary>
        /// <value> A normal <see cref="PolyFunction"/>. </value>
        public PolyFunction Current
        {
            get
            {
                return new PolyFunction(this.Values);
            }
        }

        /// <summary>
        /// Gets or sets the values of the function.
        /// </summary>
        /// <value> A normal list of float values. </value>
        public List<float> Values
        {
            get
            {
                return this.Model.ParameterList;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Error the list cant be null.");
                }

                this.Model.ParameterList = value;
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the color of the function.
        /// </summary>
        /// <value> A normal <see cref="Color"/> value. </value>
        public Color FunctionColor
        {
            get
            {
                return this.functionColor;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Error color cant be null.");
                }

                this.functionColor = value;
                this.FireOnPropertyChanged();
                this.Brush.Color = this.functionColor;
            }
        }

        /// <summary>
        /// Gets or sets the stroke thickness of the function.
        /// </summary>
        /// <value> A normal double value. </value>
        public double StrokeThickness
        {
            get
            {
                return this.strokeThickness;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Error the value cant be smaller than 0.");
                }

                this.strokeThickness = value;
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the opacity of the function.
        /// </summary>
        /// <value> A normal double value. </value>
        public double Opacity
        {
            get
            {
                return this.opacity;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Error the value cant be smaller than 0.");
                }

                this.opacity = value;
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the points for the view.
        /// </summary>
        /// <param name="smallestXValue"> The smallest value of the x axis. </param>
        /// <param name="bigestXValue"> The biggest value of the x axis. </param>
        /// <param name="smallestYValue"> The smallest value of the y axis. </param>
        /// <param name="bigestYValue"> The biggest value of the y axis. </param>
        public void GetPolyline(double smallestXValue, double bigestXValue, double smallestYValue, double bigestYValue)
        {
            this.Model.CalculatePoints(smallestXValue, bigestXValue);
            this.points.Clear();
            double widthY = 500D / ((double)bigestYValue - (double)smallestYValue);
            double widthX = 600D / ((double)bigestXValue - (double)smallestXValue);

            foreach (var item in this.Model.Points)
            {
                double x = (item.X - smallestXValue) * widthX;
                double y = 500 - ((item.Y - smallestYValue) * widthY);
                this.points.Add(new Point(x, y));
            }
        }

        /// <summary>
        /// This method fires when a property has been changed.
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
        /// This method fires when the function has been changed.
        /// </summary>
        /// <param name="e"> The <see cref="PolyFunctionVMEventArgs"/>. </param>
        protected virtual void FireOnPolyFunctionChanged(PolyFunctionVMEventArgs e)
        {
            if (this.OnPolyFunctionChanged != null)
            {
                this.OnPolyFunctionChanged(this, e);
            }
        }
    }
}
