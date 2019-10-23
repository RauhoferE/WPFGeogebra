//-----------------------------------------------------------------------
// <copyright file="FunctionSerealizerVM.cs" company="FH Wiener Neustadt">
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
    /// The serializer for the functions.
    /// </summary>
    public static class FunctionSerealizerVM
    {
        /// <summary>
        /// Saves the function to the given path.
        /// </summary>
        /// <param name="filePath"> The file path where the file is saved. </param>
        /// <param name="objToSerialize"> The file to be serialized. </param>
        public static void Save(string filePath, FunctionalListVMContainer objToSerialize)
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
        public static FunctionalListVMContainer Load(string filePath)
        {
            try
            {
                using (Stream stream = File.Open(filePath, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    var rez = (FunctionalListVMContainer)bin.Deserialize(stream);
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
