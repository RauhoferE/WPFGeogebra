//-----------------------------------------------------------------------
// <copyright file="TrigFunctionVMContainer.cs" company="FH Wiener Neustadt">
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
    using ProjectThickLines.Models;

    /// <summary>
    /// The <see cref="TrigFunctionVMContainer"/> class.
    /// </summary>
    [Serializable]
    public class TrigFunctionVMContainer
    {
        /// <summary>
        /// The model of the function.
        /// </summary>
        public readonly TrigFunction TrigFunction;

        /// <summary>
        /// The stroke thickness of the function.
        /// </summary>
        public readonly double StrokeThickness;

        /// <summary>
        /// The opacity of the function.
        /// </summary>
        public readonly double Opacity;

        /// <summary>
        /// The color of the function.
        /// </summary>
        public readonly ColorVM FunctionColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrigFunctionVMContainer"/> class.
        /// </summary>
        /// <param name="trigFunction"> The <see cref="TrigFunctionVM"/>. </param>
        public TrigFunctionVMContainer(TrigFunctionVM trigFunction)
        {
            this.TrigFunction = trigFunction.TrigFunctionM;
            this.StrokeThickness = trigFunction.StrokeThickness;
            this.Opacity = trigFunction.Opacity;
            this.FunctionColor = trigFunction.FunctionColor;
        }
    }
}
