//-----------------------------------------------------------------------
// <copyright file="PolyFunction.cs" company="FH Wiener Neustadt">
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
    using System.Windows;

    /// <summary>
    /// The <see cref="PolyFunction"/> partial class.
    /// </summary>
    [Serializable]
    public class PolyFunction : MathFunction
    {
        /// <summary>
        /// The parameter list.
        /// </summary>
        private List<float> parameterList;

        /// <summary>
        /// The degree of the function.
        /// </summary>
        private int degree;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolyFunction"/> class.
        /// </summary>
        /// <param name="values"> A list of float values as the parameters. </param>
        public PolyFunction(List<float> values)
        {
            this.Points = new List<Point>();
            this.ParameterList = new List<float>();
            this.ParameterList.Capacity = 11;
            foreach (var item in values)
            {
                this.ParameterList.Add(item);
            }

            this.Name = "Default";
        }

        /// <summary>
        /// Gets or sets the parameter list for the function.
        /// </summary>
        /// <value> A normal list of float values. </value>
        public override List<float> ParameterList
        {
            get
            {
                return this.parameterList;
            }

            set
            {
                if (value == null || value.Capacity > 11)
                {
                    throw new ArgumentOutOfRangeException("Error the list cant be larger than 11 Elements.");
                }

                this.parameterList = value;
            }
        }

        /// <summary>
        /// Gets or sets the degree of the function.
        /// </summary>
        /// <value> A normal integer value between 0 and 10. </value>
        public int Degree
        { 
            get
            {
                return this.degree;
            }

            set
            {
                if (value > 10 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("Error the most alowed value for degree is between 10 and 0.");
                }

                this.degree = value;
            }
        }

        /// <summary>
        /// Calculates the points for the function.
        /// </summary>
        /// <param name="smallestXValue"> The smallest value on the x-axis. </param>
        /// <param name="bigestXValue"> The biggest value on the x-axis. </param>
        public override void CalculatePoints(double smallestXValue, double bigestXValue)
        {
            this.Points.Clear();

            for (double i = smallestXValue; i <= bigestXValue; i = i + 0.1)
            {
                double y = 0;
                for (int j = 0; j < this.parameterList.Count; j++)
                {
                    y = y + (this.parameterList[j] * Math.Pow(i, (double)j));
                }

                this.Points.Add(new Point(i, y));
            }
        }
    }
}
