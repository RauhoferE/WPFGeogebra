// -----------------------------------------------------------------------
//  <copyright file="SmallestYValue.cs" company="FH Wiener Neustadt">
//      Copyright (c) Emre Rauhofer. All rights reserved.
//  </copyright>
//  <author>Emre Rauhofer</author>
//  <summary>
//  This program is a plot.
//  </summary>
// -----------------------------------------------------------------------
namespace ProjectThickLines.ViewModels
{
    /// <summary>
    /// Gets the <see cref="SmallestYValue"/> class.
    /// </summary>
    public class SmallestYValue : IXYAxis
    {
        /// <summary>
        /// Gets the name of the value.
        /// </summary>
        /// <value> A string name. </value>
        public string Name
        {
            get { return "SmallestYValue"; }
        }
    }
}