//-----------------------------------------------------------------------
// <copyright file="GridLines.cs" company="FH Wiener Neustadt">
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
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// The <see cref="GridLines"/> class.
    /// </summary>
    public class GridLines
    {
        /// <summary>
        /// The start point of the line.
        /// </summary>
        private Point startPoint;

        /// <summary>
        /// The color of the line.
        /// </summary>
        private SolidColorBrush color;

        /// <summary>
        /// Initializes a new instance of the <see cref="GridLines"/> class.
        /// </summary>
        /// <param name="startPoint"> The start of the point. </param>
        /// <param name="opacity"> The opacity of the line. </param>
        /// <param name="color"> The color of the line. </param>
        public GridLines(Point startPoint, double opacity, Color color)
        {
            this.StartPoint = startPoint;
            this.Opacity = opacity;
            this.Color = new SolidColorBrush();
            this.Color.Color = color;
        }

        /// <summary>
        /// Gets or sets the start point of the line.
        /// </summary>
        /// <value> A normal <see cref="Point"/>. </value>
        public Point StartPoint
        {
            get
            {
                return this.startPoint;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Error value cant be null.");
                }

                this.startPoint = value;
            }
        }

        /// <summary>
        /// Gets or sets the opacity of the line.
        /// </summary>
        /// <value> A normal double. </value>
        public double Opacity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value> A normal <see cref="SolidColorBrush"/>. </value>
        public SolidColorBrush Color
        {
            get
            {
                return this.color;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Error value cant be null.");
                }

                this.color = value;
            }
        }
    }
}
