namespace OnlineShop.Models.Products.Computers
{
    using OnlineShop.Common.Constants;
    using OnlineShop.Models.Products.Components;
    using OnlineShop.Models.Products.Peripherals;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => (IReadOnlyCollection<IComponent>)components;

        public IReadOnlyCollection<IPeripheral> Peripherals => (IReadOnlyCollection<IPeripheral>)peripherals;

        public override decimal Price => base.Price + this.components.Sum(x => x.Price) + this.peripherals.Sum(x => x.Price);

        public override double OverallPerformance
        {
            get
            {
                if (this.components.Count == 0)
                    return base.OverallPerformance;

                return base.OverallPerformance + this.components.Average(x => x.OverallPerformance);
            }
        }

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(x => x.GetType().Name == component.GetType().Name))
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (this.components.Count == 0 || !this.components.Any(x => x.GetType().Name == componentType))
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));

            var componentToRemove = this.components.First(x => x.GetType().Name == componentType);
            this.components.Remove(componentToRemove);

            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.peripherals.Count == 0 || !this.peripherals.Any(x => x.GetType().Name == peripheralType))
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));

            var peripheralToRemove = this.peripherals.First(x => x.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheralToRemove);

            return peripheralToRemove;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.components.Count}):");

            foreach (var component in this.components)
                sb.AppendLine($"  {component}");

            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.peripherals.Average(x => x.OverallPerformance)}):");

            foreach (var peripheral in this.peripherals)
                sb.AppendLine($"  {peripheral}");

            return sb.ToString().TrimEnd();
        }
    }
}
