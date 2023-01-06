using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Builder Design Pattern - Creational Pattern
    // Builder pattern solves the situation  of increasing Constrcutor parameters and constructors
    // of a given class by providing a step by step initialization of parameters.
    // After Step by Step initialization --> It returns the constructed object at last.

    // When to Choose
    // 1. When we need to break the construction of complex object
    // 2. when we need to create compex object and its independent of the parts that make up object
    // 3. When Construction process must allow multiple representation of same class.


    internal class BuilderDesignPattern
    {

        // Problem Statement

        public class ComputerSystem
        {
            private string _ramSize;
            private string _diskSize;

            public ComputerSystem(string ramSize, string diskSize)
            {
                _ramSize = ramSize;
                _diskSize = diskSize;
            }

            public string BuildTheSystem()
            {
                string systemCofiguration = "Ram Size " + _ramSize + ". Disk Size is " + _diskSize;
                return systemCofiguration;
            }
        }

        public class BuilderClient
        {
            public void Main()
            {
                // Desktop
                ComputerSystem desktop = new ComputerSystem("200GB", "100GB");
                string systemConfig = desktop.BuildTheSystem();

                // Laptop
            }
        }


        // Using Builder Design Pattern

        public class ComputerSystemBDP
        {
            public string RamSize { get; set; }
            public string DiskSize { get; set; }

            // Extending 
            public string MouseConfig { get; set; }
            public string TouchConfig { get; set; }


            public ComputerSystemBDP()
            {
            }

            public string BuildTheSystem()
            {
                string systemCofiguration = "Ram Size " + RamSize + ". Disk Size is " + DiskSize;
                return systemCofiguration;
            }
        }

  

        // IBuilder 
        interface ISystemBuilder
        {
            void AddRAMSize(string ramSize);
            void AddDiskSize(string diskSize);

            void AddMouseConfig(string mouse);

            void AddTouchConfig(string touch);

            ComputerSystemBDP GetSystem();
        }

        // Concrete Builder Classes

        public class DesktopBuilder : ISystemBuilder
        {
            ComputerSystemBDP desktop = new ComputerSystemBDP();
            public void AddDiskSize(string diskSize)
            {
                desktop.DiskSize = diskSize;
            }

            public void AddMouseConfig(string mouse)
            {
                desktop.MouseConfig = mouse;
            }

            public void AddRAMSize(string ramSize)
            {
                desktop.RamSize = ramSize;
            }

            public void AddTouchConfig(string touch)
            {
                return;
            }

            public ComputerSystemBDP GetSystem()
            {
                return desktop;
            }
        }

        public class LaptopBuilder : ISystemBuilder
        {
            ComputerSystemBDP laptop = new ComputerSystemBDP();
            public void AddDiskSize(string diskSize)
            {
                laptop.DiskSize = diskSize;
            }

            public void AddRAMSize(string ramSize)
            {
                laptop.RamSize = ramSize;
            }

            public void AddMouseConfig(string mouse)
            {
                return;
            }

            public void AddTouchConfig(string touch)
            {
                laptop.TouchConfig = touch;
            }

            public ComputerSystemBDP GetSystem()
            {
                return laptop;
            }
        }


        // Director

        public class Director
        {
            public void Main()
            {
                // Desktop
                ISystemBuilder desktopBuilder = new LaptopBuilder();
                desktopBuilder.AddDiskSize("300GB");
                desktopBuilder.AddRAMSize("100GB");

                ComputerSystemBDP desktopSystem = desktopBuilder.GetSystem();
                string desktopConfiguration = desktopSystem.BuildTheSystem();

                // Laptop
                ISystemBuilder laptopBuilder = new LaptopBuilder();
                laptopBuilder.AddDiskSize("500GB");
                laptopBuilder.AddRAMSize("200GB");

                ComputerSystemBDP laptopSystem = laptopBuilder.GetSystem();
                string laptopConfiguration = laptopSystem.BuildTheSystem();

            }
        }

        // Fluent Interface - It is a method for constructing Object oriented API's where the readbility of source code 
        // is close to that of ordinary written prose.
        // Allows Method Chaining
        // Fluent inteface implementation enables the code to apply multiple properties to an object by connecting them with dots.
        // No Difference in Functionality 

        // IBuilder 
        public interface ISystemBuilderF
        {
            ISystemBuilderF AddRAMSize(string ramSize);
            ISystemBuilderF AddDiskSize(string diskSize);
            ComputerSystemBDP GetSystem();
        }

        // Concrete Builder Classes

        public class DesktopBuilderF : ISystemBuilderF
        {
            ComputerSystemBDP desktop = new ComputerSystemBDP();
            public ISystemBuilderF AddDiskSize(string diskSize)
            {
                desktop.DiskSize = diskSize;
                return this;
            }

            public ISystemBuilderF AddRAMSize(string ramSize)
            {
                desktop.RamSize = ramSize;
                return this;
            }

            public ComputerSystemBDP GetSystem()
            {
                return desktop;
            }
        }

        public class LaptopBuilderF : ISystemBuilderF
        {
            ComputerSystemBDP laptop = new ComputerSystemBDP();
            public ISystemBuilderF AddDiskSize(string diskSize)
            {
                laptop.DiskSize = diskSize;
                return this;
            }

            public ISystemBuilderF AddRAMSize(string ramSize)
            {
                laptop.RamSize = ramSize;
                return this;
            }

            public ComputerSystemBDP GetSystem()
            {
                return laptop;
            }
        }


        // Director

        public class DirectorF
        {
            public void Main()
            {
                // Desktop
                ISystemBuilderF desktopBuilder = new LaptopBuilderF();
                desktopBuilder.AddDiskSize("300GB").AddRAMSize("100GB");

                ComputerSystemBDP desktopSystem = desktopBuilder.GetSystem();
                string desktopConfiguration = desktopSystem.BuildTheSystem();

                // Laptop
                ISystemBuilderF laptopBuilder = new LaptopBuilderF();
                laptopBuilder.AddDiskSize("500GB").AddRAMSize("200GB");

                ComputerSystemBDP laptopSystem = laptopBuilder.GetSystem();
                string laptopConfiguration = laptopSystem.BuildTheSystem();

            }
        }
    }

    // Builder DP encapsulates the complex creation into single method. and that method is builder. it heaps to create objects in step by step pattern

    }

