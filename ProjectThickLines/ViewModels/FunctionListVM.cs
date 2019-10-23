//-----------------------------------------------------------------------
// <copyright file="FunctionListVM.cs" company="FH Wiener Neustadt">
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
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Input;
    using ProjectThickLines.Commands;
    using ProjectThickLines.Models;

    /// <summary>
    /// Initializes a new instance of the <see cref="FunctionListVM"/> class.
    /// </summary>
    public class FunctionListVM
    {
        /// <summary>
        /// The command to delete a <see cref="TrigFunctionVM"/> from the list view.
        /// </summary>
        private readonly ICommand removeCommand;

        /// <summary>
        /// The command to delete a <see cref="PolyFunctionVM"/> from the list view.
        /// </summary>
        private readonly ICommand removeCommandPoly;

        /// <summary>
        /// A simple dialogue for opening files.
        /// </summary>
        private OpenFileDialog openFileDialog1;

        /// <summary>
        /// A simple dialogue for saving files.
        /// </summary>
        private SaveFileDialog saveFileDialogue;

        /// <summary>
        /// The smallest value on x axis.
        /// </summary>
        private double smallestxValue;

        /// <summary>
        /// The biggest value on x axis.
        /// </summary>
        private double bigestxValue;

        /// <summary>
        /// The smallest value on y axis.
        /// </summary>
        private double smallestyValue;

        /// <summary>
        /// The biggest value on y axis.
        /// </summary>
        private double bigestyValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionListVM"/> class.
        /// </summary>
        public FunctionListVM()
        {
            this.TrigFunctions = new ObservableCollection<TrigFunctionVM>();
            this.PolyFunctions = new ObservableCollection<PolyFunctionVM>();
            this.removeCommand = new Command(obj =>
            {
                var functionVM = obj as TrigFunctionVM;

                if (functionVM != null)
                {
                    this.TrigFunctions.Remove(functionVM);
                    this.CalculateBiggestYANDSmallestY();
                }
            });
            this.removeCommandPoly = new Command(obj =>
            {
                var functionVM = obj as PolyFunctionVM;

                if (functionVM != null)
                {
                    this.PolyFunctions.Remove(functionVM);
                    this.CalculateBiggestYANDSmallestY();
                }
            });

            this.DegreeOfPolyFunction = 2;
            this.saveFileDialogue = new SaveFileDialog();
            this.openFileDialog1 = new OpenFileDialog();
            this.saveFileDialogue.Filter = "dat files (*.dat)|*.dat";
            this.openFileDialog1.Filter = "dat files (*.dat)|*.dat";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionListVM"/> class.
        /// </summary>
        /// <param name="functionalListVMContainer"> The container file of the saved <see cref="FunctionListVM"/>. </param>
        /// <param name="smallestXValue"> The smallest value on x axis. </param>
        /// <param name="biggestXValue"> The biggest value on x axis. </param>
        /// <param name="smallestYValue"> The smallest value on y axis. </param>
        /// <param name="biggestYvalue"> The biggest value on y axis. </param>
        public FunctionListVM(FunctionalListVMContainer functionalListVMContainer, double smallestXValue, double biggestXValue, double smallestYValue, double biggestYvalue)
        {
            this.TrigFunctions = new ObservableCollection<TrigFunctionVM>();
            this.PolyFunctions = new ObservableCollection<PolyFunctionVM>();
            this.removeCommand = new Command(obj =>
            {
                var functionVM = obj as TrigFunctionVM;

                if (functionVM != null)
                {
                    this.TrigFunctions.Remove(functionVM);
                    this.CalculateBiggestYANDSmallestY();
                }
            });
            this.removeCommandPoly = new Command(obj =>
            {
                var functionVM = obj as PolyFunctionVM;

                if (functionVM != null)
                {
                    this.PolyFunctions.Remove(functionVM);
                    this.CalculateBiggestYANDSmallestY();
                }
            });

            foreach (var item in functionalListVMContainer.PolyFunctionVMContainers)
            {
                var temp = new PolyFunctionVM(item, this.removeCommandPoly);
                temp.OnPolyFunctionChanged += this.DrawNewPolyLineForPolyFunction;
                this.PolyFunctions.Add(temp);
            }

            foreach (var item in functionalListVMContainer.TrigFunctionVMContainers)
            {
                var temp = new TrigFunctionVM(item, this.removeCommand);
                temp.OnTrigFunctionChanged += this.DrawNewPolyLineForTrigFunction;
                this.TrigFunctions.Add(temp);
            }

            this.smallestxValue = smallestXValue;
            this.bigestxValue = biggestXValue;
            this.smallestyValue = smallestYValue;
            this.bigestyValue = biggestYvalue;
            this.DegreeOfPolyFunction = 2;
            this.saveFileDialogue = new SaveFileDialog();
            this.openFileDialog1 = new OpenFileDialog();
            this.saveFileDialogue.Filter = "dat files (*.dat)|*.dat";
            this.openFileDialog1.Filter = "dat files (*.dat)|*.dat";
            this.DrawNewPolyLines();
        }

        /// <summary>
        /// The event to be fired when the biggest value on the y axis should be changed.
        /// </summary>
        public event EventHandler<IntValueEventArgs> OnYMaxChanged;

        /// <summary>
        /// The event to be fired when the smallest value on the y axis should be changed.
        /// </summary>
        public event EventHandler<IntValueEventArgs> OnYMinChanged;

        /// <summary>
        /// Gets the command to add a new <see cref="PolyFunctionVM"/> to the list.
        /// </summary>
        /// <value> A instance of the <see cref="ICommand"/>. </value>
        public ICommand AddPolyFunctionCommand
        {
            get
            {
                return new Command(obj =>
                {
                    var numbers = Enumerable.Repeat(1f, this.DegreeOfPolyFunction + 1).ToList();
                    var numbers2 = Enumerable.Repeat(0f, 10 - this.DegreeOfPolyFunction).ToList();
                    var numbers3 = numbers.Concat(numbers2).ToList();
                    var polyFunction = new PolyFunction(numbers3);
                    var vm = new PolyFunctionVM(polyFunction, this.removeCommandPoly);
                    vm.GetPolyline(this.SmallestXValueGrid, this.BigestXValueGrid, this.SmallestYValueGrid, this.BigestYValueGrid);
                    vm.OnPolyFunctionChanged += this.DrawNewPolyLineForPolyFunction;
                    this.PolyFunctions.Add(vm);
                    this.CalculateBiggestYANDSmallestY();
                });
            }
        }

        /// <summary>
        /// Gets the command to save current functions to a file.
        /// </summary>
        /// <value> A instance of the <see cref="ICommand"/>. </value>
        public ICommand SaveAllFunctions
        {
            get
            {
                return new Command(obj =>
                {
                    if (saveFileDialogue.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            var filePath = saveFileDialogue.FileName;
                            var container = new FunctionalListVMContainer(this);
                            FunctionSerealizerVM.Save(filePath, container);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occured: " + ex);
                        }
                    }
                });
            }
        }

        /// <summary>
        /// Gets the command to load functions to a file.
        /// </summary>
        /// <value> A instance of the <see cref="ICommand"/>. </value>
        public ICommand LoadAllFunctions
        {
            get
            {
                return new Command(obj =>
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            var filePath = openFileDialog1.FileName;

                            var container = FunctionSerealizerVM.Load(filePath);
                            this.AddSavedFunctionsToList(container);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occured: " + ex);
                        }
                    }
                });
            }
        }

        /// <summary>
        /// Gets or sets the degree of the <see cref="PolyFunction"/>.
        /// </summary>
        /// <value> A value between 0 and 10. </value>
        public int DegreeOfPolyFunction
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the possible integers for the <see cref="PolyFunction"/>.
        /// </summary>
        /// <value> A value between 0 and 10. </value>
        public IEnumerable<int> PossibleDegree
        {
            get
            {
                return Enumerable.Range(0, 11).ToList();
            }
        }

        /// <summary>
        /// Gets or sets the value of the smallest value on x axis.
        /// </summary>
        /// <value> A normal integer. </value>
        public double SmallestXValueGrid
        {
            get
            {
                return this.smallestxValue;
            }

            set
            {
                this.smallestxValue = value;
                this.DrawNewPolyLines();
                this.CalculateBiggestYANDSmallestY();
            }
        }

        /// <summary>
        /// Gets or sets the value of the biggest value on x axis.
        /// </summary>
        /// <value> A normal integer. </value>
        public double BigestXValueGrid
        {
            get
            {
                return this.bigestxValue;
            }

            set
            {
                this.bigestxValue = value;
                this.DrawNewPolyLines();
                this.CalculateBiggestYANDSmallestY();
            }
        }

        /// <summary>
        /// Gets or sets the value of the smallest value on y axis.
        /// </summary>
        /// <value> A normal integer. </value>
        public double SmallestYValueGrid
        {
            get
            {
                return this.smallestyValue;
            }

            set
            {
                this.smallestyValue = value;
                this.DrawNewPolyLines();
            }
        }

        /// <summary>
        /// Gets or sets the value of the biggest value on y axis.
        /// </summary>
        /// <value> A normal integer. </value>
        public double BigestYValueGrid
        {
            get
            {
                return this.bigestyValue;
            }

            set
            {
                this.bigestyValue = value;
                this.DrawNewPolyLines();
            }
        }
        
        /// <summary>
        /// Gets the <see cref="ObservableCollection{T}"/> for the <see cref="TrigFunctionVM"/>.
        /// </summary>
        /// <value> A normal <see cref="ObservableCollection{T}"/>. </value>
        public ObservableCollection<TrigFunctionVM> TrigFunctions
        {
            get;
        }

        /// <summary>
        /// Gets the <see cref="ObservableCollection{T}"/> for the <see cref="PolyFunctionVM"/>.
        /// </summary>
        /// <value> A normal <see cref="ObservableCollection{T}"/>. </value>
        public ObservableCollection<PolyFunctionVM> PolyFunctions
        {
            get;
        }

        /// <summary>
        /// Gets the command to add <see cref="TrigFunction"/> to the list view.
        /// </summary>
        /// <value> A instance of the <see cref="ICommand"/>. </value>
        public ICommand AddTrigFunctionCommand
        {
            get
            {
                return new Command(obj =>
                {
                    var trigFunction = new TrigFunction();
                    var vm = new TrigFunctionVM(trigFunction, this.removeCommand);
                    vm.GetPolyline(this.SmallestXValueGrid, this.BigestXValueGrid, this.SmallestYValueGrid, this.BigestYValueGrid);
                    vm.OnTrigFunctionChanged += this.DrawNewPolyLineForTrigFunction;
                    this.TrigFunctions.Add(vm);
                    this.CalculateBiggestYANDSmallestY();
                });
            }
        }

        /// <summary>
        /// This method adds saved functions to the current lists.
        /// </summary>
        /// <param name="c"> The container file. </param>
        public void AddSavedFunctionsToList(FunctionalListVMContainer c)
        {
            while (this.PolyFunctions.Count != 0)
            {
                this.PolyFunctions.RemoveAt(0);
            }

            while (this.TrigFunctions.Count != 0)
            {
                this.TrigFunctions.RemoveAt(0);
            }

            foreach (var item in c.TrigFunctionVMContainers)
            {
                var vm = new TrigFunctionVM(item, this.removeCommand);
                vm.FunctionColor = item.FunctionColor;
                vm.StrokeThickness = item.StrokeThickness;
                vm.Opacity = item.Opacity;
                vm.Name = item.TrigFunction.Name;
                vm.GetPolyline(this.SmallestXValueGrid, this.BigestXValueGrid, this.SmallestYValueGrid, this.BigestYValueGrid);
                vm.OnTrigFunctionChanged += this.DrawNewPolyLineForTrigFunction;
                this.TrigFunctions.Add(vm);
            }

            foreach (var item in c.PolyFunctionVMContainers)
            {
                var polyFunction = new PolyFunction(item.PolyFunction.ParameterList);
                var vm = new PolyFunctionVM(polyFunction, this.removeCommandPoly);
                vm.FunctionColor = item.FunctionColor;
                vm.StrokeThickness = item.StrokeThickness;
                vm.Opacity = item.Opacity;
                vm.Name = item.PolyFunction.Name;
                vm.GetPolyline(this.SmallestXValueGrid, this.BigestXValueGrid, this.SmallestYValueGrid, this.BigestYValueGrid);
                vm.OnPolyFunctionChanged += this.DrawNewPolyLineForPolyFunction;
                this.PolyFunctions.Add(vm);
            }
        }

        /// <summary>
        /// This method changes the current values of the x-y axis.
        /// </summary>
        /// <param name="sender"> The object sender. </param>
        /// <param name="e"> The <see cref="IntValueEventArgs"/>. </param>
        public void ChangeXYValueGrid(object sender, IntValueEventArgs e)
        {
            switch (e.XYAxisEnum.Name)
            {
                case "SmallestXValue":
                    this.SmallestXValueGrid = e.Value;
                    break;
                case "BiggestXValue":
                    this.BigestXValueGrid = e.Value;
                    break;
                case "SmallestYValue":
                    this.SmallestYValueGrid = e.Value;
                    break;
                case "BiggestYValue":
                    this.BigestYValueGrid = e.Value;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// This method gets new points for the view. 
        /// </summary>
        public void DrawNewPolyLines()
        {
            List<TrigFunctionVM> clonedTrig = new List<TrigFunctionVM>();
            List<PolyFunctionVM> clonedPoly = new List<PolyFunctionVM>();

            foreach (var item in this.TrigFunctions)
            {
                clonedTrig.Add(item);
            }

            foreach (var item in this.PolyFunctions)
            {
                clonedPoly.Add(item);
            }

            this.PolyFunctions.Clear();
            this.TrigFunctions.Clear();

            foreach (var item in clonedTrig)
            {
                item.GetPolyline(this.SmallestXValueGrid, this.BigestXValueGrid, this.SmallestYValueGrid, this.BigestYValueGrid);
                this.TrigFunctions.Add(item);
            }

            foreach (var item in clonedPoly)
            {
                item.GetPolyline(this.SmallestXValueGrid, this.BigestXValueGrid, this.SmallestYValueGrid, this.BigestYValueGrid);
                this.PolyFunctions.Add(item);
            }
        }

        /// <summary>
        /// This method gets new points for the view of the current <see cref="TrigFunctionVM"/>. 
        /// </summary>
        /// <param name="sender"> The object sender. </param>
        /// <param name="e"> The <see cref="TrigFunctionVMEventArgs"/>. </param>
        public void DrawNewPolyLineForTrigFunction(object sender, TrigFunctionVMEventArgs e)
        {
            this.TrigFunctions.Where(x => x == e.OldItem).FirstOrDefault().GetPolyline(this.SmallestXValueGrid, this.BigestXValueGrid, this.SmallestYValueGrid, this.BigestYValueGrid);
            this.CalculateBiggestYANDSmallestY();
        }

        /// <summary>
        /// This method gets new points for the view of the current <see cref="PolyFunctionVM"/>. 
        /// </summary>
        /// <param name="sender"> The object sender. </param>
        /// <param name="e"> The <see cref="PolyFunctionVMEventArgs"/>. </param>
        public void DrawNewPolyLineForPolyFunction(object sender, PolyFunctionVMEventArgs e)
        {
            this.PolyFunctions.Where(x => x == e.PolyFunctionVM).FirstOrDefault().GetPolyline(this.SmallestXValueGrid, this.BigestXValueGrid, this.SmallestYValueGrid, this.BigestYValueGrid);
            this.CalculateBiggestYANDSmallestY();
        }

        /// <summary>
        /// Fires the <see cref="OnYMinChanged"/> event.
        /// </summary>
        /// <param name="e"> The current value. </param>
        protected virtual void ChangeYMinValue(IntValueEventArgs e)
        {
            if (this.OnYMinChanged != null)
            {
                this.OnYMinChanged(this, e);
            }
        }

        /// <summary>
        /// Fires the <see cref="OnYMaxChanged"/> event.
        /// </summary>
        /// <param name="e"> The current value. </param>
        protected virtual void ChangeYMaxValue(IntValueEventArgs e)
        {
            if (this.OnYMaxChanged != null)
            {
                this.OnYMaxChanged(this, e);
            }
        }

        /// <summary>
        /// This method calculates the biggest and smallest y value.
        /// </summary>
        private void CalculateBiggestYANDSmallestY()
        {
            double yMAX = 0;
            double yMin = 0;

            if (this.TrigFunctions.Count > 0)
            {
                yMin = this.TrigFunctions[0].TrigFunctionM.Points.OrderByDescending(e => e.Y).Last().Y;
                yMAX = this.TrigFunctions[0].TrigFunctionM.Points.OrderByDescending(e => e.Y).First().Y;
            }
            else if (this.PolyFunctions.Count > 0)
            {
                yMin = this.PolyFunctions[0].Model.Points.OrderByDescending(e => e.Y).Last().Y;
                yMAX = this.PolyFunctions[0].Model.Points.OrderByDescending(e => e.Y).First().Y;
            }

            foreach (var item in this.TrigFunctions)
            {
                if (item.TrigFunctionM.Points.OrderByDescending(e => e.Y).First().Y > yMAX)
                {
                    yMAX = item.TrigFunctionM.Points.OrderByDescending(e => e.Y).First().Y;
                }

                if (item.TrigFunctionM.Points.OrderByDescending(e => e.Y).Last().Y < yMin)
                {
                    yMin = item.TrigFunctionM.Points.OrderByDescending(e => e.Y).Last().Y;
                }
            }

            foreach (var item in this.PolyFunctions)
            {
                if (item.Model.Points.OrderByDescending(e => e.Y).First().Y > yMAX)
                {
                    yMAX = item.Model.Points.OrderByDescending(e => e.Y).First().Y;
                }

                if (item.Model.Points.OrderByDescending(e => e.Y).Last().Y < yMin)
                {
                    yMin = item.Model.Points.OrderByDescending(e => e.Y).Last().Y;
                }
            }

            if (yMAX > 10000)
            {
                yMAX = 10000;
            }
            else if (yMin < -10000)
            {
                yMin = -10000;
            }

            try
            {
                this.ChangeYMaxValue(new IntValueEventArgs(yMAX, new BiggestYValue()));
                this.ChangeYMinValue(new IntValueEventArgs(yMin, new SmallestYValue()));
            }
            catch (Exception)
            {
                this.ChangeYMaxValue(new IntValueEventArgs(10, new BiggestYValue()));
                this.ChangeYMinValue(new IntValueEventArgs(-8, new SmallestYValue()));
            }
        }
    }
}
