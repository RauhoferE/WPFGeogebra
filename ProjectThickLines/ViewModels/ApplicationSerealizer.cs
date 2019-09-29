//-----------------------------------------------------------------------
// <copyright file="ApplicationSerealizer.cs" company="FH Wiener Neustadt">
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
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// The <see cref="ApplicationSerealizer"/> class.
    /// </summary>
    public static class ApplicationSerealizer
    {
        /// <summary>
        /// Saves the current application status to the file path.
        /// </summary>
        /// <param name="filePath"> The path to the file. </param>
        /// <param name="objToSerialize"> The object to be serialized. </param>
        public static void Save(string filePath, MainWindowVMContainer objToSerialize)
        {
            try
            {
                using (Stream stream = File.Open(filePath, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, objToSerialize);
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error: " + e);
            }
        }

        /// <summary>
        /// Creates a object from the serialized file.
        /// </summary>
        /// <param name="filePath"> The path to the file. </param>
        /// <returns> It returns a new object. </returns>
        public static MainWindowVMContainer Load(string filePath)
        {
            try
            {
                using (Stream stream = File.Open(filePath, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    var rez = (MainWindowVMContainer)bin.Deserialize(stream);
                    return rez;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
