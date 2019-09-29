//-----------------------------------------------------------------------
// <copyright file="MainWindowVMContainer.cs" company="FH Wiener Neustadt">
//     Copyright (c) Emre Rauhofer. All rights reserved.
// </copyright>
// <author>Emre Rauhofer</author>
// <summary>
// This program is a plot. 
// </summary>
//-----------------------------------------------------------------------
namespace ProjectThickLines.ViewModels
{
    using System;

    /// <summary>
    /// The <see cref="MainWindowVMContainer"/> class.
    /// </summary>
    [Serializable]
    public class MainWindowVMContainer
    {
        /// <summary>
        /// The grid container.
        /// </summary>
        public readonly GridVMContainer GridVMContainer;

        /// <summary>
        /// The <see cref="FunctionListVM"/> container.
        /// </summary>
        public readonly FunctionalListVMContainer FunctionalListVMContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowVMContainer"/> class.
        /// </summary>
        /// <param name="gridVM"> The grid of the view. </param>
        /// <param name="functionListVM"> The functions of the view. </param>
        public MainWindowVMContainer(GridVM gridVM, FunctionListVM functionListVM)
        {
            this.GridVMContainer = new GridVMContainer(gridVM);
            this.FunctionalListVMContainer = new FunctionalListVMContainer(functionListVM);
        }
    }
}
