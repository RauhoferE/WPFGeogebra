//-----------------------------------------------------------------------
// <copyright file="IntValueEventArgs.cs" company="FH Wiener Neustadt">
//     Copyright (c) Emre Rauhofer. All rights reserved.
// </copyright>
// <author>Emre Rauhofer</author>
// <summary>
// This program is a plot. 
// </summary>
//-----------------------------------------------------------------------
namespace ProjectThickLines.ViewModels
{
    /// <summary>
    /// The <see cref="IntValueEventArgs"/> class.
    /// </summary>
    public class IntValueEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntValueEventArgs"/> class.
        /// </summary>
        /// <param name="value"> The value of the variable. </param>
        /// <param name="xy"> Where to put the value. </param>
        public IntValueEventArgs(double value, IXYAxis xy)
        {
            this.Value = value;
            this.XYAxisEnum = xy;
        }

        /// <summary>
        /// Gets the value of the variable.
        /// </summary>
        /// <value> A normal integer value. </value>
        public double Value
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the <see cref="IXYAxis"/>.
        /// </summary>
        /// <value> A normal <see cref="IXYAxis"/>. </value>
        public IXYAxis XYAxisEnum
        {
            get;
            private set;
        }
    }
}
