//-----------------------------------------------------------------------
// <copyright file="IAngle.cs" company="FH Wiener Neustadt">
//     Copyright (c) Emre Rauhofer. All rights reserved.
// </copyright>
// <author>Emre Rauhofer</author>
// <summary>
// This program is a plot. 
// </summary>
//-----------------------------------------------------------------------
namespace ProjectThickLines.Models
{
    /// <summary>
    /// The <see cref="IAngle"/> interface.
    /// </summary>
    public interface IAngle
    {
        /// <summary>
        /// Gets the name of the angle.
        /// </summary>
        /// <value> A string name. </value>
        string Name { get; }
    }
}