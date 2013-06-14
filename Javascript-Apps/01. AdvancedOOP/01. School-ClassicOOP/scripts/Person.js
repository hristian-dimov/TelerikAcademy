var Person = Class.create({
    init: function (firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    },

    introduce: function () {
        return "Name: " + this.firstName + " " + this.lastName + ", Age: " + this.age;
    }
});

var Student = Class.create({
    init: function (firstName, lastName, age, grade) {
        this._super.init(firstName, lastName, age);
        this.grade = grade;
    },

    introduce: function () {
        return this._super.introduce() + ", Grade: " + this.grade;
    }
});

var Teacher = Class.create({
    init: function (firstName, lastName, age, speciality) {
        this._super.init(firstName, lastName, age);
        this.speciality = speciality;
    },

    introduce: function () {
        return this._super.introduce() + ", Specialty: " + this.speciality;
    }
});

Student.inherit(Person);
Teacher.inherit(Person);