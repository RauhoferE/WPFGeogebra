//-----------------------------------------------------------------------
// <copyright file="TrigFunctionVM.cs" company="FH Wiener Neustadt">
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
    /// The <see cref="TrigFunctionVM"/> class.
    /// </summary>
    public class TrigFunctionVM : INotifyPropertyChanged
    {
        /// <summary>
        /// The model of the function.
        /// </summary>
        public readonly TrigFunction TrigFunctionM;

        /// <summary>
        /// The command to remove the function.
        /// </summary>
        private readonly ICommand removeCommand;

        /// <summary>
        /// The stroke thickness of the function.
        /// </summary>
        private double strokeThickness;

        /// <summary>
        /// The opacity of the function.
        /// </summary>
        private double opacity;

        /// <summary>
        /// The color of the function.
        /// </summary>
        private Color functionColor;

        /// <summary>
        /// The point collection of the function.
        /// </summary>
        private PointCollection points;

        /// <summary>
        /// Represents the brush of the function.
        /// </summary>
        private SolidColorBrush brush;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrigFunctionVM"/> class.
        /// </summary>
        /// <param name="trigFunction"> The model of the <see cref="TrigFunction"/>. </param>
        /// <param name="removeCommand"> The remove command. </param>
        public TrigFunctionVM(TrigFunction trigFunction, ICommand removeCommand)
        {
            this.points = new PointCollection();
            this.Brush = new SolidColorBrush();
            this.TrigFunctionM = trigFunction;
            this.Name = trigFunction.Name;
            this.Values = trigFunction.ParameterList;
            this.Angle = trigFunction.Angle.Name;
            this.removeCommand = removeCommand;
            this.opacity = 1;
            this.strokeThickness = 1;
            this.functionColor = Colors.Red;
            this.Brush.Color = this.functionColor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrigFunctionVM"/> class.
        /// </summary>
        /// <param name="trigFunctionVMContainer"> The container for the <see cref="TrigFunction"/>. </param>
        /// <param name="removec"> The remove command. </param>
        public TrigFunctionVM(TrigFunctionVMContainer trigFunctionVMContainer, ICommand removec)
        {
            this.points = new PointCollection();
            this.Brush = new SolidColorBrush();
            this.TrigFunctionM = trigFunctionVMContainer.TrigFunction;
            this.Name = trigFunctionVMContainer.TrigFunction.Name;
            this.Values = trigFunctionVMContainer.TrigFunction.ParameterList;
            this.Angle = trigFunctionVMContainer.TrigFunction.Angle.Name;
            this.removeCommand = removec;
            this.opacity = trigFunctionVMContainer.Opacity;
            this.strokeThickness = trigFunctionVMContainer.StrokeThickness;
            this.functionColor = trigFunctionVMContainer.FunctionColor;
            this.Brush.Color = this.functionColor;
        }

        /// <summary>
        /// This event fires when a property has been changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This event fires when the function has been changed.
        /// </summary>
        public event EventHandler<TrigFunctionVMEventArgs> OnTrigFunctionChanged;

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
                return this.TrigFunctionM.Name;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 10)
                {
                    this.TrigFunctionM.Name = "Default";
                }

                this.TrigFunctionM.Name = value;
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the first value of the function.
        /// </summary>
        /// <value> A normal float value. </value>
        public float AValue
        {
            get
            {
                return this.Values[0];
            }

            set
            {
                this.Values[0] = value;
                this.FireOnPropertyChanged();
                this.FireOnTrigFunctionChanged(new TrigFunctionVMEventArgs(this));
            }
        }

        /// <summary>
        /// Gets or sets the second value of the function.
        /// </summary>
        /// <value> A normal float value. </value>
        public float BValue
        {
            get
            {
                return this.Values[1];
            }

            set
            {
                this.Values[1] = value;
                this.FireOnPropertyChanged();
                this.FireOnTrigFunctionChanged(new TrigFunctionVMEventArgs(this));
            }
        }

        /// <summary>
        /// Gets or sets the third value of the function.
        /// </summary>
        /// <value> A normal float value. </value>
        public float CValue
        {
            get
            {
                return this.Values[2];
            }

            set
            {
                this.Values[2] = value;
                this.FireOnPropertyChanged();
                this.FireOnTrigFunctionChanged(new TrigFunctionVMEventArgs(this));
            }
        }

        /// <summary>
        /// Gets or sets the angle of the function.
        /// </summary>
        /// <value> A normal angle. </value>
        public string Angle
        {
            get
            {
                return this.TrigFunctionM.Angle.Name;
            }

            set
            {
                switch (value)
                {
                    case "Sine":
                        this.TrigFunctionM.Angle = new Sine();
                        break;
                    case "Cosine":
                        this.TrigFunctionM.Angle = new Cosine();
                        break;
                    case "Tangent":
                        this.TrigFunctionM.Angle = new Tangent();
                        break;
                    default:
                        this.TrigFunctionM.Angle = new Sine();
                        break;
                }
                
                this.FireOnPropertyChanged();
                this.FireOnTrigFunctionChanged(new TrigFunctionVMEventArgs(this));
            }
        }

        /// <summary>
        /// Gets the possible angles of the function.
        /// </summary>
        /// <value> A list of angle. </value>
        public IEnumerable<string> AngleValues
        {
            get
            {
                return new List<string>() { "Sine", "Cosine", "Tangent" };
            }
        }

        /// <summary>
        /// Gets the possible colors of the function.
        /// </summary>
        /// <value> A list of colors. </value>
        public IEnumerable<Color> ColorsValues
        {
            get
            {
                List<Color> l = new List<Color>();
                l.Add(Colors.Pink);
                l.Add(Colors.Red);
                l.Add(Colors.Blue);
                return l;
            }
        }

        /// <summary>
        /// Gets or sets the list of values.
        /// </summary>
        /// <value> A normal list. </value>
        public List<float> Values
        {
            get
            {
                return this.TrigFunctionM.ParameterList;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Error value cant be null.");
                }

                this.TrigFunctionM.ParameterList = value;
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
        /// Gets the model.
        /// </summary>
        /// <value> A normal model. </value>
        public TrigFunction Current
        {
            get
            {
                TrigFunction t = new TrigFunction();
                switch (this.Angle)
                {
                    case "Sine":
                        t.Angle = new Sine();
                        break;
                    case "Cosine":
                        t.Angle = new Cosine();
                        break;
                    case "Tangent":
                        t.Angle = new Tangent();
                        break;
                    default:
                        t.Angle = new Sine();
                        break;
                }

                t.Name = this.Name;
                t.ParameterList = this.Values;
                return t;
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
            this.TrigFunctionM.CalculatePoints(smallestXValue, bigestXValue);
            this.Points.Clear();
            double widthY = 500D / ((double)bigestYValue - (double)smallestYValue);
            double widthX = 600D / ((double)bigestXValue - (double)smallestXValue);

            foreach (var item in this.TrigFunctionM.Points)
            {
                double x = (item.X - smallestXValue) * widthX;
                double y = 500 - ((item.Y - smallestYValue) * widthY);
                this.points.Add(new Point(x, y));
            }
        }

        /// <summary>
        /// This method fires when the function has been changed.
        /// </summary>
        /// <param name="e"> The <see cref="TrigFunctionVMEventArgs"/>. </param>
        protected virtual void FireOnTrigFunctionChanged(TrigFunctionVMEventArgs e)
        {
            if (this.OnTrigFunctionChanged != null)
            {
                this.OnTrigFunctionChanged(this, e);
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
    }
}
