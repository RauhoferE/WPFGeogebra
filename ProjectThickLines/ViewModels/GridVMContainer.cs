//-----------------------------------------------------------------------
// <copyright file="GridVMContainer.cs" company="FH Wiener Neustadt">
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
    /// The <see cref="GridVMContainer"/> class.
    /// </summary>
    [Serializable]
    public class GridVMContainer
    {
        /// <summary>
        /// The grid interval of the x axis.
        /// </summary>
        public readonly float GridXInterval;

        /// <summary>
        /// The grid interval of the y axis.
        /// </summary>
        public readonly float GridYInterval;

        /// <summary>
        /// The opacity of the x axis grid.
        /// </summary>
        public readonly double GridXOpacity;

        /// <summary>
        /// The opacity of the y axis grid.
        /// </summary>
        public readonly double GridYOpacity;

        /// <summary>
        /// The smallest value on the x axis.
        /// </summary>
        public readonly double SmallestXValue;

        /// <summary>
        /// The biggest value on the x axis.
        /// </summary>
        public readonly double BigestXValue;

        /// <summary>
        /// The smallest value on the y axis.
        /// </summary>
        public readonly double SmallestYValue;

        /// <summary>
        /// The biggest value on the y axis.
        /// </summary>
        public readonly double BigestYValue;

        /// <summary>
        /// The opacity of the x axis.
        /// </summary>
        public readonly double XOpacity;

        /// <summary>
        /// The opacity of the y axis.
        /// </summary>
        public readonly double YOpacity;

        /// <summary>
        /// The color of the x axis.
        /// </summary>
        public readonly ColorVM ColorXAxis;

        /// <summary>
        /// The color of the y axis.
        /// </summary>
        public readonly ColorVM ColorYAxis;

        /// <summary>
        /// The color of the x axis grid.
        /// </summary>
        public readonly ColorVM ColorXAxisGrid;

        /// <summary>
        /// The color of the y axis grid.
        /// </summary>
        public readonly ColorVM ColorYAxisGrid;

        /// <summary>
        /// Initializes a new instance of the <see cref="GridVMContainer"/> class.
        /// </summary>
        /// <param name="gridVM"> The to be saved grid. </param>
        public GridVMContainer(GridVM gridVM)
        {
            this.GridXInterval = gridVM.GridXInterval;
            this.GridYInterval = gridVM.GridYInterval;
            this.GridXOpacity = gridVM.GridXOpacity;
            this.GridYOpacity = gridVM.GridYOpacity;
            this.SmallestXValue = gridVM.SmallestXValue;
            this.BigestXValue = gridVM.BigestXValue;
            this.SmallestYValue = gridVM.SmallestYValue;
            this.BigestYValue = gridVM.BigestYValue;
            this.XOpacity = gridVM.XOpacity;
            this.YOpacity = gridVM.YOpacity;
            this.ColorXAxis = gridVM.ColorXAxis;
            this.ColorYAxis = gridVM.ColorYAxis;
            this.ColorXAxisGrid = gridVM.ColorXAxisGrid;
            this.ColorYAxisGrid = gridVM.ColorYAxisGrid;
        }
    }
}
