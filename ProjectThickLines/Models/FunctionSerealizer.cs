//-----------------------------------------------------------------------
// <copyright file="FunctionSerealizer.cs" company="FH Wiener Neustadt">
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
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// The <see cref="FunctionSerealizer"/> class.
    /// </summary>
    public static class FunctionSerealizer
    {
        /// <summary>
        /// Saves the function to the given path.
        /// </summary>
        /// <param name="filePath"> The file path where the file is saved. </param>
        /// <param name="objToSerialize"> The file to be serialized. </param>
        public static void Save(string filePath, ContainerFileForSerealization objToSerialize)
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
        /// Creates a object out of a serialized file.
        /// </summary>
        /// <param name="filePath"> The file path where the file is saved. </param>
        /// <returns> It returns a new object. </returns>
        public static ContainerFileForSerealization Load(string filePath)
        {
            try
            {
                using (Stream stream = File.Open(filePath, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    var rez = (ContainerFileForSerealization)bin.Deserialize(stream);
                    return rez;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error: " + e);
            }
        }
    }
}
