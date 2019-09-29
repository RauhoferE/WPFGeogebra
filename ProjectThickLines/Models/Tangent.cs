//-----------------------------------------------------------------------
// <copyright file="Tangent.cs" company="FH Wiener Neustadt">
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

    /// <summary>
    /// The <see cref="Tangent"/> class.
    /// </summary>
    [Serializable]
    public class Tangent : IAngle
    {
        /// <summary>
        /// Gets the name of the angle.
        /// </summary>
        /// <value> A string name. </value>
        public string Name
        {
            get { return "Tangent"; }
        }
    }
}