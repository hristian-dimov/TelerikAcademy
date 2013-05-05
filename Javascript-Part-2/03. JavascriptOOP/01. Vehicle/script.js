var vehicles = (function () {
    Function.prototype.inherit = function (parent) {
        this.prototype = new parent();
        this.prototype.constructor = this;
    };

    Function.prototype.extend = function (parent) {
        for (var i = 1; i < arguments.length; i += 1) {
            var name = arguments[i];
            this.prototype[name] = parent.prototype[name];
        }

        return this;
    };

    // Constants ### http://stackoverflow.com/questions/287903/enums-in-javascript/5040502#5040502 ###
    var AfterburnerState = Object.freeze({
        "ON": 1,
        "OFF": 2
    });

    var RotationDirection = Object.freeze({
        "CLOCKWISE": 1,
        "COUNTERCLOCKWISE": 2
    });

    var AmphibianMode = Object.freeze({
        "LAND": 1,
        "WATER": 2
    });

    // PropulsionUnit class
    function PropulsionUnit() { }

    PropulsionUnit.prototype.getAcceleration = function () {
        throw new Error("Cannot get acceleration without specifying the propulsion unit type!");
    }

    // Wheel class
    function Wheel(radius) {
        this.radius = radius;
    }

    Wheel.inherit(PropulsionUnit);

    Wheel.prototype.getAcceleration = function () {
        var acceleration = 2 * Math.PI * this.radius;
        return acceleration;
    }

    // PropellingNozzle class
    function PropellingNozzle(power, afterburnerState) {
        this.power = power;
        this.afterburnerState = afterburnerState;
    }

    PropellingNozzle.inherit(PropulsionUnit);

    PropellingNozzle.prototype.getAcceleration = function () {
        var acceleration;
        if (this.afterburnerState == AfterburnerState.ON) {
            acceleration = 2 * this.power;
        } else {
            acceleration = this.power;
        }

        return acceleration;
    }

    // Propeller class
    function Propeller(finsCount, spinDirection) {
        this.finsCount = finsCount;
        this.spinDirection = spinDirection;
    }

    Propeller.inherit(PropulsionUnit);

    Propeller.prototype.getAcceleration = function () {
        var acceleration;
        if (this.spinDirection == RotationDirection.CLOCKWISE) {
            acceleration = this.finsCount;
        } else {
            acceleration = -1 * this.finsCount;
        }

        return acceleration;
    }

    // Vehicle class / base class /
    function Vehicle(speed, propulsionUnits) {
        this.speed = speed;
        this.propulsionUnits = propulsionUnits;
    }

    Vehicle.prototype.accelerate = function () {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            this.speed += this.propulsionUnits[i].getAcceleration();
        }
    }

    // LandVehicle class
    function LandVehicle(speed, wheels) {
        if (wheels.length != 4) {
            throw new Error("The propulsionUnits array must contain only 4 wheels!");
        }

        Vehicle.apply(this, arguments);
    }

    LandVehicle.inherit(Vehicle);

    // Aircraft class
    function Aircraft(speed, propellingNozzles) {
        if (propellingNozzles.length < 1) {
            throw new Error("The propellingNozzles array must contain more than 1 propelling nozzle");
        }

        Vehicle.apply(this, arguments);
    }

    Aircraft.inherit(Vehicle);

    Aircraft.prototype.switchAfterburners = function (afterburnerState) {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            if (this.propulsionUnits[i] instanceof PropellingNozzle) {
                this.propulsionUnits[i].afterburnerState = afterburnerState;
            }
        }
    }

    // Watercraft class
    function Watercraft(speed, propellers) {
        Vehicle.apply(this, arguments);
    }

    Watercraft.inherit(Vehicle);

    Watercraft.prototype.setPropellersRotationDirection = function (rotationDirection) {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            if (this.propulsionUnits[i] instanceof Propeller) {
                this.propulsionUnits[i].rotationDirection = rotationDirection;
            }
        }
    }

    // Amphibian class
    function Amphibian(speed, propellers, wheels, mode) {

        var propulsionUnits = [];
        for (var i = 0; i < propellers.length; i++) {
            propulsionUnits.push(propellers[i]);
        }

        for (var j = 0; j < wheels.length; j++) {
            propulsionUnits.push(wheels[i]);
        }

        Vehicle.call(this, speed, propulsionUnits);
        this.mode = mode;
    }

    Amphibian.inherit(Vehicle);
    Amphibian.extend(Watercraft, "setPropellersRotationDirection");

    Amphibian.prototype.accelerate = function () {
        var i = 0;
        if (this.mode === AmphibianMode.LAND) {
            for (i = 0; i < this.propulsionUnits.length; i++) {
                if (this.propulsionUnits[i] instanceof Wheel) {
                    this.speed += this.propulsionUnits[i].getAcceleration();
                }
            }
        } else {
            for (i = 0; i < this.propulsionUnits.length; i++) {
                if (this.propulsionUnits[i] instanceof Propeller) {
                    this.speed += this.propulsionUnits[i].getAcceleration();
                }
            }
        }
    }

    return {
        AfterburnerState: AfterburnerState,
        RotationDirection: RotationDirection,
        AmphibianMode: AmphibianMode,
        Wheel: Wheel,
        PropellingNozzle: PropellingNozzle,
        Propeller: Propeller,
        LandVehicle: LandVehicle,
        Aircraft: Aircraft,
        Watercraft: Watercraft,
        Amphibian: Amphibian
    };
})();