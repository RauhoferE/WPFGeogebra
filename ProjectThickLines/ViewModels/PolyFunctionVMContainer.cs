//-----------------------------------------------------------------------
// <copyright file="PolyFunctionVMContainer.cs" company="FH Wiener Neustadt">
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
    /// The <see cref="PolyFunctionVMContainer"/> class.
    /// </summary>
    [Serializable]
    public class PolyFunctionVMContainer
    {
        /// <summary>
        /// The opacity of the function.
        /// </summary>
        public readonly double Opacity;

        /// <summary>
        /// The stroke thickness of the function.
        /// </summary>
        public readonly double StrokeThickness;

        /// <summary>
        /// The color of the function.
        /// </summary>
        public readonly ColorVM FunctionColor;

        /// <summary>
        /// The model of the function.
        /// </summary>
        public readonly PolyFunction PolyFunction;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolyFunctionVMContainer"/> class.
        /// </summary>
        /// <param name="polyFunction"> The <see cref="PolyFunctionVM"/>. </param>
        public PolyFunctionVMContainer(PolyFunctionVM polyFunction)
        {
            this.Opacity = polyFunction.Opacity;
            this.StrokeThickness = polyFunction.StrokeThickness;
            this.FunctionColor = polyFunction.FunctionColor;
            this.PolyFunction = polyFunction.Model;
        }
    }
}
