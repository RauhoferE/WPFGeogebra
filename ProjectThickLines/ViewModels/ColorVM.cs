//-----------------------------------------------------------------------
// <copyright file="ColorVM.cs" company="FH Wiener Neustadt">
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
    using System.Windows.Media;

    /// <summary>
    /// The <see cref="ColorVM"/> struct.
    /// </summary>
    [Serializable]
    public struct ColorVM
    {
        /// <summary>
        /// The alpha byte value.
        /// </summary>
        public readonly byte A;

        /// <summary>
        /// The red byte value.
        /// </summary>
        public readonly byte R;

        /// <summary>
        /// The green byte value.
        /// </summary>
        public readonly byte G;

        /// <summary>
        /// The blue byte value.
        /// </summary>
        public readonly byte B;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorVM"/> struct.
        /// </summary>
        /// <param name="a"> The alpha value as a byte. </param>
        /// <param name="r"> The red value as a byte. </param>
        /// <param name="g"> The green value as a byte. </param>
        /// <param name="b"> The blue value as a byte. </param>
        public ColorVM(byte a, byte r, byte g, byte b)
        {
            this.A = a;
            this.R = r;
            this.G = g;
            this.B = b;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorVM"/> struct.
        /// </summary>
        /// <param name="color"> The color for the class. </param>
        public ColorVM(Color color)
            : this(color.A, color.R, color.G, color.B)
        {
        }

        /// <summary>
        /// This method returns a new <see cref="ColorVM"/> object.
        /// </summary>
        /// <param name="color"> The color for the object. </param>
        public static implicit operator ColorVM(Color color)
        {
            return new ColorVM(color);
        }

        /// <summary>
        /// This method returns a new <see cref="Color"/> object.
        /// </summary>
        /// <param name="colorVM"> The color for the object. </param>
        public static implicit operator Color(ColorVM colorVM)
        {
            return Color.FromArgb(colorVM.A, colorVM.R, colorVM.G, colorVM.B);
        }
    }
}
