//-----------------------------------------------------------------------
// <copyright file="PointEventArgs.cs" company="FH Wiener Neustadt">
//     Copyright (c) Emre Rauhofer. All rights reserved.
// </copyright>
// <author>Emre Rauhofer</author>
// <summary>
// This program is a plot. 
// </summary>
//-----------------------------------------------------------------------
namespace ProjectThickLines.ViewModels
{
    using System.Windows;

    /// <summary>
    /// The <see cref="PointEventArgs"/> class.
    /// </summary>
    public class PointEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PointEventArgs"/> class.
        /// </summary>
        /// <param name="start"> The start point. </param>
        /// <param name="end"> The end point. </param>
        public PointEventArgs(Point start, Point end)
        {
            this.StartPoint = start;
            this.EndPoint = end;
        }

        /// <summary>
        /// Gets the start point.
        /// </summary>
        /// <value> A normal point. </value>
        public Point StartPoint
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the end point.
        /// </summary>
        /// <value> A normal point. </value>
        public Point EndPoint
        {
            get;
            private set;
        }
    }
}
