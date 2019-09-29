//-----------------------------------------------------------------------
// <copyright file="ContainerFileForSerealization.cs" company="FH Wiener Neustadt">
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

    /// <summary>
    /// The <see cref="ContainerFileForSerealization"/> class.
    /// </summary>
    [Serializable]
    public class ContainerFileForSerealization
    {
        /// <summary>
        /// Gets or sets the list from <see cref="PolyFunction"/>.
        /// </summary>
        public readonly List<PolyFunction> PolyFunctions;

        /// <summary>
        /// Gets or sets the list from <see cref="TrigFunction"/>.
        /// </summary>
        public readonly List<TrigFunction> TrigFunctions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerFileForSerealization"/> class.
        /// </summary>
        /// <param name="polyFunctions"> The list with all the <see cref="PolyFunction"/>. </param>
        /// <param name="trigFunctions"> The list with all the <see cref="TrigFunction"/>. </param>
        public ContainerFileForSerealization(List<PolyFunction> polyFunctions, List<TrigFunction> trigFunctions)
        {
            this.PolyFunctions = polyFunctions;
            this.TrigFunctions = trigFunctions;
        }
    }
}
