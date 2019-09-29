//-----------------------------------------------------------------------
// <copyright file="TrigFunction.cs" company="FH Wiener Neustadt">
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
    /// The <see cref="TrigFunction"/> class.
    /// </summary>
    [Serializable]
    public class TrigFunction : MathFunction
    {
        /// <summary>
        /// The parameter list.
        /// </summary>
        private List<float> parameterList;

        /// <summary>
        /// Represents the angle of the function.
        /// </summary>
        private IAngle angle;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrigFunction"/> class.
        /// </summary>
        public TrigFunction()
        {
            this.ParameterList = new List<float>();
            this.Points = new List<Point>();
            this.Name = "Default";
            this.ParameterList.Add(1f);
            this.ParameterList.Add(1f);
            this.ParameterList.Add(0f);
            this.Angle = new Sine();
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
                if (value == null)
                {
                    throw new ArgumentNullException("Error list cant be null.");
                }

                this.parameterList = value;
            }
        }

        /// <summary>
        /// Gets or sets angle of the function.
        /// </summary>
        /// <value> An angle from the angle . </value>
        public IAngle Angle
        {
            get
            {
                return this.angle;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Error value cant be null.");
                }

                this.angle = value;
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

            switch (this.Angle.Name)
            {
                case "Sine":
                    this.CalculateSine(smallestXValue, bigestXValue);
                    break;
                case "Cosine":
                    this.CalculateCosine(smallestXValue, bigestXValue);
                    break;
                case "Tangent":
                    this.CalculateTan(smallestXValue, bigestXValue);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Calculates the points for the function.
        /// </summary>
        /// <param name="smallestXValue"> The smallest value on the x-axis. </param>
        /// <param name="bigestXValue"> The biggest value on the x-axis. </param>
        private void CalculateSine(double smallestXValue, double bigestXValue)
        {
            for (double i = smallestXValue; i <= bigestXValue; i = i + 0.1)
            {
                double x = i;
                double y = (this.parameterList[0] * Math.Sin(this.parameterList[1] * i)) + this.parameterList[2];
                this.Points.Add(new Point(x, y));
            }
        }

        /// <summary>
        /// Calculates the points for the function.
        /// </summary>
        /// <param name="smallestXValue"> The smallest value on the x-axis. </param>
        /// <param name="bigestXValue"> The biggest value on the x-axis. </param>
        private void CalculateCosine(double smallestXValue, double bigestXValue)
        {
            for (double i = smallestXValue; i <= bigestXValue; i = i + 0.1)
            {
                double x = i;
                double y = (this.parameterList[0] * Math.Cos(this.parameterList[1] * i)) + this.parameterList[2];
                this.Points.Add(new Point(x, y));
            }
        }

        /// <summary>
        /// Calculates the points for the function.
        /// </summary>
        /// <param name="smallestXValue"> The smallest value on the x-axis. </param>
        /// <param name="bigestXValue"> The biggest value on the x-axis. </param>
        private void CalculateTan(double smallestXValue, double bigestXValue)
        {
            for (double i = smallestXValue; i <= bigestXValue; i = i + 0.1)
            {
                double x = i;
                double y = (this.parameterList[0] * Math.Tan(this.parameterList[1] * i)) + this.parameterList[2];
                this.Points.Add(new Point(x, y));
            }
        }
    }
}
