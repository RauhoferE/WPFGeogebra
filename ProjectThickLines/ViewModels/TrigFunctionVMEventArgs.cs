//-----------------------------------------------------------------------
// <copyright file="TrigFunctionVMEventArgs.cs" company="FH Wiener Neustadt">
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
    /// The <see cref="TrigFunctionVMEventArgs"/> class.
    /// </summary>
    public class TrigFunctionVMEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrigFunctionVMEventArgs" /> class.
        /// </summary>
        /// <param name="old"> The <see cref="TrigFunctionVM"/>. </param>
        public TrigFunctionVMEventArgs(TrigFunctionVM old)
        {
            this.OldItem = old;
        }

        /// <summary>
        /// Gets the <see cref="TrigFunctionVM"/>.
        /// </summary>
        /// <value> A normal <see cref="TrigFunctionVM"/>. </value>
        public TrigFunctionVM OldItem
        {
            get;
            private set;
        }
    }
}
