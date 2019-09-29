//-----------------------------------------------------------------------
// <copyright file="ZoomVM.cs" company="FH Wiener Neustadt">
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
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;

    /// <summary>
    /// The <see cref="ZoomVM"/> class.
    /// </summary>
    public class ZoomVM : INotifyPropertyChanged
    {
        /// <summary>
        /// A value indicating if the rectangle is visible.
        /// </summary>
        private bool visible;

        /// <summary>
        /// Gets the x position of the rectangle.
        /// </summary>
        private double left;

        /// <summary>
        /// Gets the y position of the rectangle.
        /// </summary>
        private double top;

        /// <summary>
        /// Gets the width of the rectangle.
        /// </summary>
        private double width;

        /// <summary>
        /// Gets the height of the rectangle.
        /// </summary>
        private double height;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZoomVM"/> class.
        /// </summary>
        public ZoomVM()
        {
            this.ISVisible = false;
            this.Height = 0;
            this.Width = 0;
            this.Top = 0;
            this.Left = 0;
        }

        /// <summary>
        /// This event fires when a property has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This event fires when the player lets the mouse button go.
        /// </summary>
        public event EventHandler<PointEventArgs> OnXYChanged;

        /// <summary>
        /// Gets or sets a value indicating whether the rectangle is visible.
        /// </summary>
        /// <value> If true then the rectangle is visible. </value>
        public bool ISVisible
        {
            get
            {
                return this.visible;
            }

            set
            {
                this.visible = value;
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the x position of the rectangle.
        /// </summary>
        /// <value> A normal double value. </value>
        public double Left
        {
            get
            {
                return this.left;
            }

            set
            {
                this.left = value;
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the y position of the rectangle.
        /// </summary>
        /// <value> A normal double value. </value>
        public double Top
        {
            get
            {
                return this.top;
            }

            set
            {
                this.top = value;
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        /// <value> A normal double value. </value>
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.width = value;
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the height of the rectangle.
        /// </summary>
        /// <value> A normal double value. </value>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
                this.FireOnPropertyChanged();
            }
        }

        /// <summary>
        /// This method gets the start point.
        /// </summary>
        /// <param name="pos"> The start point. </param>
        public void GetPoint(Point pos)
        {
            this.ISVisible = true;
            this.Top = pos.Y;
            this.Left = pos.X;
        }

        /// <summary>
        /// This method gets the height and width of the rectangle.
        /// </summary>
        /// <param name="pos"> The current point. </param>
        public void GetWidthAndHeight(Point pos)
        {
            if (this.ISVisible == true)
            {
                this.Width = pos.X - this.Left;
                this.Height = pos.Y - this.Top;
            }
        }

        /// <summary>
        /// This method gets the end point.
        /// </summary>
        /// <param name="pos"> The end point. </param>
        public void ScaleAxis(Point pos)
        {
            if (this.ISVisible == true && this.Width > 0 && this.Height > 0)
            {
                this.FireXYValueChanged(new PointEventArgs(new Point(this.Left, this.Top), pos));
                this.ISVisible = false;
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
        /// This method fires when the x and y value has changed.
        /// </summary>
        /// <param name="e"> The point events. </param>
        protected virtual void FireXYValueChanged(PointEventArgs e)
        {
            if (this.OnXYChanged != null)
            {
                this.OnXYChanged(this, e);
            }
        }
    }
}
