// -----------------------------------------------------------------------
//  <copyright file="BiggestXValue.cs" company="FH Wiener Neustadt">
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
    /// The <see cref="BiggestXValue"/> class.
    /// </summary>
    public class BiggestXValue : IXYAxis
    {
        /// <summary>
        /// Gets name of the value.
        /// </summary>
        /// <value> A string name. </value>
        public string Name
        {
            get { return "BiggestXValue"; }
        }
    }
}