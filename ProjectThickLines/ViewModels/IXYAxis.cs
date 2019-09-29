//-----------------------------------------------------------------------
// <copyright file="IXYAxis.cs" company="FH Wiener Neustadt">
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
    /// The <see cref="IXYAxis"/> interface.
    /// </summary>
    public interface IXYAxis
    {
        /// <summary>
        /// Gets the name of the x or y axis.
        /// </summary>
        /// <value> A string name. </value>
        string Name
        {
            get;
        }
    }
}