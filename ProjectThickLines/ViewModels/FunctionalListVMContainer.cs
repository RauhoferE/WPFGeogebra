//-----------------------------------------------------------------------
// <copyright file="FunctionalListVMContainer.cs" company="FH Wiener Neustadt">
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
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="FunctionalListVMContainer"/> class.
    /// </summary>
    [Serializable]
    public class FunctionalListVMContainer
    {
        /// <summary>
        /// A list that contains <see cref="TrigFunctionVMContainer"/> objects.
        /// </summary>
        public readonly List<TrigFunctionVMContainer> TrigFunctionVMContainers;

        /// <summary>
        /// A list that contains <see cref="PolyFunctionVMContainer"/> objects.
        /// </summary>
        public readonly List<PolyFunctionVMContainer> PolyFunctionVMContainers;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionalListVMContainer"/> class.
        /// </summary>
        /// <param name="functionListVM"> The <see cref="FunctionListVM"/> to be put into the container. </param> 
        public FunctionalListVMContainer(FunctionListVM functionListVM)
        {
            this.PolyFunctionVMContainers = new List<PolyFunctionVMContainer>();
            this.TrigFunctionVMContainers = new List<TrigFunctionVMContainer>();

            foreach (var item in functionListVM.PolyFunctions)
            {
                this.PolyFunctionVMContainers.Add(new PolyFunctionVMContainer(item));
            }

            foreach (var item in functionListVM.TrigFunctions)
            {
                this.TrigFunctionVMContainers.Add(new TrigFunctionVMContainer(item));
            }
        }
    }
}
