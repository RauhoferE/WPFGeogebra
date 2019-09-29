//-----------------------------------------------------------------------
// <copyright file="Cosine.cs" company="FH Wiener Neustadt">
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
    /// The <see cref="Cosine"/> class.
    /// </summary>
    [Serializable]
    public class Cosine : IAngle
    {
        /// <summary>
        /// Gets the name of the angle.
        /// </summary>
        /// <value> A string name. </value>
        public string Name
        {
            get { return "Cosine"; }
        }
    }
}