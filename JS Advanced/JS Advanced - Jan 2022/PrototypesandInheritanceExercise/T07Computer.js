function createComputerHierarchy() {
    class Keyboard {
        constructor(manufacturer, responseTime) {
            this.manufacturer = manufacturer;
            this.responseTime = responseTime;
        }
    }
    class Monitor {
        constructor(manufacturer, width, height) {
            this.manufacturer = manufacturer;
            this.width = width;
            this.height = height;
        }
    }
    class Battery {
        constructor(manufacturer, expectedLife) {
            this.manufacturer = manufacturer;
            this.expectedLife = expectedLife;
        }
    }
    class Computer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {
            if (new.target === Computer) {
                throw new Error("Computer is abstract class");
            }
            this.manufacturer = manufacturer;
            this.processorSpeed = processorSpeed;
            this.ram = ram;
            this.hardDiskSpace = hardDiskSpace;
        }
    }
    class Laptop extends Computer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace)
            this.weight = weight;
            this.color = color;
            this.battery = battery;
        }

        set battery(battery) {
            if (!(battery instanceof Battery)) {
                throw new TypeError("Invalid battery");
            }
            this._battery = battery;
        }
        get battery() { return this._battery; }
    }
    class Desktop extends Computer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace)
            this.keyboard = keyboard;
            this.monitor = monitor;
        }
        set keyboard(keyboard) {
            if (!(keyboard instanceof Keyboard)) {
                throw new TypeError("Invalid keyboard")
            }
            this._keyboard = keyboard;
        }
        get keyboard() { return this._keyboard; }

        set monitor(monitor) {
            if (!(monitor instanceof Monitor)) {
                throw new TypeError("Invalid monitor");
            }
            this._monitor = monitor;
        }
        get monitor() { return this._monitor; }
    }

    return {
        Battery,
        Keyboard,
        Monitor,
        Computer,
        Laptop,
        Desktop
    }
}