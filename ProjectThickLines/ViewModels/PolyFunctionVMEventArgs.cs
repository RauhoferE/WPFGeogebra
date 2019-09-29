//-----------------------------------------------------------------------
// <copyright file="PolyFunctionVMEventArgs.cs" company="FH Wiener Neustadt">
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
    /// The <see cref="PolyFunctionVMEventArgs"/> class.
    /// </summary>
    public class PolyFunctionVMEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolyFunctionVMEventArgs" /> class.
        /// </summary>
        /// <param name="polyFunctionVM"> The <see cref="PolyFunctionVM"/>. </param>
        public PolyFunctionVMEventArgs(PolyFunctionVM polyFunctionVM)
        {
            this.PolyFunctionVM = polyFunctionVM;
        }

        /// <summary>
        /// Gets the function.
        /// </summary>
        /// <value> A normal <see cref="PolyFunctionVM"/>. </value>
        public PolyFunctionVM PolyFunctionVM
        {
            get;
            private set;
        }
    }
}
