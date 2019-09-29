//-----------------------------------------------------------------------
// <copyright file="MathFunction.cs" company="FH Wiener Neustadt">
//     Copyright (c) Emre Rauhofer. All rights reserved.
// </copyright>
// <author>Emre Rauhofer</author>
// <summary>
// This program is a plot. 
// </summary>
//-----------------------------------------------------------------------
namespace ProjectThickLines.Models
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    /// <summary>
    /// The <see cref="MathFunction"/> class.
    /// </summary>
    [Serializable]
    public abstract class MathFunction
    {
        /// <summary>
        /// The name of the function.
        /// </summary>
        private string name;

        /// <summary>
        /// Gets or sets the parameter list for the function.
        /// </summary>
        /// <value> A normal list of float values. </value>
        public abstract List<float> ParameterList
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the list of points.
        /// </summary>
        /// <value> A normal list of points. </value>
        public List<Point> Points
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the function.
        /// </summary>
        /// <value> A normal string between 1 and 10. </value>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length > 10 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Error the name can only be 10 Characters long.");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Calculates the points for the function.
        /// </summary>
        /// <param name="smallestXValue"> The smallest value on the x-axis. </param>
        /// <param name="bigestXValue"> The biggest value on the x-axis. </param>
        public abstract void CalculatePoints(double smallestXValue, double bigestXValue);
    }
}
